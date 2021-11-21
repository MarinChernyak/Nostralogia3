using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class VwPersonalDatum
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public byte BirthDay { get; set; }
        public byte BirthMonth { get; set; }
        public short BirthYear { get; set; }
        public byte BirthHourFrom { get; set; }
        public byte BirthMinFrom { get; set; }
        public byte BirthHourTo { get; set; }
        public byte BirthMinTo { get; set; }
        public byte SourceBirthTime { get; set; }
        public byte AdditionalHours { get; set; }
        public int Place { get; set; }
        public byte DataType { get; set; }
        public int? IdContributor { get; set; }
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool IsAvailable { get; set; }
        public int? Sex { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public short CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryAcronym { get; set; }
        public string StateRegion { get; set; }
        public string StateAcronym { get; set; }
        public int? StateId { get; set; }
        public byte BirthSecFrom { get; set; }
        public byte BirthSecTo { get; set; }
        public string Authenticity { get; set; }
        public string SourceDescription { get; set; }
        public string DataTypeName { get; set; }
        public string DataTypeDescription { get; set; }
        public int SexId { get; set; }
        public string Ids { get; set; }
        public string SexDescription { get; set; }
        public string Adv { get; set; }
        public string IdsSource { get; set; }
        public string IdsComments { get; set; }
        public string CommentDescription { get; set; }
    }
}
