using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostraGeoEntities
{
    public partial class TimeZoneList
    {
        public TimeZoneList()
        {
            Cities = new HashSet<City>();
        }

        public short Idtzone { get; set; }
        public string Abbreviation { get; set; }
        public string TzoneName { get; set; }
        public string Location { get; set; }
        public double TimeOffset { get; set; }
        public string LocationWorldWide { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
