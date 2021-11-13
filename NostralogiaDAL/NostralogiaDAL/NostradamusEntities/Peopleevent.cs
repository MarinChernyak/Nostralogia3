using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Peopleevent
    {
        public int Id { get; set; }
        public int Idperson { get; set; }
        public short Event { get; set; }
        public byte DayFrom { get; set; }
        public byte MonthFrom { get; set; }
        public short YearFrom { get; set; }
        public byte DayTo { get; set; }
        public byte MonthTo { get; set; }
        public short YearTo { get; set; }
        public short Source { get; set; }
        public string Notes { get; set; }
        public bool? IsActive { get; set; }
        public short AcessLevel { get; set; }
        public int? PlaceEvent { get; set; }
        public int Idcontributor { get; set; }

        public virtual Eventslist EventNavigation { get; set; }
        public virtual Person IdpersonNavigation { get; set; }
    }
}
