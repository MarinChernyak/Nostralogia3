using Microsoft.AspNetCore.Http;
using Nostralogia3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels
{
    public class ViewModelBase : BaseModel
    {
        public string ErrorMessage { get; protected set; }
        protected ISession _session { get; set; }
        public void SetSession (ISession session)
        {
            _session = session;
        }
        public int GetUID()
        {
            int uid = 0;
            string suid = _session.GetString(Constants.SessionCoockies.SessionUID);
            if (!string.IsNullOrEmpty(suid))
            {
                uid = Convert.ToInt32(suid);
            }
            return uid;

        }
        public void SetUserId(int UID)
        {
            _session.SetString(Constants.SessionCoockies.SessionULevel, UID.ToString());
        }
        public int GetUserLevel()
        {
            int level = 0;
            string slevel = _session.GetString(Constants.SessionCoockies.SessionULevel);
            if(!string.IsNullOrEmpty(slevel))
            {
                level = Convert.ToInt32(slevel);
            }
            return level;
        }
        public void SetUserLevel(int level)
        {
            _session.SetString(Constants.SessionCoockies.SessionULevel, level.ToString());
        }
    }
}
