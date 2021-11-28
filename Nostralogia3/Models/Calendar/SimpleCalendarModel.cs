using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Nostralogia3.Models.Calendar
{

    public class SimpleCalendarModel :CalendarBaseModel
    {

        public SimpleCalendarModel()
            :base()
        {
            InitDays();
        }
        public SimpleCalendarModel(int day, int month, int year)
            :base(day,month,year)
        {
            InitDays();
        }
        protected List<SelectListItem> _lst_days;
        public List<SelectListItem> Days
        {
            get
            {
                if (_lst_months == null)
                    InitDays();
                return _lst_days;
            }
        }
        protected void InitDays()
        {
            _lst_days = new List<SelectListItem>();
            if (Month >0 && Year >0)
            {
                int iLastday =0;
                if(Month==1 || Month ==3 || Month==5 || Month == 7 || Month ==8 || Month ==10 || Month == 12)
                {
                    iLastday = 31;
                }
                else if(Month!=2)
                {
                    iLastday = 30;
                }
                else{
                    DateTime dt = new DateTime(Year, 2, 28);
                    dt = dt.AddDays(1);
                    if (dt.Month == Month)
                        iLastday = 29;
                    else
                        iLastday = 28;
                }
                for (int i = 1;  i <= iLastday; ++i)
                {
                    _lst_days.Add(new SelectListItem()
                    {
                        Text = i.ToString(),
                        Value = i.ToString()

                    });
                }
            }
        }
    }
    
}