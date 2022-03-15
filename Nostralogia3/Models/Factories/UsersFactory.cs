using Nostralogia3.Models.Authentication;
using Nostralogia3.Models.Utilities;
using NostralogiaDAL.NostradamusEntities;
using NostralogiaDAL.SMGeneralEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public class UsersFactory
    {
        public static List<MUserBase> GetUsersCollection()
        {
            List<User> users = null;
            using (var context = new SMGeneralContext())
            {
                if (context != null)
                    users = context.Users.ToList();
            }

            return ModelsTransformer.TransferModelList<User, MUserBase>(users);
        }
        public static bool CanUserViewData(int UserId, int PersonalDataId )
        {
            bool bRez = false;
            User user = null;
            Person person = null;
            int? idContributor = 0;
            int UserLevel = GetUserLevel(UserId);
            int DataType = 0;
            try
            {
                using (var context = new SMGeneralContext())
                {
                    if (context != null)
                        user = context.Users.FirstOrDefault(x=>x.Id== UserId);
                }
                using (NostradamusContext context = new NostradamusContext())
                {
                    person = context.People.FirstOrDefault(x => x.Id == PersonalDataId);
                    idContributor = person.IdContributor;
                    DataType = person.DataType;
                }
                if(UserLevel>=DataType|| UserId == idContributor)
                {
                    bRez = true;
                }

            }
            catch (Exception e)
            {
                LogMaster lm = new LogMaster();
                lm.SetLog(e.Message);
            }
            return bRez;
        }
        public static int GetUserLevel(int UserId)
        {
            int level = 0;
            using (SMGeneralContext _context = new SMGeneralContext())
            {
                User user = _context.Users.FirstOrDefault(x => x.Id == UserId);
                var vlevel = _context.UserAppRoles.Join(_context.Roles, uappr => uappr.RoleId, r => r.RoleId,
                    (uappr, r) => new { Uapr = uappr, R = r }).Where(z => z.R.AppId == Constants.Values.ApplicationId && z.Uapr.UserId == user.Id).FirstOrDefault();
                if (vlevel != null)
                {
                    level = vlevel.R.AccessLevel;
                }
            }
            return level;
        }
    }
}
