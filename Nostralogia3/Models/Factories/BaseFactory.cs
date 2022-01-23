using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public class BaseFactory
    {

        protected static void InsertSelectItem(List<SelectListItem> list)
        {
            if(list==null)
            {
                list = new List<SelectListItem>();
            }
            SelectListItem sli = new SelectListItem()
            {
                Value = Constants.ZeroStringComboValue,
                Text = Constants.ZeroStringComboText,
                Selected = true
            };
            list.Insert(0, sli);
        }

    }
}
