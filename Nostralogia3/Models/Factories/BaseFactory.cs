using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nostralogia3.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public class BaseFactory
    {

        public static void InsertSelectItem(List<SelectListItem> list)
        {
            if (list != null && list.Count == 0)
            {
                SelectListItem sli = new SelectListItem()
                {
                    Value = Constants.Values.ZeroStringComboValue,
                    Text = Constants.Values.ZeroStringComboText,
                    Selected = true
                };
                list.Insert(0, sli);
            }            
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
