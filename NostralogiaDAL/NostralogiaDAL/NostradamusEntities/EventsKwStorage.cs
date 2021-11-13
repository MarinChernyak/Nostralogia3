using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class EventsKwStorage
    {
        public int Id { get; set; }
        public short IdEventKeyword { get; set; }
        public int EventId { get; set; }

        public virtual Worldevent Event { get; set; }
        public virtual KeyWord1 IdEventKeywordNavigation { get; set; }
    }
}
