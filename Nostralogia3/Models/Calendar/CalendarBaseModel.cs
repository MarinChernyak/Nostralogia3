using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Nostralogia3.Models.Calendar
{
    public class CalendarBaseModel
    {
        protected string _calendarID;
        public String CalID { get { return _calendarID; } }

        protected int _calIndex;
        public int CalIndex { get { return _calIndex; } }


        protected String _dpid;
        protected int _dpIndex;
        protected int _day;
        public int Day { get { return _day; } }

        protected int _month;
        public int Month { get { return _month; } }

        protected int _year;
        public int Year { get { return _year; } }


        private List<YearNumber> _year_lst;
        public List<YearNumber> ListYear
        {
            get
            {
                if (_year_lst == null)
                    InitYear();
                return _year_lst;
            }

        }
        public CalendarBaseModel(int index = 1)
        {
            InitZerovariant(index);
        }
        public CalendarBaseModel(int day, int month, int year, int index = 1)
        {
            InitFullVariant(day, month, year, index);
        }
        protected void InitZerovariant(int index)
        {
            _calendarID = String.Format("Calendar_{0}", index);
            _calIndex = index;
            _day = DateTime.Now.Day; ;
            _month = DateTime.Now.Month;
            InitYear(DateTime.Now.Year);
        }
        protected void InitFullVariant(int day, int month, int year, int index = 1)
        {
            _calIndex = index;
            _calendarID = String.Format("Calendar_{0}", index);
            _day = day;
            _month = month;
            InitYear(year);
        }
        protected void InitYear(int Year = 0)
        {
            _year_lst = new List<YearNumber>();
            _year = Year;
            if (Year == 0)
                _year = DateTime.Now.Year;
            int iy1 = _year / 1000;
            int iy2 = (_year - iy1 * 1000) / 100;
            int iy3 = (_year - iy1 * 1000 - iy2 * 100) / 10;
            int iy4 = _year - iy1 * 1000 - iy2 * 100 - iy3 * 10;
            _year_lst.Add(new YearNumber(iy1, 0));
            _year_lst.Add(new YearNumber(iy2, 1));
            _year_lst.Add(new YearNumber(iy3, 2));
            _year_lst.Add(new YearNumber(iy4, 3));
        }

        public YearNumber getYearNum(int index)
        {
            YearNumber iret = null;
            if (index >= 0 && index < 4)
                iret = ListYear[index];

            return iret;
        }
        protected List<SelectListItem> _lst_months;
        public List<SelectListItem> Months
        {
            get
            {
                if (_lst_months == null)
                    InitMonths();
                return _lst_months;
            }
        }
        protected void InitMonths()
        {
            _lst_months = new List<SelectListItem>();

            _lst_months.Add(new SelectListItem() { Value = "1", Text = "January" });
            _lst_months.Add(new SelectListItem() { Value = "2", Text = "February" });
            _lst_months.Add(new SelectListItem() { Value = "3", Text = "March" });
            _lst_months.Add(new SelectListItem() { Value = "4", Text = "April" });
            _lst_months.Add(new SelectListItem() { Value = "5", Text = "May" });
            _lst_months.Add(new SelectListItem() { Value = "6", Text = "June" });
            _lst_months.Add(new SelectListItem() { Value = "7", Text = "July" });
            _lst_months.Add(new SelectListItem() { Value = "8", Text = "August" });
            _lst_months.Add(new SelectListItem() { Value = "9", Text = "September" });
            _lst_months.Add(new SelectListItem() { Value = "10", Text = "October" });
            _lst_months.Add(new SelectListItem() { Value = "11", Text = "November" });
            _lst_months.Add(new SelectListItem() { Value = "12", Text = "December" });
        }

    }
}