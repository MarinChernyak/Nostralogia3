using Nostralogia3.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Authentication
{
    public class PasswordUpdater : MUserBase
    { 
        public string EncryptrdPass {get;set;}
        public string DecryptedPass { get; protected set; }
        public PasswordUpdater(string username, string encryptedpass)
        {
            EncryptrdPass = encryptedpass;
            Decrypt(username, encryptedpass);
        }
        protected void Decrypt(string username, string encryptedpass)
        {
                var secprot = _context.SecurityProtocols.Where(x => x.UserName == username).OrderByDescending(x => x.Id).First();
                if(secprot!=null)
                {
                    string salt = secprot.Salt;
                    string passcode = secprot.Passcode;
                    string  initvector = secprot.Initvector;
                    SMRijndaelEncryption encryptor = new SMRijndaelEncryption(salt, passcode, initvector);
                    DecryptedPass = encryptor.Decrypt(encryptedpass);
                }
            

        }
    }
}
