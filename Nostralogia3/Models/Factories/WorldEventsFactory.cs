using Nostralogia3.Models.Utilities;
using NostralogiaDAL.NostradamusEntities;
using NostralogiaDAL.SMGeneralEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public class WorldEventsFactory
    {
        public static int GetUserRightData(int UserId, int EventId)
        {
            int Rights = 0;
            Worldevent we = null;
            User user = null;
            int? idContributor = 0;
            int UserLevel = UsersFactory.GetUserLevel(UserId);
            int DataType = 0;
            try
            {
                using (var context = new SMGeneralContext())
                {
                    if (context != null)
                        user = context.Users.FirstOrDefault(x => x.Id == UserId);
                }
                using (NostradamusContext context = new NostradamusContext())
                {
                    we = context.Worldevents.FirstOrDefault(x => x.Id == EventId);
                    idContributor = we.IdContributor;
                    DataType = we.EventsDataType;
                }
                Rights = CommonFunctionsFactory.GetRights(user.Id, we.IdContributor ?? 0, UserLevel, DataType);

            }
            catch (Exception e)
            {
                LogMaster lm = new LogMaster();
                lm.SetLog(e.Message);
            }
            return Rights;
        }
    }
}
