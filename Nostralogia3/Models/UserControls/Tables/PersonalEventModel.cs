using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Geo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls.Tables
{
    public class PersonalEventModel
    {
        private string LabelDateEventFrom { get { return "Date of the Event"; } }
        private string LabelDateEventTo { get { return "End of the Period"; } }
        private string LabelPlaceEvent { get { return "Pleace of the Event"; } }

        public int Id { get; set; }
        public string EventValue { get { return "Event"; } }
        public string PeriodValue { get { return "Period"; } }
        public string MainLabel { get; set; }
        public SimpleCalendarModel DateFrom { get; set; }
        public SimpleCalendarModel DateTo { get; set; }

        [DisplayName("DataType the same as all data of the person")]
        public bool IsDataTypeTheSame {get;set;}
        public EventPlaceModel EventPlace { get; set; }
        [DisplayName("Where do you know those dates from?")]
        public short Idsource { get; set; }

        [DisplayName("If you want, please write some details of the event")]
        public string Notes { get; set; }
        public byte DataType { get; set; }
        [DisplayName("Select a Categoty of the Event")]
        public short IdCategory { get; set; }
        [DisplayName("Select a Kind of the Event")]
        public short IdeventKind { get; set; }
        public int? PlaceEvent { get; set; }
        public int Idcontributor { get; set; }

        public string IsEvent { get; set; }
        public int IdPerson { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Sources { get; set; }
        public List<SelectListItem> DataTypes { get; set; }
        public List<SelectListItem> EventsKinds { get; set; }

        public PersonalEventModel()
        {
            CreatePartialsModels();
        }
        public PersonalEventModel(int idPerson, int idEvent=0, string label="")
        {
            MainLabel = label;
            if (idPerson>0)
            {
                IsDataTypeTheSame = true;              
                IdPerson = idPerson;
                IsDataTypeTheSame = true;
                IsEvent = EventValue;
                FillUpDropDowns();
                CreatePartialsModels();
            }
            else if(idEvent>0)
            {
                Id = idEvent;
                MPeopleevent mpe = EventsDataFactory.GetPersonalEvent(idEvent);
                IdCategory = mpe.CategoryId.Value;
                DataType = (byte)mpe.AcessLevel;
                DateFrom = new SimpleCalendarModel(LabelDateEventFrom, mpe.DayFrom, mpe.MonthFrom, mpe.YearFrom);
                DateTo = new SimpleCalendarModel(LabelDateEventTo, mpe.DayTo, mpe.MonthTo, mpe.YearTo);
                EventPlace = new EventPlaceModel(mpe.PlaceEvent.Value, LabelPlaceEvent);
                Idsource = mpe.Source;
                Notes = mpe.Notes;
                IdCategory = (short)mpe.CategoryId;
                IdeventKind = mpe.Event;
                IdPerson = mpe.Idperson;
                FillUpDropDowns(IdCategory);

                Categories.FirstOrDefault(x => x.Value == IdCategory.ToString()).Selected = true;
                Sources.FirstOrDefault(x => x.Value == Idsource.ToString()).Selected = true;
                DataTypes.FirstOrDefault(x => x.Value == DataType.ToString()).Selected = true;
                EventsKinds.FirstOrDefault(x => x.Value == IdeventKind.ToString()).Selected = true;

                IsEvent = IsEventPeriod(mpe);
                IsDataTypeTheSame = IsDataTypeTheSameAsPerson(mpe);

            }

        }
        protected void FillUpDropDowns(int idCategory=-1)
        {
            Categories = EventsDataFactory.GetPersonalEventsCategory();
            Sources = PersonalDataFactory.GetDataSources();
            DataTypes = PersonalDataFactory.GetDataTypes();
            EventsKinds = EventsDataFactory.GetPersonalEventsKinds(idCategory);
        }
        protected string IsEventPeriod(MPeopleevent mpe)
        {
            string brez = PeriodValue;
            if(mpe.DayFrom==mpe.DayTo && mpe.MonthFrom==mpe.MonthTo && mpe.YearFrom==mpe.YearTo)
            {
                brez = EventValue;
            }
            return brez;
        }
        protected bool IsDataTypeTheSameAsPerson(MPeopleevent mpe)
        {
            int personLevel = PersonalDataFactory.GetPersonDataType(mpe.Idperson);
            return personLevel==mpe.AcessLevel;
        }
        protected void CreatePartialsModels()
        {
            DateTime dt = DateTime.Today;
            DateFrom = new SimpleCalendarModel(LabelDateEventFrom, (byte)dt.Day, (byte)dt.Month, (short)dt.Year);
            DateTo = new SimpleCalendarModel(LabelDateEventTo, (byte)dt.Day, (byte)dt.Month, (short)dt.Year);
            EventPlace = new EventPlaceModel(LabelPlaceEvent);

        }
    }
}
