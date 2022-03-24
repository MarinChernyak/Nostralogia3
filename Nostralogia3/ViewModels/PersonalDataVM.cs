using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Geo;
using Nostralogia3.Models.Persons;
using Nostralogia3.Models.UserControls;
using NostralogiaDAL.NostradamusEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using Nostralogia3.Models.PicturesViewer;
using Microsoft.AspNetCore.Http;

namespace Nostralogia3.ViewModels
{
    public class PersonalDataVM
    {
        public MPersonalData _model { get; set; }
        public bool ReadOnly { get; protected set; }
        public virtual List<MMapNote> MapNotes { get; set; } = new();
        public SimpleTimePickerModel TimeFrom { get; set; } = new();
        public SimpleTimePickerModel TimeTo { get; set; } = new();
        public EventPlaceModel EventPlaceModel { get; set; }
        public virtual List<MPeopleevent> Peopleevents { get; set; } = new();
        public virtual List<MPeoplekeywordsstore> Peoplekeywordsstores { get; set; } = new();
        public virtual ICollection<MPicture> Pictures { get; set; }
        public List<SelectListItem> SexCollection { get; protected set; } = new();
        public List<SelectListItem> SourceColection { get; protected set; } = new();
        public List<SelectListItem> TimeShifts { get; protected set; } = new();
        public List<SelectListItem> DataTypeCollection { get; protected set; } = new();
        public List<MDataType> MDataTypes { get; protected set; } = new();
        public string ErrorMessage { get; protected set; }
        public SimpleCalendarModel SimpleCalendarModel { get; protected set; } = new();
        public KeyWordsCollectionModel KWCollection { get; protected set; } = new();
        public PersonalEventsCollectionModel EventsCollection { get; protected set; }
        public PicturesViewerPersonalPreviewModel PicturesViewer { get; protected set; } 
        protected ISession _session { get; set; }

        public PersonalDataVM(ISession session)
        {
            _session = session;
            ReadOnly = false;
            _model = new MPersonalData();
            EventPlaceModel = new EventPlaceModel("Birth Place");
            DateTime dt = DateTime.Now;
            SimpleCalendarModel = new SimpleCalendarModel("Date of Birth", (byte)dt.Day, (byte)dt.Month, (short)dt.Year, ReadOnly);
            TimeFrom = new SimpleTimePickerModel("Birth Time From:", 0, 0, ReadOnly);
            TimeTo = new SimpleTimePickerModel("Birth Time To:", 0, 0, ReadOnly);
            KWCollection = new KeyWordsCollectionModel(0);
            EventsCollection = new PersonalEventsCollectionModel("Events of the person", _session);
            FillUpCollections();

        }
        public PersonalDataVM(int Id, ISession session)
        {
            _session = session;
            UpdateFormDetails(Id);
        }
        protected void UpdateFormDetails(int Id)
        {
            MVwPersonalDisplayDatum data = PersonalDataFactory.GetPersonalDisplayData(Id);
            _model = new MPersonalData();
            if (data != null)
            {
                _model.FirstName = data.FirstName;
                _model.SecondName = data.SecondName;
                _model.Sex = data.Sex;
                _model.BirthDay = data.BirthDay;
                _model.BirthMonth = data.BirthMonth;
                _model.BirthYear = data.BirthYear;
                _model.BirthHourFrom = data.BirthHourFrom;
                _model.BirthHourTo = data.BirthHourTo;
                _model.BirthMinFrom = data.BirthMinFrom;
                _model.BirthMinTo = data.BirthMinTo;
                _model.AdditionalHours = data.AdditionalHours;
                _model.SourceBirthTime = data.SourceBirthTime;
                _model.Email = data.Email;
                _model.DataType = data.DataType;
                _model.Id = Id;
            }
            string suserlevel = _session.GetString(Constants.SessionCoockies.SessionULevel);
            string suserID = _session.GetString(Constants.SessionCoockies.SessionUID);
            int userlevel = 0;
            int.TryParse(suserlevel, out userlevel);
            int userID = 0;
            int.TryParse(suserID, out userID);
            ReadOnly = CommonFunctionsFactory.IsReadOnly(userID, _model.IdContributor ?? 0, userlevel, _model.DataType);

            EventPlaceModel = new EventPlaceModel(data.CountryId, data.StateId, data.Place, "Birth Place",ReadOnly);
            SimpleCalendarModel = new SimpleCalendarModel("Date of Birth", _model.BirthDay, _model.BirthMonth, _model.BirthYear, ReadOnly);
            TimeFrom = new SimpleTimePickerModel("Birth Time 'From'", _model.BirthHourFrom, _model.BirthMinFrom, ReadOnly);
            TimeTo = new SimpleTimePickerModel("Birth Time 'To'", _model.BirthHourTo, _model.BirthMinTo, ReadOnly);
            KWCollection = new KeyWordsCollectionModel(0, Id);
            EventsCollection = new PersonalEventsCollectionModel(Id,"Events of the person", _session);
            PicturesViewer = new PicturesViewerPersonalPreviewModel(_model.Id);
            FillUpCollections();
        }
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
            DataTypeCollection = PersonalDataFactory.GetDataTypes();
            var sel = DataTypeCollection.FirstOrDefault(x => x.Value == _model.DataType.ToString());
            if (sel != null)
            {
                sel.Selected = true;
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
                    Selected = sd.Idtimeshift == _model.AdditionalHours ? true : false
                });
            }
        }
        protected void FillUpSourcedata(NostradamusContext context)
        {
            SourceColection = PersonalDataFactory.GetDataSources();
            var sel = SourceColection.FirstOrDefault(x => x.Value == _model.SourceBirthTime.ToString());
            if (sel != null)
            {
                sel.Selected = true;
            }
        }
        protected void FillUpSexCollection(NostradamusContext context)
        {
            SexCollection = new List<SelectListItem>();
            List<SexDatum> lst = PersonalDataFactory.GetSexCollection();
            foreach (SexDatum sd in lst)
            {
                SexCollection.Add(new SelectListItem()
                {
                    Text = sd.SexDescription,
                    Value = sd.SexId.ToString(),
                    Selected = sd.SexId == _model.Sex ? true : false
                });
            }
        }
        private void UpdateModel()
        {
            _model.Place = EventPlaceModel.PlaceId.Value;
            _model.BirthDay = SimpleCalendarModel.Day;
            _model.BirthMonth = SimpleCalendarModel.Month;
            _model.BirthYear = SimpleCalendarModel.Year;
            _model.BirthHourFrom = (byte)TimeFrom.Hour;
            _model.BirthMinFrom = (byte)TimeFrom.Minute;
            _model.BirthHourTo = (byte)TimeTo.Hour;
            _model.BirthMinTo = (byte)TimeTo.Minute;
        }
        public int AddNew()
        {
            UpdateModel();
            _model.Id = PersonalDataFactory.AddPersonalData(_model);
            KWCollection.IdForKWStorage = _model.Id;
            EventsCollection.Idperson = _model.Id;
            return _model.Id;
        }
        public bool UpdateData()
        {
            UpdateModel();
            _model.IsAvailable = true;
            return PersonalDataFactory.UpdatePersonalData(_model);
        }
        public string GetCancelLabel()
        {
            return ReadOnly? "Close" : "Cancel";
        }
        public string GetClassCancel()
        {
            return ReadOnly? "form-group ml-lg-4" : "form-group";
        }
    }
}
