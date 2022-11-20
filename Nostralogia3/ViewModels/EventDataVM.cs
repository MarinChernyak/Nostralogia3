using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Geo;
using Nostralogia3.Models.UserControls;
using Nostralogia3.Models.UserControls.KeyWords;
using Nostralogia3.ViewModels.MapNotes;
using Nostralogia3.ViewModels.UserControls.KeyWords;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels
{
    public class EventDataVM : ViewModelBase
    {
        public SimpleCalendarModel CalendarModelFrom { get; protected set; } = new();
        public SimpleCalendarModel CalendarModelTo { get; protected set; } = new();
        public MWorldEvent _model { get; protected set; }
        public bool ReadOnly { get; protected set; }
        public SimpleTimePickerModel TimeFrom { get; set; } = new();
        public SimpleTimePickerModel TimeTo { get; set; } = new();
        public KeyWordsCollectionModel KWCollection { get; protected set; } = new();
        public MapNotesVM MapNotes { get; protected set; }
        public bool IsInterval { get; set; }
        
        [DisplayName("Select a place type")]
        public PlaceDataCommon.PlaceDataType PlaceDataType { get; set; }
        public PlaceDataCommon PlaceVM { get; set; }
       
        [DisplayName("Number of Victims")]
        public int NumberVictims { get; set; }
        [DisplayName("Number of Survivors")]
        public int NumberSurvivors { get; set; }
        [DisplayName("Damage (M$)")]
        public double Damage { get; set; }
        [DisplayName("Potential Severity")]
        public int PotentialSeverity { get; set; }
        [DisplayName("Hystorical Scales")]
        public int HystoriacalScale { get; set; }
        [DisplayName("Select a value")]
        public int HystoriacalScaleValue { get; set; }
        public DropDownWithHelpModel ImpactRelatedSectorsVM { get; set; } = new();

        #region Collections
        public List<SelectListItem> PotentialSeverityCollection { get; set; }
        public List<SelectListItem> PlaceDatTypes { get; set; }
        public List<SelectListItem> HystoricalScalesCollection { get; set; }
        public List<SelectListItem> HystoricalScalesValuesCollection { get; set; }
        #endregion
        public EventDataVM() { }

        public EventDataVM(ISession session)
        {
            _session = session;
            _model = new MWorldEvent();
            DateTime dt = DateTime.Now;
            ReadOnly = false;
            CalendarModelFrom = new SimpleCalendarModel("Date of the Event (From)", (byte)dt.Day, (byte)dt.Month, (short)dt.Year, ReadOnly);
            CalendarModelTo = new SimpleCalendarModel("Date of the Event (To)", (byte)dt.Day, (byte)dt.Month, (short)dt.Year, ReadOnly);
            PlaceVM = new EventPlaceModel("Birth Place");
            
            TimeFrom = new SimpleTimePickerModel("Time of the Event From:", 0, 0, ReadOnly);
            TimeTo = new SimpleTimePickerModel("Time of the Event To:", 0, 0, ReadOnly);
            KWCollection = new KeyWordsCollectionModel(0);
            MapNotes = new MapNotesVM(_session, 0);
            PlaceVM = new EventPlaceModel(@"City\Vilage of the Event");
            HystoriacalScale = 1;
            FillUpCollections();

        }
        protected void FillUpCollections()
        {
            FillUpSourcedata();
            FillUpShiftTimeCollection();
            FillUpDataTypeCollection();
            FillUpPlaceDataTypes();
            PotentialSeverityCollection = HystoricalEventsFactory.GetPotentialSeverity();
            HystoricalScalesCollection = HystoricalEventsFactory.GetHystoricalScales();
            HystoricalScalesValuesCollection = HystoricalEventsFactory.GetHystoricalScaleValues(HystoriacalScale);
        }
        protected void FillUpPlaceDataTypes()
        {
            PlaceDatTypes = HystoricalEventsFactory.GetPlaceDataTypes();
            var item = PlaceDatTypes.FirstOrDefault(x => x.Value == "1");
            if(item!=null)
            {
                item.Selected = true;
            }
        }
        protected void FillUpSourcedata()
        {

        }
        protected void FillUpShiftTimeCollection()
        {
            
        }
        protected void FillUpDataTypeCollection()
        {

        }
    }
}
