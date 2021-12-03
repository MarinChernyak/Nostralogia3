using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls
{
    public class SimpleCalendarModel
    {
        [DisplayName("Day")]
        public int Day { get; set; }
        [DisplayName("Month")]
        public int Month { get; set; }
        [DisplayName("Year")]
        [Range(0, 5000, ErrorMessage = "The year must be between 5000bc and 5000ce")]
        public int Year { get; set; }

        protected int _index;
        public List<SelectListItem> Days { get; protected set; }
        public List<SelectListItem> Monthes { get; protected set; }
        protected string[] _monthes = { "January", "February", "March", "April", "May", "June", "July","August","September","October","November","December" };

        public string MainLabel { get; protected set; }
        public SimpleCalendarModel(string label)
        {
            MainLabel = label;
            _index = Constants.Counter;
            FillUpdays();
            FillUpMonths();
            Year = DateTime.Now.Year;
        }
        public string GetIdMonthes()
        {
            return $"cmbMonthes{_index}";
        }
        public string GetIdDays()
        {
            return $"cmbDays{_index}";
        }
        public string GetIdYear()
        {
            return $"txtYear{_index}";
        }
        protected void FillUpdays()
        {
            int lastDayOfMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            Days = new List<SelectListItem>();
            for (int i = 1; i <= lastDayOfMonth; ++i)
            {
                Days.Add(new SelectListItem(i.ToString(), i.ToString()));
            }

        }
        protected void FillUpMonths()
        {
            Monthes = new List<SelectListItem>();
            for (int i = 1; i <= 12; ++i)
            {
                Monthes.Add(new SelectListItem(_monthes[i-1], i.ToString()));
            }
        }
    }
}
