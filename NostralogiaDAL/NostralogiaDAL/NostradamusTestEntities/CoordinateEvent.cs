using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class CoordinateEvent
    {
        public int Id { get; set; }
        public int IdEvent { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double DiffTime { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }

        public virtual Worldevent IdEventNavigation { get; set; }
    }
}
