using System;

namespace Nostralogia3.Models.Calendar
{

    public class CalendarModel : CalendarBaseModel
    {
        protected TimeModel _tm;
        public TimeModel TM { get { return _tm; } }

        public CalendarModel(int index = 1)
            : base(index)
        {
            _tm = new TimeModel(_calendarID, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        }
        public CalendarModel(int day, int month, int year, int hour, int min, int sec, int index = 1)
            : base(day, month, year, index)
        {

            _tm = new TimeModel(_calendarID, hour, min, sec);
        }
        public CalendarModel(CalendarModel calendar, int index = 1)
        {
            _calIndex = index;
            _calendarID = String.Format("Calendar_{0}", index); ;
            if (calendar != null)
            {
                InitYear(calendar.Year);
                _month = calendar.Month;
                String id = String.Format("timemodel_{0}", index);
                if (calendar._tm != null)
                {
                    _tm = new TimeModel(calendar._tm.ToString(), id);
                }
                else
                {
                    _tm = new TimeModel(String.Format("timemodel_{0}", index));
                }
            }
            else
            {
                DateTime dt = DateTime.Now;
                InitYear(dt.Year);
                _month = dt.Month;
            }

        }
    }

}