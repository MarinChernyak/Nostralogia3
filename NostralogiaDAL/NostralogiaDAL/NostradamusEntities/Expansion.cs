using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Expansion
    {
        public int Id { get; set; }
        public short? Idcountry { get; set; }
        public int IdEvent { get; set; }
        public int? Idregion { get; set; }

        public virtual Worldevent IdEventNavigation { get; set; }
    }
}
