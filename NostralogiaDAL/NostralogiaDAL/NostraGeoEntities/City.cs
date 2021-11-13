using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostraGeoEntities
{
    public partial class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public short Country { get; set; }
        public int RegionState { get; set; }
        public short TimeZone { get; set; }

        public virtual Country CountryNavigation { get; set; }
        public virtual StateRegion RegionStateNavigation { get; set; }
        public virtual TimeZoneList TimeZoneNavigation { get; set; }
    }
}
