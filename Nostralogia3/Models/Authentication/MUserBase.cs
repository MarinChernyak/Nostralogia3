using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Helpers;
using Nostralogia3.Models.Utilities;
using Nostralogia3.Utilities;
using NostralogiaDAL.SMGeneralEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nostralogia3.Models.Authentication
{
    public class MUserBase : SMGeneralBaseModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name cannot be empty")]
        [MaxLength(50, ErrorMessage = "The length of a user  name must not exсeed 50 characters")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "The Password cannot be empty")]
        [MaxLength(50, ErrorMessage = "The length of a user  name must not exсeed 50 characters")]
        public string Password { get; set; }

        public int UserLevel { get; protected set; }
        public int UserId { get; protected set; }
        public MUserBase()
        {
            IsActive = true;
        }

        protected void GetSaltPasscode(out string salt, out string passcode)
        {
            salt = string.Empty;
            passcode = string.Empty;

            StringGenerator strgen = new StringGenerator(Constants.Values.SaltLength);
            salt = strgen.GenericString;
            strgen = new StringGenerator(Constants.Values.PassCodeLength);
            strgen.Generate();
            passcode = strgen.GenericString;
        }

    }
    public class LogInModel : MUserBase
    {
        [DisplayName("Remember me")]
        public bool ShouldRemember { get; set; }
        public string ErrorMessage { get; set; }
        
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
                    UserId = updater.UserId;
                    UserLevel = updater.UserLevel;
                    UserName = updater.UserName;
                }
            }
        }
        public LogInModel(HttpContext context)
        {
            string token = CoockiesHelper.GetCockie(context, Constants.SessionCoockies.CoockieToken);
            using (SMGeneralContext _context = new SMGeneralContext())
            {
                User user = _context.Users.FirstOrDefault(x => x.Token == token);
                if (user != null)
                {
                    UserName = user.UserName;
                    EncryptDataUpdater datapdater = new EncryptDataUpdater();
                    token = datapdater.SetToken(user.Id);
                    CoockiesHelper.SetCockie(context, Constants.SessionCoockies.CoockieToken, token);
                }
            }
        }
        public bool TryLogIn(out string token)
        {
            token = "";
            bool bIsOK = false;
            using (SMGeneralContext _context = new SMGeneralContext())
            {
                User user = _context.Users.FirstOrDefault(x => x.UserName == UserName);
                UserId = user.Id;
                if (user != null)
                {
                    EncryptDataUpdater datapdater = new EncryptDataUpdater();
                    string decrpass = datapdater.DecryptStringVal(UserId, user.Password);
                    if (decrpass == Password)
                    {
                        UserLevel = UsersFactory.GetUserLevel(UserId);
                        UserName = user.UserName;
                        bIsOK = true;
                        datapdater.UpdateEncryptedData(UserId);
                        if (ShouldRemember)
                        {
                            token = datapdater.SetToken(UserId);
                        }
                    }
                }
            }

            return bIsOK;
        }
    }
}
