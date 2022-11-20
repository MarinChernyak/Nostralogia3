using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Eventslist
    {
        public Eventslist()
        {
            Peopleevents = new HashSet<Peopleevent>();
        }

        public short Idevent { get; set; }
        public byte? CategoryId { get; set; }
        public string AdvEvent { get; set; }
        public string Description { get; set; }

        public virtual EventsCategory Category { get; set; }
        public virtual ICollection<Peopleevent> Peopleevents { get; set; }
    }
}
