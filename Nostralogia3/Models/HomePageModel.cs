using Nostralogia3.Models.Authentication;
using Nostralogia3.Models.Events;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models
{
    public class HomePageModel :BaseModel
    { 
        public List<MVwPersonalDisplayDatum> People { get; protected set; }
        public List<MVwWorldEvent> Events { get; protected set; }

        public HomePageModel()
        {
            GetData();
        }
        protected void GetData()
        {
            People = PersonalDataFactory.GetPersonalDisplayDataList();
            Events = EventsDataFactory.GetEventslDisplayDataList();
        }
    }
}
