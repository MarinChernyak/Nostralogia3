using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls
{

    public class NostraTable : NostraTableBase
    {
        //public string TableWidth { get; set; }
        public string TableLabel { get; set; }
        public bool Expanded { get; set; }
        public string GetclassExpanded() { return Expanded ? "collapse.show" : "collapse"; }
        public string GetclassNotExpanded() { return Expanded ? "collapse" : "collapse.show"; }
        protected int UserId { get; set; }
        protected int UserLevel { get; set; }

        public NostraTable(string label, ISession session, bool collapsed=true)
        {
            _session = session;
            string suid = _session.GetString(Constants.SessionCoockies.SessionUID);
            UserId = 0;
            if(!string.IsNullOrEmpty(suid))
            {
                int userid = 0;
                if (int.TryParse(suid, out userid))
                {
                    UserId = userid;
                }               

            }
            if (UserId > 0)
            {
                string slevel = _session.GetString(Constants.SessionCoockies.SessionULevel);
                if (!string.IsNullOrEmpty(slevel))
                {
                    int ulevel = 1;
                    if (int.TryParse(slevel, out ulevel))
                    {
                        UserLevel = ulevel;
                    }
                    UserLevel = UserLevel == 0 ? 1 : UserLevel;

                }
            }

            TableLabel = label; 
            Expanded = !collapsed;
        }

        public string ExpandCollapsAreaId()
        {
            return $"ExpCollapse{index}";
        }
        public string ExpandCollapsMessageAreaId()
        {
            return $"ExpCollapseMsg{index}";
        }
        public string ExpanderId()
        {
            return $"Expander{index}";
        }

        
    }
}
