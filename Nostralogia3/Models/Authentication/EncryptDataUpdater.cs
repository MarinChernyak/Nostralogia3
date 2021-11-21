using Nostralogia3.Models.Utilities;
using Nostralogia3.Utilities;
using NostralogiaDAL.SMGeneralEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Authentication
{
    public class EncryptDataUpdater : MUserBase
    { 
        public EncryptDataUpdater()
        {

        }
        public bool CheckToken(string token)
        {
            bool bRez = false;
            string newtoken = string.Empty;
            User user = _context.Users.FirstOrDefault(x => x.Token == token);
            if (user!=null)
            {                
                UserName = user.UserName;
                UserLevel = GetUserLevel(user.UserName);
                bRez = true;
            }

            return bRez;
        }
        public string SetToken(string username)
        {           
            string token  = Guid.NewGuid().ToString();
            User user = _context.Users.Where(x => x.UserName == username).First();
            if(user!=null)
            {
                user.Token = token;
                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return token;
        }
        public string DecryptStringVal(string username, string encryptedstr)
        {
            string decryptstr = string.Empty;
            try
            {
                var secprot = _context.SecurityProtocols.Where(x => x.UserName == username).OrderByDescending(x => x.Id).First();
                if (secprot != null)
                {
                    string salt = secprot.Salt;
                    string passcode = secprot.Passcode;

                    RijndaelEncryptor encryptor = new RijndaelEncryptor(salt, passcode);
                    decryptstr = encryptor.Decrypt(encryptedstr);
                }
            }
            catch
            {

            }
            return decryptstr;
        }
        public void UpdateEncryptedData(string username)
        {
            int SaltLength = 10;
            int PascodeLength = 12;
            var secprot = _context.SecurityProtocols.Where(x => x.UserName == username).OrderByDescending(x => x.Id).First();
            if (secprot != null)
            {
                User user = _context.Users.Where(x => x.UserName == username).First();
                string salt = secprot.Salt;
                string passcode = secprot.Passcode;

                RijndaelEncryptor encryptor = new RijndaelEncryptor(salt, passcode);
                string password = encryptor.Decrypt(user.Password);
                string FName = encryptor.Decrypt(user.FirstName);
                string email = encryptor.Decrypt(user.Email);
                string LName = encryptor.Decrypt(user.LastName);
                string MName = encryptor.Decrypt(user.MidleName);

                StringGenerator strgen = new StringGenerator(SaltLength);
                salt = strgen.GenericString;
                strgen = new StringGenerator(PascodeLength);
                strgen.Generate();
                passcode = strgen.GenericString;


                encryptor = new RijndaelEncryptor(salt, passcode);
                user.FirstName = encryptor.Encrypt(FName);
                user.MidleName = encryptor.Encrypt(MName);
                user.LastName = encryptor.Encrypt(LName);
                user.Email = encryptor.Encrypt(email);
                user.Password = encryptor.Encrypt(password);
                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                secprot.Passcode = passcode;
                secprot.Salt = salt;

                _context.Entry(secprot).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

            }

        }
    }
}
