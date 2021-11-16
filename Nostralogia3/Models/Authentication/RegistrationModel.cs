using Nostralogia3.Models.Helpers;
using Nostralogia3.Utilities;
using NostralogiaDAL.SMGeneralEntities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Nostralogia3.Models.Authentication
{
    public class RegistrationModel : MUser
    {
        [DisplayName("Confirmation Email")]
        [Compare("Email", ErrorMessage = "The email and confirmation do not match.")]
        public string ConfirmEmail { get; set; }

        public string ErrorMessage { get; set; }

        public bool SaveUser()
        {
            bool brez = false;
            StringGenerator strgen = new StringGenerator();
            string salt = strgen.GenericString;
            strgen.Generate();
            string pass = strgen.GenericString;
            strgen = new StringGenerator(16);
            string vector = strgen.GenericString;

            SMGeneralContext context = new SMGeneralContext();
            User user = new User();
            SMRijndaelEncryption ecryptor = new SMRijndaelEncryption(salt, pass, vector);
            try
            {
                user.UserName = UserName;
                user.Password = ecryptor.Encrypt(Password);
                user.Email = ecryptor.Encrypt(Email);
                user.City = City;
                user.Country = Country;
                user.FirstName = ecryptor.Encrypt(StrWraper( FirstName));
                user.LastName = ecryptor.Encrypt(StrWraper(LastName));
                user.MidleName = ecryptor.Encrypt(StrWraper(MidleName));
                user.Sex = Sex;
                context.Users.Add(user);
                context.SaveChanges();
                int Id = user.Id;
                //Save salt etc...
                SecurityProtocol prot = new SecurityProtocol();
                prot.Initvector = vector;
                prot.Passcode = pass;
                prot.Salt = salt;
                prot.UserName = UserName;
                context.SecurityProtocols.Add(prot);
                context.SaveChanges();
                brez = true;
            }
            catch(Exception e)
            {
                LogMaster Log = new LogMaster();
                Log.SetLogException("RegistrationModel", "SaveUser", e.Message);
                ErrorMessage = "Registration has failed! Please check log files."; 
            }
            return brez;
        }
    }
}
