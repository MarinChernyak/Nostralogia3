using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Geo;
using Nostralogia3.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls
{

    public class PersonalEventsCollectionModel : NostraTable
    {
        public List<MPeopleevent> EventsCollection { get; protected set; } = new();
        public string Label { get; protected set; } = string.Empty;
        public int Idperson { get; set; }

        //public NewPersonalEventModal NewPersonalEventModal { get; set; } = new();
        public PersonalEventsCollectionModel(string label)
            :base(label,false)
        {
            Label = label;
            InitCollection(0);
        }
        public PersonalEventsCollectionModel(int personId, string label)
            :base(label,false)
        {
            Label = label;
            InitCollection(personId);
            Idperson = personId;
            //NewPersonalEventModal.DateFrom = new SimpleCalendarModel("Date From", 1, 1, 1900);
        }
        protected void InitCollection(int personId)
        {
            EventsCollection = EventsDataFactory.GetPersonalEventslList(personId);
            Labels = new List<LabelData>();
            Labels.Add(new LabelData() { Label="Date From",Width= "200px" });
            Labels.Add(new LabelData() { Label = "Place", Width = "200px" });
            Labels.Add(new LabelData() { Label = "Category", Width = "300px" });
            Labels.Add(new LabelData() { Label = "", Width = "50px" });
            Labels.Add(new LabelData() { Label = "", Width = "50px" });
            GeoFactory gf = new GeoFactory();
            foreach (MPeopleevent pe in EventsCollection)
            {
                List<string> lst = new List<string>();
                string prefixd = pe.DayFrom < 10 ? "0" : "";
                string prefixm = pe.MonthFrom < 10 ? "0" : "";

                lst.Add($"{prefixd}{pe.DayFrom}-{prefixm}{pe.MonthFrom}-{pe.YearFrom}");
                string place = pe.PlaceEvent == null ? string.Empty : gf.GetDisplayPlaceEvent((int)pe.PlaceEvent);
                lst.Add(place);
                lst.Add(pe.CategoryDescription);
                lst.Add($"{Constants.Values.MarkerEdit}:{"PersonalEvent"}|{"EditPersonalEvent"}|{pe.Idevent}");
                lst.Add($"{Constants.Values.MarkerDelete}:{"PersonalEvent"}|{"DeleteEvent"}|{pe.Idevent}");

                Data.Add(lst);
            }
        }
    }
}
