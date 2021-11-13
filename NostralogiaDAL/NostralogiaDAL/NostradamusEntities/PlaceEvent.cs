using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class PlaceEvent
    {
        public int Id { get; set; }
        public int IdPlace { get; set; }
        public int IdEvent { get; set; }

        public virtual Worldevent IdEventNavigation { get; set; }
    }
}
