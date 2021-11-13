using Nostralogia3.Models.Factories;
using NostralogiaDAL.SMGeneralEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

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
        public bool TryLogIn()
        {
            bool bIsOK = false;
            User user = _context.Users.FirstOrDefault(x => x.UserName == UserName);
            if(user!=null)
            {
                string pass = user.Password;
            }

            return bIsOK;
        }
    }
}
