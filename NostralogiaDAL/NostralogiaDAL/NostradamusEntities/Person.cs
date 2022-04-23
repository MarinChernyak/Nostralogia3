using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Person
    {
        public Person()
        {
            MapNotes = new HashSet<MapNote>();
            PeopleUsers = new HashSet<PeopleUser>();
            Peopleevents = new HashSet<Peopleevent>();
            Peoplekeywordsstores = new HashSet<Peoplekeywordsstore>();
            Pictures = new HashSet<Picture>();
        }

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
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsAvailable { get; set; }
        public int? Sex { get; set; }

        public virtual Datatype DataTypeNavigation { get; set; }
        public virtual ICollection<MapNote> MapNotes { get; set; }
        public virtual ICollection<PeopleUser> PeopleUsers { get; set; }
        public virtual ICollection<Peopleevent> Peopleevents { get; set; }
        public virtual ICollection<Peoplekeywordsstore> Peoplekeywordsstores { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
