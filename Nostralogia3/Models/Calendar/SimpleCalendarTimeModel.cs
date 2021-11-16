using System;

namespace Sadalmelik3.Models.Calendar
{
    public class SimpleCalendarTimeModel : SimpleCalendarModel
    {
        protected TimeModel _tm;
        public TimeModel TM { get { return _tm; } }

        public SimpleCalendarTimeModel(int day, int month, int year, int Hour=0, int Min=0, int Sec=0 , String calID="calendar1" )
            :base( day, month, year, calID)
        {
            _tm = new TimeModel(Hour, Min, Sec, calID);
        }
        public override bool IsTimeIconVisible() { return true; }

    }
}