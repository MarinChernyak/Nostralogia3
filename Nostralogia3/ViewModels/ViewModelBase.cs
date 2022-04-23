using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels
{
    public class ViewModelBase
    {
        protected ISession _session { get; set; }
        public int UserId { get; set; }
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
