using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using Nostralogia3.Models.Calendar;
using System;
using System.Collections.Generic;
using System.IO;

namespace Nostralogia3.Controllers
{
    public class CalendarController : Controller
    {
        CalendarModel _model;

        public PartialViewResult CalendarMain(int index)
        {
            _model = new CalendarModel(index);
            ViewBag.cmbMothes = new SelectList(_model.Months, "Value", "Description", _model.Month);
            return PartialView(_model);
        }
        //[HttpPost]
        //public JsonResult DayMonthChangedValue()
        //{
        //    string json;
        //    using (StreamReader reader = new StreamReader(Request.InputStream))
        //    {
        //        json = reader.ReadToEnd();
        //    }
        //    JObject jObject = JObject.Parse(json);
        //    return Json("");
        //}
        protected List<int> GetYearArr(JObject jObject)
        {
            List<int> arr = new List<int>();
            arr.Add(Convert.ToInt16(jObject["y1"].ToString()));
            arr.Add(Convert.ToInt16(jObject["y2"].ToString()));
            arr.Add(Convert.ToInt16(jObject["y3"].ToString()));
            arr.Add(Convert.ToInt16(jObject["y4"].ToString()));
            if (arr[0] == 0 && arr[1] == 0 && arr[2] == 0 && arr[3] == 0)
            {
                arr[3] = 1;
            }
            return arr;
        }
        [HttpPost]
 
        protected int UpdateYearMonth(List<int> arr, int imonth)
        {
            int iyear = iyear = arr[0] * 1000 + arr[1] * 100 + arr[2] * 10 + arr[3];

            if (imonth == 13)
            {
                imonth = 1;
                iyear++;
            }
            else if (imonth == 0)
            {
                imonth = 12;
                iyear--;

            }
            iyear = CheckYearLimits(iyear);
            UpdateArrayYear(arr, iyear);
            return imonth;
        }
        protected void UpdateArrayYear(List<int> arr, int iyear)
        {
            arr[0] = (int)(iyear / 1000);
            arr[1] = (int)((iyear - arr[0]*1000) / 100);
            arr[2] = (int)((iyear - arr[0] * 1000 - arr[1] * 100) / 10);
            arr[3] = (int)(iyear - arr[0] * 1000 - arr[1] * 100 - arr[2] * 10);
        }
        protected int CheckYearLimits(int iyear)
        {
            if (iyear < DateTime.MinValue.Year)
                iyear = DateTime.MinValue.Year;
            else if (iyear >DateTime.MaxValue.Year)
                iyear = DateTime.MaxValue.Year;

            return iyear;
        }

     }
}
