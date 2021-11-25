using Microsoft.AspNetCore.Http;
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
        public MUserBase()
        {
            IsActive = true;
        }
        protected int GetUserLevel(string username)
        {
            int level = 0;
            using (SMGeneralContext _context = new SMGeneralContext())
            {
                User user = _context.Users.FirstOrDefault(x => x.UserName == UserName);
                var vlevel = _context.UserAppRoles.Join(_context.Roles, uappr => uappr.RoleId, r => r.RoleId,
                    (uappr, r) => new { Uapr = uappr, R = r }).Where(z => z.R.AppId == Constants.ApplicationId && z.Uapr.UserId == user.Id).FirstOrDefault();
                if (vlevel != null)
                {
                    level = vlevel.R.AccessLevel;
                }
            }
            return level;
        }
        protected void GetSaltPasscode(out string salt, out string passcode)
        {
            salt = string.Empty;
            passcode = string.Empty;

            StringGenerator strgen = new StringGenerator(Constants.SaltLength);
            salt = strgen.GenericString;
            strgen = new StringGenerator(Constants.PassCodeLength);
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
                    UserName = updater.UserName;
                    UserLevel = updater.UserLevel;
                }

            }
        }
        public LogInModel(HttpContext context)
        {
            string token = CoockiesHelper.GetCockie(context, Constants.CoockieToken);
            using (SMGeneralContext _context = new SMGeneralContext())
            {
                User user = _context.Users.FirstOrDefault(x => x.Token == token);
                if (user != null)
                {
                    UserName = user.UserName;
                    EncryptDataUpdater datapdater = new EncryptDataUpdater();
                    token = datapdater.SetToken(user.UserName);
                    CoockiesHelper.SetCockie(context, Constants.CoockieToken, token);
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

                if (user != null)
                {
                    EncryptDataUpdater datapdater = new EncryptDataUpdater();
                    string decrpass = datapdater.DecryptStringVal(UserName, user.Password);
                    if (decrpass == Password)
                    {
                        UserLevel = GetUserLevel(user.UserName);
                        UserName = user.UserName;
                        bIsOK = true;
                        datapdater.UpdateEncryptedData(UserName);
                        if (ShouldRemember)
                        {
                            token = datapdater.SetToken(UserName);
                        }
                    }
                }
            }

            return bIsOK;
        }
    }
}
