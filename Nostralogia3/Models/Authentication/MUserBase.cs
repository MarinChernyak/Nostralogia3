using NostralogiaDAL.SMGeneralEntities;
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
        public bool TryLogIn()
        {
            bool bIsOK = false;
            User user = _context.Users.FirstOrDefault(x => x.UserName == UserName);
            if(user!=null)
            {
                string pass = user.Password;
                PasswordUpdater pupdater = new PasswordUpdater(user.UserName, pass);
                if(pupdater.DecryptedPass == Password)
                {
                    bIsOK = true;
                }
            }

            return bIsOK;
        }
    }
}
