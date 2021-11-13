using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostraGeoEntities
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public short Id { get; set; }
        public string CountryName { get; set; }
        public string Acronym { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
