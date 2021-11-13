using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class EventsCategory
    {
        public EventsCategory()
        {
            Eventslists = new HashSet<Eventslist>();
        }

        public byte Idcat { get; set; }
        public string AdvCategory { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Eventslist> Eventslists { get; set; }
    }
}
