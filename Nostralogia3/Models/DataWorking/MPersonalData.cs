using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.DataWorking
{
    public class MPersonalData
    {
        public int Id { get; set; }
        [DisplayName("First Name (You can use pseudonym)")]
        [MaxLength(50, ErrorMessage = "The length of a name must not exсeed 50 characters")]
        public string FirstName { get; set; }
        [DisplayName("First Name (You can use pseudonym)")]
        [MaxLength(50, ErrorMessage = "The length of a name must not exсeed 50 characters")]
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

        public string ErrorMessage { get; protected set; }
        public virtual List<MMapNote> MapNotes { get; set; }
        //public virtual ICollection<PeopleUser> PeopleUsers { get; set; }
        public virtual List<MPeopleevent> Peopleevents { get; set; }
        public virtual List<MPeoplekeywordsstore> Peoplekeywordsstores { get; set; }
        public virtual ICollection<MPicture> Pictures { get; set; }
    }
}
