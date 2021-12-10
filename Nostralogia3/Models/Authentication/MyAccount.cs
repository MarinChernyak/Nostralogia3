using Nostralogia3.Models.Geo;
using NostralogiaDAL.SMGeneralEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Authentication
{
    public class MyAccount : MUser
    {
        [DisplayName("My points")]   
        public int NumPoints { get; set; }

        [DisplayName("My Role")]
        public string Role { get; set; }
         public int RoleId { get; set; }

        public EventPlaceModel EventPlaceModel { get; protected set; }
        public MyAccount()
        {

        }
        public MyAccount(string username)
        {
            UserName = username;
            InitData();
        }
        protected void InitData()
        {
            EncryptDataUpdater updater = new EncryptDataUpdater();
            MUser muser = updater.GetDecryptedUser(UserName);
            FirstName = muser.FirstName;
            MidleName = muser.MidleName;
            Password = muser.Password;
            LastName = muser.LastName;
            Email = muser.Email;
            Id = muser.Id;
            IsActive = muser.IsActive;
            Sex = muser.Sex;
            Dob = muser.Dob;
            ActivationDate = muser.ActivationDate;
            EventPlaceModel = new EventPlaceModel(muser.CountryId, muser.StateId, muser.PlaceId, "Where you are?");
            using (SMGeneralContext context = new SMGeneralContext())
            {
                var uar = context.UserAppRoles.Join(context.Roles, uappr => uappr.RoleId, r => r.RoleId,
                (uappr, r) => new { Uapr = uappr, R = r }).Where(z => z.R.AppId == Constants.ApplicationId && z.Uapr.UserId == Id).FirstOrDefault();
                if (uar != null)
                {
                    RoleId = uar.R.RoleId;
                    Role = uar.R.RoleName;
                }
            }
        }    
        public bool SaveData()
        {
            bool bRez = false;
            EncryptDataUpdater updater = new EncryptDataUpdater();
            MUser muser = updater.GetDecryptedUser(UserName);
            muser.FirstName= FirstName;
            muser.MidleName = MidleName;
            muser.LastName= LastName;
            muser.Email= Email;
            muser.Password = Password;
            muser.Id = Id;
            muser.IsActive= IsActive;
            muser.Sex= Sex;
            muser.Dob= Dob;
            muser.ActivationDate= ActivationDate;
            muser.CountryId = CountryId;
            muser.StateId = StateId;
            muser.PlaceId = PlaceId;
            bRez = updater.SetEncryptedUser(muser);

            return bRez;
        }

    }
}
