using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Geo;
using Nostralogia3.Models.UserControls;
using Nostralogia3.Models.UserControls.KeyWords;
using Nostralogia3.ViewModels.MapNotes;
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
        public EventPlaceModel EventPlaceModel { get; set; }
        public SimpleTimePickerModel TimeFrom { get; set; } = new();
        public SimpleTimePickerModel TimeTo { get; set; } = new();
        public KeyWordsCollectionModel KWCollection { get; protected set; } = new();
        public MapNotesVM MapNotes { get; protected set; }
        public bool IsInterval { get; set; }
        public List<SelectListItem> PlaceDatTypes { get; set; }
        
        [DisplayName("Select a place type")]
        public PlaceDataCommon.PlaceDataType PlaceDataType { get; set; }
        public PlaceDataCommon PlaceVM { get; set; }
        public EventDataVM() { }

        public EventDataVM(ISession session)
        {
            _session = session;
            _model = new MWorldEvent();
            DateTime dt = DateTime.Now;
            ReadOnly = false;
            CalendarModelFrom = new SimpleCalendarModel("Date of the Event (From)", (byte)dt.Day, (byte)dt.Month, (short)dt.Year, ReadOnly);
            CalendarModelTo = new SimpleCalendarModel("Date of the Event (To)", (byte)dt.Day, (byte)dt.Month, (short)dt.Year, ReadOnly);
            EventPlaceModel = new EventPlaceModel("Birth Place");
            
            TimeFrom = new SimpleTimePickerModel("Time of the Event From:", 0, 0, ReadOnly);
            TimeTo = new SimpleTimePickerModel("Time of the Event To:", 0, 0, ReadOnly);
            KWCollection = new KeyWordsCollectionModel(0);
            MapNotes = new MapNotesVM(_session, 0);
            PlaceVM = new EventPlaceModel(@"City\Vilage of the Event");
            FillUpCollections();

        }
        protected void FillUpCollections()
        {
            FillUpSourcedata();
            FillUpShiftTimeCollection();
            FillUpDataTypeCollection();
            FillUpPlaceDataTypes();
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
