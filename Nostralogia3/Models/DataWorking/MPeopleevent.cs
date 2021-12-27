using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.DataWorking
{
    public class MPeopleevent
    {
        public int Idevent { get; set; }
        public int Idperson { get; set; }
        public string EventStrId { get; set; }
        public string EventDescription { get; set; }
        public byte DayFrom { get; set; }
        public byte MonthFrom { get; set; }
        public short YearFrom { get; set; }
        public byte DayTo { get; set; }
        public byte MonthTo { get; set; }
        public short YearTo { get; set; }
        public short Idsource { get; set; }
        public string Notes { get; set; }
        public string Authenticity { get; set; }
        public bool IsActive { get; set; }
        public short AcessLevel { get; set; }
        public byte DataType { get; set; }
        public byte? CategoryId { get; set; }
        public short IdeventKind { get; set; }
        public int? PlaceEvent { get; set; }
        public int Idcontributor { get; set; }
        public string CategoryDescription { get; set; }
        public string SourceDescription { get; set; }
        public string EventPlaceDisplay { get; set; }


    }
}
