using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nostralogia3.Models.Calendar
{
    public class YearNumber
    {
        protected int _yearNum;
        public int YearNum { get { return _yearNum; } }

        protected int _index_in_parent;
        public int IndexInParent
        {
            get { return _index_in_parent; }
        }

        public YearNumber(int year, int position)
        {
            _yearNum = year;
            _index_in_parent = position;
        }
    }
}