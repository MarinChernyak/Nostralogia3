using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class VwWorldEvent
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
        public byte SourceId { get; set; }
        public byte EventsDataType { get; set; }
        public string CommentSource { get; set; }
        public string CommentEvent { get; set; }
        public int? IdContributor { get; set; }
        public DateTime DateCreated { get; set; }
        public byte SourceRating { get; set; }
        public string EventKeywords { get; set; }
        public byte PagePlaceDataId { get; set; }
        public byte EventScaleValue { get; set; }
        public byte IdScaleEvent { get; set; }
        public short KindEvent { get; set; }
        public short IdhistScale { get; set; }
        public byte HistScaleValue { get; set; }
        public int WictimsNumber { get; set; }
        public int SurviversNumber { get; set; }
        public double Damage { get; set; }
        public byte PotentialSeverity { get; set; }
        public byte ImpactRelatedSectors { get; set; }
        public string EventName { get; set; }
        public string PlaceDataFactory { get; set; }
        public string Impact { get; set; }
        public string ImpactDetails { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Source { get; set; }
        public string DataTypeName { get; set; }
        public string DataTypeDetails { get; set; }
        public short? ContributorsCountryId { get; set; }
    }
}
