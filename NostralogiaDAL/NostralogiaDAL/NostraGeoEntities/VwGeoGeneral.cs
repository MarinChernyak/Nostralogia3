using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostraGeoEntities
{
    public partial class VwGeoGeneral
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CityName { get; set; }
        public short Country { get; set; }
        public int RegionState { get; set; }
        public short? TimeZone { get; set; }
        public string StateRegion { get; set; }
        public string Acronym { get; set; }
        public string CountryName { get; set; }
        public string Expr1 { get; set; }
        public string Abbreviation { get; set; }
        public string TzoneName { get; set; }
        public double TimeOffset { get; set; }
    }
}
