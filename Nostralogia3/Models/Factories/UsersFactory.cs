using Nostralogia3.Models.Authentication;
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
            var context = new SMGeneralContext();
            if (context != null)
                users = context.Users.ToList();

            return ModelsTransformer.TransferModelList<User, MUserBase>(users);
        }

    }
}
