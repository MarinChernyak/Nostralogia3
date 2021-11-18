using Nostralogia3.Models.Helpers;
using Nostralogia3.Models.Utilities;
using Nostralogia3.Utilities;
using NostralogiaDAL.SMGeneralEntities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;

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
            strgen = new StringGenerator();
            string vector = strgen.GenericString;

            SMGeneralContext context = new SMGeneralContext();
            User user = new User();
            //SMRijndaelEncryption ecryptor = new SMRijndaelEncryption(salt, pass, vector);
            RijndaelEncryptor encryptor = new RijndaelEncryptor(salt, pass);
            try
            {
                user.UserName = UserName;
                user.Password = encryptor.Encrypt(Password);
                user.Email = encryptor.Encrypt(Email);
                user.PlaceId = City;
                user.CountryId = Country;
                user.FirstName = encryptor.Encrypt(StrWraper( FirstName));
                user.LastName = encryptor.Encrypt(StrWraper(LastName));
                user.MidleName = encryptor.Encrypt(StrWraper(MidleName));
                user.Sex = (byte?)Sex;
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

        public bool UserNameExists()
        {
            return _context.Users.Any(x => x.UserName == UserName);
        }
        public bool EmailExists()
        {
            return _context.Users.Any(x => x.Email == Email);
        }
    }
}
