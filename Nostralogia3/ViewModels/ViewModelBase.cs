using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models;
using Nostralogia3.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels
{
    public class ViewModelBase : BaseModel
    {
        public string ErrorMessage { get; protected set; }
        public ViewModelBase()
        {

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
            if (_session != null)
            {
                string slevel = _session.GetString(Constants.SessionCoockies.SessionULevel);
                if (!string.IsNullOrEmpty(slevel))
                {
                    level = Convert.ToInt32(slevel);
                }
            }
            return level;
        }
        public int GetUserLevel(ISession session)
        {
            _session = session;
            return GetUserLevel();
        }        
        public void SetUserLevel(int level)
        {
            _session.SetString(Constants.SessionCoockies.SessionULevel, level.ToString());
        }
        protected List<SelectListItem> FromLstObjectsToDropDownFeed<T>(List<T> lstObj, string TxtProperty, string ValProperty)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem()
            {
                Text = Constants.Values.ZeroStringComboText,
                Value = Constants.Values.ZeroStringComboValue,
                Selected = true
            });
            try
            {
                if (lstObj != null)
                {
                    foreach (T obj in lstObj)
                    {
                        var protxt = typeof(T).GetProperty(TxtProperty).GetValue(obj, null);
                        var proval = typeof(T).GetProperty(ValProperty).GetValue(obj, null);
                        if (protxt != null && proval != null)
                        {
                            lst.Add(new SelectListItem()
                            {
                                Text = protxt.ToString(),
                                Value = proval.ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMaster lm = new LogMaster();
                lm.SetLogException(GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);

            }
            return lst;
        }
    }        
}
