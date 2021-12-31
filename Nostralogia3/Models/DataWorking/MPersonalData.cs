using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Geo;
using Nostralogia3.Models.Persons;
using Nostralogia3.Models.UserControls;
using NostralogiaDAL.NostradamusEntities;
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
        [DisplayName("Last Name (You can use pseudonym)")]
        [MaxLength(50, ErrorMessage = "The length of a name must not exсeed 50 characters")]
        public string SecondName { get ; set; }
        public byte BirthDay
        {
            get
            {
                return SimpleCalendarModel.Day;
            }
            set
            {
                SimpleCalendarModel.Day = value;
            }
        }
        public byte BirthMonth {
            get
            {
                return SimpleCalendarModel.Month;
            }
            set
            {
                SimpleCalendarModel.Month = value;
            }
        }
        public short BirthYear {
            get
            {
                return SimpleCalendarModel.Year;
            }
            set
            {
                SimpleCalendarModel.Year = value;
            }
        }
        public byte BirthHourFrom 
        { 
            get { return (byte)TimeFrom.Hour; } 
            set { TimeFrom.Hour = value; }
        }
        public byte BirthMinFrom {
            get { return (byte)TimeFrom.Minute; }
            set { TimeFrom.Minute = value; }
        }
        public byte BirthSecFrom {
            get;set;
            
        }
        public byte BirthHourTo {
            get { return (byte)TimeTo.Hour; }
            set { TimeTo.Hour = value; }
        }
        public byte BirthMinTo {
            get { return (byte)TimeTo.Minute; }
            set { TimeTo.Minute = value; }
        }
        public byte BirthSecTo { get; set; }
        [DisplayName("Where do you know the birth time?")]

        public byte SourceBirthTime { get; set; }
        [DisplayName("Additional Time Shift")]
        public byte AdditionalHours { get; set; }
        public int Place { 
            get {  return EventPlaceModel.PlaceId??48; }
            set { EventPlaceModel.PlaceId = value; }
        }
        [DisplayName("Whom do you allow to see your data?")]
        public byte DataType { get; set; }
        public int? IdContributor { get; set; }
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsAvailable { get; set; }
        public int? Sex { get; set; }

        public string ErrorMessage { get; protected set; }
        public SimpleCalendarModel SimpleCalendarModel { get; protected set;}
        public KeyWordsCollectionModel KWCollection { get; protected set; }
        public PersonalEventsCollectionModel EventsCollection{ get; protected set; }
    public MPersonalData()
        {
          
            EventPlaceModel = new EventPlaceModel("Birth Place");
            DateTime dt = DateTime.Now;
            SimpleCalendarModel = new SimpleCalendarModel("Date of Birth", (byte)dt.Day, (byte)dt.Month, (short)dt.Year);
            TimeFrom = new SimpleTimePickerModel("Birth Time From:", 0, 0);
            TimeTo = new SimpleTimePickerModel("Birth Time To:", 0, 0);
            KWCollection = new KeyWordsCollectionModel(0);
            EventsCollection = new PersonalEventsCollectionModel("Events of the person");
            FillUpCollections();
        }
        public MPersonalData(int Id)
        {                        
            UpdateFormDetails(Id);
            FillUpCollections();
        }
        public virtual List<MMapNote> MapNotes { get; set; }
        public SimpleTimePickerModel TimeFrom { get; set; }
        public SimpleTimePickerModel TimeTo { get; set; }
        public EventPlaceModel EventPlaceModel { get; set; }
        public virtual List<MPeopleevent> Peopleevents { get; set; }
        public virtual List<MPeoplekeywordsstore> Peoplekeywordsstores { get; set; }
        public virtual ICollection<MPicture> Pictures { get; set; }
        public List<SelectListItem> SexCollection { get; protected set; }
        public List<SelectListItem> SourceColection { get; protected set; }
        public List<SelectListItem> TimeShifts { get; protected set; }
        public List<SelectListItem> DataTypeCollection { get; protected set; }
        public List<MDataType> MDataTypes { get; protected set; }

        public void FillUpCollections()
        {
            using (NostradamusContext context = new NostradamusContext())
            {
                FillUpSourcedata(context);
                FillUpSexCollection(context);
                FillUpShiftTimeCollection(context);
                FillUpDataTypeCollection(context);
            }
        }
        protected void FillUpDataTypeCollection(NostradamusContext context)
        {
            DataTypeCollection = new List<SelectListItem>();
            List<NostralogiaDAL.NostradamusEntities.Datatype> lst = context.Datatypes.OrderBy(x=>x.Idtype).ToList();
            MDataTypes = ModelsTransformer.TransferModelList<NostralogiaDAL.NostradamusEntities.Datatype, MDataType>(lst);
            foreach (NostralogiaDAL.NostradamusEntities.Datatype sd in lst)
            {
                DataTypeCollection.Add(new SelectListItem()
                {
                    Text = sd.Description,
                    Value = sd.Idtype.ToString(),
                    Selected = sd.Idtype == DataType ? true : false
                });
            }
        }
        protected void FillUpShiftTimeCollection(NostradamusContext context)
        {
            TimeShifts = new List<SelectListItem>();
            List<TimesShift> lst = context.TimesShifts.ToList();
            foreach (TimesShift sd in lst)
            {
                TimeShifts.Add(new SelectListItem()
                {
                    Text = $"{sd.Description}({sd.ShiftValue} h)",
                    Value = sd.Idtimeshift.ToString(),
                    Selected = sd.Idtimeshift == AdditionalHours? true : false
                });
            }
        }
        protected void FillUpSourcedata(NostradamusContext context)
        {
            SourceColection = new List<SelectListItem>();
            List<Source> lst = context.Sources.ToList();
            foreach (Source sd in lst)
            {
                SourceColection.Add(new SelectListItem()
                {
                    Text = sd.SourceDescription,
                    Value = sd.Idsource.ToString(),
                    Selected = sd.Idsource == SourceBirthTime ? true : false
                });
            }            
        }            
        protected void FillUpSexCollection(NostradamusContext context)
        {
            SexCollection = new List<SelectListItem>();
            List<SexDatum> lst = context.SexData.ToList();
            foreach (SexDatum sd in lst)
            {
                SexCollection.Add(new SelectListItem()
                {
                    Text = sd.SexDescription,
                    Value = sd.SexId.ToString(),
                    Selected = sd.SexId == Sex ? true : false
                });
            }            
        }
        protected void UpdateFormDetails(int Id)
        {
            MVwPersonalDisplayDatum data = PersonalDataFactory.GetPersonalDisplayData(Id);
            if(data!=null)
            {
                FirstName = data.FirstName;
                SecondName = data.SecondName;
                Sex = data.Sex;
                BirthDay = data.BirthDay;               
                BirthMonth = data.BirthMonth;
                BirthYear = data.BirthYear;
                SimpleCalendarModel = new SimpleCalendarModel("Date of Birth", BirthDay, BirthMonth, BirthYear);
                BirthHourFrom = data.BirthHourFrom;
                BirthHourTo = data.BirthHourTo;
                BirthMinFrom = data.BirthMinFrom;
                BirthMinTo = data.BirthMinTo;
                AdditionalHours = data.AdditionalHours;
                TimeFrom = new SimpleTimePickerModel("Birth Time 'From'", BirthHourFrom, BirthMinFrom);
                TimeTo = new SimpleTimePickerModel("Birth Time 'To'", BirthHourTo, BirthMinTo);
                SourceBirthTime = data.SourceBirthTime;
                EventPlaceModel = new EventPlaceModel(data.CountryId,data.StateId, data.Place,"Birth Place");
            }
        }

        public int AddNew()
        {
            
            Id = PersonalDataFactory.AddPersonalData(this);

            return Id;
        }
    }
}
