using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class EventScaleVal
    {
        public int Id { get; set; }
        public int IdEvent { get; set; }
        public byte IdScale { get; set; }
        public byte Value { get; set; }

        public virtual Worldevent IdEventNavigation { get; set; }
        public virtual EventScale IdScaleNavigation { get; set; }
    }
}
