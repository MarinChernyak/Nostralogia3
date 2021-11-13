using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Worldevent
    {
        public Worldevent()
        {
            CharacteristicsDisasters = new HashSet<CharacteristicsDisaster>();
            CoordinateEvents = new HashSet<CoordinateEvent>();
            EventHistorScaleVals = new HashSet<EventHistorScaleVal>();
            EventScaleVals = new HashSet<EventScaleVal>();
            EventsKwStorages = new HashSet<EventsKwStorage>();
            Expansions = new HashSet<Expansion>();
            Picture1s = new HashSet<Picture1>();
            PlaceEvents = new HashSet<PlaceEvent>();
        }

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

        public virtual Datatype EventsDataTypeNavigation { get; set; }
        public virtual EventPlaceType PlaceDataEventNavigation { get; set; }
        public virtual Source1 SourceEventNavigation { get; set; }
        public virtual ICollection<CharacteristicsDisaster> CharacteristicsDisasters { get; set; }
        public virtual ICollection<CoordinateEvent> CoordinateEvents { get; set; }
        public virtual ICollection<EventHistorScaleVal> EventHistorScaleVals { get; set; }
        public virtual ICollection<EventScaleVal> EventScaleVals { get; set; }
        public virtual ICollection<EventsKwStorage> EventsKwStorages { get; set; }
        public virtual ICollection<Expansion> Expansions { get; set; }
        public virtual ICollection<Picture1> Picture1s { get; set; }
        public virtual ICollection<PlaceEvent> PlaceEvents { get; set; }
    }
}
