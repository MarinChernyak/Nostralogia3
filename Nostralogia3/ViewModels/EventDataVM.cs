using Microsoft.AspNetCore.Http;
using Nostralogia3.Models;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Geo;
using Nostralogia3.Models.UserControls;
using Nostralogia3.Models.UserControls.KeyWords;
using Nostralogia3.ViewModels.MapNotes;
using System;
using System.Collections.Generic;
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
            FillUpCollections();

        }
        protected void FillUpCollections()
        {
            FillUpSourcedata();
            FillUpShiftTimeCollection();
            FillUpDataTypeCollection();
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
