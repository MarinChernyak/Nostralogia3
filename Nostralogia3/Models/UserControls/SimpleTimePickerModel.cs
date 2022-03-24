using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls
{
    public class SimpleTimePickerModel
    {
        [DisplayName("Hours")]
        public int Hour { get; set; }
        [DisplayName("Minutes")]
        public int Minute { get; set; }
        public bool ReadOnly { get; protected set; }
        public List<SelectListItem> Hours { get; protected set; }
        public List<SelectListItem> Minutes { get; protected set; }
        protected int _index;
        public string MainLabel { get; set; }
        public SimpleTimePickerModel()
        {
            ReadOnly = false;
            _index = Constants.Values.Counter;
            FillHours();
            FillMinutes();
        }
        public SimpleTimePickerModel(string label, int H, int Min, bool readOnly)
        {
            ReadOnly = readOnly;
            MainLabel = label;
            _index = Constants.Values.Counter;
            Hour = H;
            Minute = Min;
            FillHours();
            FillMinutes();
        }
        protected void FillHours()
        {
            Hours = new List<SelectListItem>();
            for (int i=0; i<24; ++i)
            {
                string sH = i < 10 ? $"0{i}" : i.ToString();
                SelectListItem sli = new SelectListItem(sH, i.ToString());
                if(i==Hour)
                {
                    sli.Selected = true;
                }
                Hours.Add(sli);
            }
        }
        protected void FillMinutes()
        {
            Minutes = new List<SelectListItem>();
            for (int i = 0; i < 60; ++i)
            {
                string sM = i < 10 ? $"0{i}" : i.ToString();
                SelectListItem sli = new SelectListItem(sM, i.ToString());
                if (i == Minute)
                {
                    sli.Selected = true;
                }
                Minutes.Add(sli);
            }
        }
        public string GetIdHours()
        {
            return $"cmbHours{_index}";
        }
        public string GetIdMinutes()
        {
            return $"cmbMinutes{_index}";
        }
    }
}
