using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class KeyWord1
    {
        public KeyWord1()
        {
            EventHistorScales = new HashSet<EventHistorScale>();
            EventScales = new HashSet<EventScale>();
            EventsKwStorages = new HashSet<EventsKwStorage>();
        }

        public short Idkw { get; set; }
        public string AdvKeyWord { get; set; }
        public string Description { get; set; }
        public short ReferenceId { get; set; }
        public byte AccessLevel { get; set; }

        public virtual ICollection<EventHistorScale> EventHistorScales { get; set; }
        public virtual ICollection<EventScale> EventScales { get; set; }
        public virtual ICollection<EventsKwStorage> EventsKwStorages { get; set; }
    }
}
