using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class TimesShift
    {
        public byte Idtimeshift { get; set; }
        public double ShiftValue { get; set; }
        public string AdvKindOfShift { get; set; }
        public string Description { get; set; }
    }
}
