using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.DataWorking
{
    public class MWorldEvent
    {
        public int Id { get; set; }
        public byte EventsDayFrom { get; set; }
        public byte EventsMonthFrom { get; set; }
        public short EventsYearFrom { get; set; }
        public byte EventsHFrom { get; set; }
        public byte EventsMFrom { get; set; }
        public byte EventsDayTo { get; set; }
        public byte EventsMonthTo { get; set; }
        public short EventsYearTo { get; set; }
        public byte EventsHTo { get; set; }
        public byte EventsMTo { get; set; }
        public byte PlaceDataEvent { get; set; }
        public byte SourceEvent { get; set; }
        public string CommentSource { get; set; }
        public string CommentEvent { get; set; }
        public int? IdContributor { get; set; }
        public DateTime DateCreated { get; set; }
        public string EventName { get; set; }
        public byte EventsDataType { get; set; }
    }
}
