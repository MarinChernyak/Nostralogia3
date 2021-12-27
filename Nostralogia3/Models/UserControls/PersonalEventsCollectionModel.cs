using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls
{
    public class PersonalEventsCollectionModel
    {
        public NostraTable Eventstable { get; protected set; }
        public List<MPeopleevent> EventsCollection { get; protected set; } = new();
        public string Label { get; protected set; } = string.Empty;
        public PersonalEventsCollectionModel(string label)
        {
            Label = label;
            InitCollection(0);
        }
        public PersonalEventsCollectionModel(int personId, string label)
        {
            Label = label;
            InitCollection(personId);
        }
        protected void InitCollection(int personId)
        {
            List<MPeopleevent> data = EventsDataFactory.GetPersonalEventslList(835);
            Eventstable = new NostraTable(Label, /*"500",*/false);
            Eventstable.Labels.Add(new LabelData() { Label="Date From",Width= "200px" });
            Eventstable.Labels.Add(new LabelData() { Label = "Place", Width = "200px" });
            Eventstable.Labels.Add(new LabelData() { Label = "Category", Width = "300px" });
            Eventstable.Labels.Add(new LabelData() { Label = "", Width = "50px" });
            Eventstable.Labels.Add(new LabelData() { Label = "", Width = "50px" });
            GeoFactory gf = new GeoFactory();
            foreach (MPeopleevent pe in data)
            {
                List<string> lst = new List<string>();
                string prefixd = pe.DayFrom < 10 ? "0" : "";
                string prefixm = pe.MonthFrom < 10 ? "0" : "";

                lst.Add($"{prefixd}{pe.DayFrom}-{prefixm}{pe.MonthFrom}-{pe.YearFrom}");
                string place = pe.PlaceEvent == null ? string.Empty : gf.GetDisplayPlaceEvent((int)pe.PlaceEvent);
                lst.Add(place);
                lst.Add(pe.CategoryDescription);
                lst.Add($"{Constants.MarkerEdit}:{pe.Idevent}");
                lst.Add($"{Constants.MarkerDelete}:{pe.Idevent}");

                Eventstable.Data.Add(lst);
            }
        }
    }
}
