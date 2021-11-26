using Nostralogia3.Models.Authentication;
using Nostralogia3.Models.Events;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Persons;
using Nostralogia3.Models.UserControls;
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

        public NostraTable PeopleTable { get; protected set; }
        public NostraTable EventTable { get; protected set; }

        public HomePageModel()
        {
            GetData();
        }
        protected void GetData()
        {

            Events = EventsDataFactory.GetEventslDisplayDataList();
            People = PersonalDataFactory.GetPersonalDisplayDataList();
            PeopleTable = new NostraTable("Last Ten People Added");
            PeopleTable.Labels = new List<string>()
            { "Name","DOB","Birth place","Events","Keywords","Pictures"};

            PeopleTable.Data = new List<List<string>>();
            foreach(var p in People)
            {
                PeopleTable.Data.Add(new List<string>()
                {
                    $"{p.SecondName} {p.FirstName.Substring(0,1)}.",
                    $"{p.BirthDay}-{p.BirthMonth}-{p.BirthYear}",
                    $"{p.CityName} ({p.CountryAcronym})",
                    p.NumEvents.ToString(),
                    p.NumKw.ToString(),
                    p.NumPictures.ToString()
                });
            }

            EventTable = new NostraTable("Last Ten Events Added");
            EventTable.Labels = new List<string>()
            {
                "Event Name","Date","Impact","Contributor"
            };
            EventTable.Data = new List<List<string>>();
            foreach (var e in Events)
            {
                EventTable.Data.Add(new List<string>()
                {
                    e.EventName,
                    $"{e.EventsDayFrom}-{e.EventsMonthFrom}-{e.EventsYearFrom}",
                    e.Impact,
                    e.UserName
                });
            }
        }
    }
}
