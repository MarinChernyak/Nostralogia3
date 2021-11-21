using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Persons
{
    public class MVwPersonalDisplayDatum
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public byte BirthDay { get; set; }
        public byte BirthMonth { get; set; }
        public short BirthYear { get; set; }
        public byte BirthHourFrom { get; set; }
        public byte BirthMinFrom { get; set; }
        public byte BirthSecFrom { get; set; }
        public byte BirthHourTo { get; set; }
        public byte BirthMinTo { get; set; }
        public byte BirthSecTo { get; set; }
        public byte SourceBirthTime { get; set; }
        public byte AdditionalHours { get; set; }
        public int Place { get; set; }
        public byte DataType { get; set; }
        public int? IdContributor { get; set; }
        public int? Sex { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool IsAvailable { get; set; }
        public string SexDescription { get; set; }
        public string DataTypeDescription { get; set; }
        public string DataTypeName { get; set; }
        public int? NumPictures { get; set; }
        public int? NumKw { get; set; }
        public int? NumEvents { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public short CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryAcronym { get; set; }
        public string StateRegion { get; set; }
        public string StateAcronym { get; set; }
        public int StateId { get; set; }
        public double DiffTime { get; set; }
        public string Abbreviation { get; set; }
        public string TzoneName { get; set; }
    }
}
