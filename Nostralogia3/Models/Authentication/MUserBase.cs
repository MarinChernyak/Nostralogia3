using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.Helpers;
using NostralogiaDAL.SMGeneralEntities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nostralogia3.Models.Authentication
{
    public class MUserBase : SMGeneralBaseModel
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name cannot be empty")]
        [MaxLength(50, ErrorMessage = "The length of a user  name must not exсeed 50 characters")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "The Password cannot be empty")]
        [MaxLength(50, ErrorMessage = "The length of a user  name must not exсeed 50 characters")]
        public string Password { get; set; }


    }
    public class LogInModel : MUserBase
    {
        [DisplayName("Remember me")]
        public bool ShouldRemember { get; set; }

        public LogInModel()
        {
            
        }
        public LogInModel(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                EncryptDataUpdater updater = new EncryptDataUpdater();
                bool brez = updater.CheckToken(token);
                if (brez)
                {
                    UserName = updater.UserName;
                }

            }
        }
        public LogInModel(HttpContext context)
        {
            string token = CoockiesHelper.GetCockie(context, Constants.CoockieToken);
            User user = _context.Users.FirstOrDefault(x => x.Token == token);
            if(user!=null)
            {
                UserName = user.UserName;
                EncryptDataUpdater datapdater = new EncryptDataUpdater();
                token = datapdater.SetToken(user.UserName);
                CoockiesHelper.SetCockie(context, Constants.CoockieToken,token);
            }
        }
        public bool TryLogIn(out string token)
        {
            token = "";
            bool bIsOK = false;
            User user = _context.Users.FirstOrDefault(x => x.UserName == UserName);
            if(user!=null)
            {
                EncryptDataUpdater datapdater = new EncryptDataUpdater();
                string decrpass = datapdater.DecryptStringVal(UserName, user.Password);
                if(decrpass == Password)
                {
                    UserName = user.UserName;
                    bIsOK = true;
                    datapdater.UpdateEncryptedData(UserName);
                    if (ShouldRemember)
                    {
                        token = datapdater.SetToken(UserName);
                    }
                }
            }

            return bIsOK;
        }
    }
}
