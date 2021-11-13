using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostraGeoEntities
{
    public partial class StateRegion
    {
        public StateRegion()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string StateRegion1 { get; set; }
        public string Acronym { get; set; }
        public short? CountryRef { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
