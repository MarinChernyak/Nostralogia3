using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class EventPlaceType
    {
        public EventPlaceType()
        {
            Worldevents = new HashSet<Worldevent>();
        }

        public byte Id { get; set; }
        public string TableName { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<Worldevent> Worldevents { get; set; }
    }
}
