using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class RectTimeVariant
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public byte DayRect { get; set; }
        public byte MonthRect { get; set; }
        public short YearRect { get; set; }
        public byte HourRect { get; set; }
        public double MinuteRect { get; set; }
        public int IdPlace { get; set; }
        public byte Description { get; set; }
        public byte Source { get; set; }
        public byte AdditionalHours { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual RectTimeVarCharacteristic DescriptionNavigation { get; set; }
        public virtual Source SourceNavigation { get; set; }
    }
}
