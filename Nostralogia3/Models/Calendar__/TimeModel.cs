using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nostralogia3.Models.Calendar
{
    public class TimeModel 
    {
        private String _id;
        private const int iH10 = 0;
        private const int iH1 = 1;
        private const int iM10 = 2;
        private const int iM1 = 3;
        private const int iS10 = 4;
        private const int iS1 = 5;
        private List<int> _Time;

        //public String ID_time_closeicon { get { return String.Format("ID_time_close_icon_{0}", id); } }

        public int Hour
        {
            get
            {
                return _Time[iH10] * 10 + _Time[iH1];
            }
        }
        public int Minutes
        {
            get
            {
                return _Time[iM10] * 10 + _Time[iM1];
            }
        }
        public int Seconds
        {
            get
            {
                return _Time[iS10] * 10 + _Time[iS1];
            }
        }
        public TimeSpan GetTimeSpan()
        {
            return new TimeSpan(Hour, Minutes, Seconds);
        }
        public String ID
        {
            get
            {
                return _id;
            }
        }
        public override string ToString()
        {
            return String.Format("{0}:{1}:{2}", GetStringOfVal(Hour), GetStringOfVal(Minutes), GetStringOfVal(Seconds));
        }
        public String GetStringOfVal(int val)
        {
            String sval = "";
            sval = val < 10 ? String.Format("0{0}", val) : val.ToString();
            return sval;
        }

        public TimeModel(string id)
        {
            _id = id;
            //id = CreateID(sid);
            Init0();
        }
        public TimeModel(string id, int iH, int iM, int iS)
        {
            _id = id;

            if (iH < 0 || iM < 0 || iS < 0 || iH > 23 || iM > 59 || iS > 59)
                Init0();
            else
            {
                _Time = new List<int>();
                AddTimeList(iH);
                AddTimeList(iM);
                AddTimeList(iS);
            }
        }

        public TimeModel(List<int> time, string id)
        {
           _id = id;



            if (time == null || time.Count != 6)
                Init0();
            else
            {
                _Time = new List<int>();
                _Time.Add(time[0]);//hours
                _Time.Add(time[1]);

                _Time.Add(time[2]);//min
                _Time.Add(time[3]);

                _Time.Add(time[4]);//sec
                _Time.Add(time[5]);
            }
        }
        public TimeModel(TimeModel tm, string id)
        {
            _id = id;
            if (tm != null)
                InitTimeList(tm.ToString());
            else
                Init0();
        }
        public TimeModel(String time, string id)
        {
            _id = id;
            if (String.IsNullOrEmpty(time))
            {
                Init0();
            }
            else
            {
                char[] sep = { ':' };
                string[] timearr = time.Split(sep);
                if (timearr == null || timearr.Length != 3)
                    Init0();
                else
                {
                    InitTimeList(time);
                }
            }
        }

        protected void AddTimeList(int iNum)
        {
            if (iNum < 10)
            {
                _Time.Add(0);
                _Time.Add(iNum);
            }
            else
            {
                int ival10 = iNum / 10;
                _Time.Add(ival10);
                _Time.Add(iNum - ival10 * 10);
            }

        }
        protected void InitTimeList(String time)
        {
            char[] sep = { ':' };
            string[] timearr = time.Split(sep);
            _Time = new List<int>();


            if (timearr[0].Length == 1)
            {
                _Time.Add(0);
                _Time.Add(getNUmber(timearr[0], 0));
            }
            else
            {
                _Time.Add(getNUmber(timearr[0], 0));
                _Time.Add(getNUmber(timearr[0], 1));
            }



            if (timearr[1].Length == 1)
            {
                _Time.Add(0);
                _Time.Add(getNUmber(timearr[1], 0));
            }
            else
            {
                _Time.Add(getNUmber(timearr[1], 0));
                _Time.Add(getNUmber(timearr[1], 1));
            }



            if (timearr[2].Length == 1)
            {
                _Time.Add(0);
                _Time.Add(getNUmber(timearr[2], 0));
            }
            else
            {
                _Time.Add(getNUmber(timearr[2], 0));
                _Time.Add(getNUmber(timearr[2], 1));
            }

        }
        public String GetTimeNumber(int ipos)
        {
            String s = "0";
            if (ipos >= 0 && ipos < _Time.Count)
                s = _Time[ipos].ToString();
            return s;
        }
        private int getNUmber(string timestr, int index)
        {
            string s = "0";
            if (index < timestr.Length)
                s = timestr.Substring(index, 1);
            else
                s = timestr;

            int result = 0;
            bool isSucess = Int32.TryParse(s, out result);
            
            return result;
        }
        private void Init0()
        {
            _Time = new List<int>();
            _Time.Add(0);//hours
            _Time.Add(0);

            _Time.Add(0);//min
            _Time.Add(0);

            _Time.Add(0);//sec
            _Time.Add(0);
        }
        private void InitCurrent()
        {
            _Time = new List<int>();
            int iVal = DateTime.Now.Hour;
            _Time.Add(iVal<10?0:iVal/10);//hours
            _Time.Add(iVal < 10 ? iVal : iVal - (iVal / 10)*10);
            iVal = DateTime.Now.Minute;
            _Time.Add(iVal < 10 ? 0 : iVal / 10);//min
            _Time.Add(iVal < 10 ? iVal : iVal - (iVal / 10) * 10);
            iVal = DateTime.Now.Second;
            _Time.Add(iVal < 10 ? 0 : iVal / 10);//sec
            _Time.Add(iVal < 10 ? iVal : iVal - (iVal / 10) * 10);
        }
     }
}