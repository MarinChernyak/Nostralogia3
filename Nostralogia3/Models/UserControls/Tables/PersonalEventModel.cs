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
        private int IdPerson { get; }

        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Sources { get; set; }
        public List<SelectListItem> DataTypes { get; set; }
        public List<SelectListItem> EventsKinds { get; set; }

        public PersonalEventModel(int idPerson, string label="")
        {            
            IsDataTypeTheSame = true;
            MainLabel = label;
            IdPerson = idPerson;
            IsDataTypeTheSame = true;
            IsEvent = EventValue;
            FillUpDropDowns();
            CreatePartialsModels();
        }

        protected void FillUpDropDowns()
        {
            Categories = EventsDataFactory.GetPersonalEventsCategory();
            Sources = PersonalDataFactory.GetDataSources();
            DataTypes = PersonalDataFactory.GetDataTypes();
            EventsKinds = EventsDataFactory.GetPersonalEventsKinds(-1);
        }
        protected void CreatePartialsModels()
        {
            DateTime dt = DateTime.Today;
            DateFrom = new SimpleCalendarModel("Date of the Event", (byte)dt.Day, (byte)dt.Month, (short)dt.Year);
            DateTo = new SimpleCalendarModel("End of the Period", (byte)dt.Day, (byte)dt.Month, (short)dt.Year);
            EventPlace = new EventPlaceModel("Pleace of the Event");

        }
    }
}
