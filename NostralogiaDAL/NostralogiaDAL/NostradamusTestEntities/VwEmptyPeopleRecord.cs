using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class VwEmptyPeopleRecord
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
        public int? IdContributor { get; set; }
        public string Email { get; set; }
        public string AccessLevel { get; set; }
        public byte DataType { get; set; }
        public string Authenticity { get; set; }
        public int? AuthenticityNum { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
