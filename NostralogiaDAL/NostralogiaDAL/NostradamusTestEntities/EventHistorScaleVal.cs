using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class EventHistorScaleVal
    {
        public int Id { get; set; }
        public int IdEvent { get; set; }
        public short IdHistScale { get; set; }
        public byte Value { get; set; }

        public virtual Worldevent IdEventNavigation { get; set; }
        public virtual EventHistorScale IdHistScaleNavigation { get; set; }
    }
}
