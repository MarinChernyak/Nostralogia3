using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Geo;
using Nostralogia3.Models.Helpers;
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
        public bool CanDelete { get; set; }
        

        //public NewPersonalEventModal NewPersonalEventModal { get; set; } = new();
        public PersonalEventsCollectionModel(string label, ISession session)
            :base(label, session,false)
        {
            _session = session;
            Label = label;
            InitCollection();

        }
        public PersonalEventsCollectionModel(int personId, string label, ISession session)
            :base(label, session,false)
        {
            _session = session;
            Label = label;
            Idperson = personId;
            InitCollection();
            

        }
        public int GetRights(int eventId)
        {
            int rights = 0;
            if (UserId > 0)
            {
                rights = UsersFactory.GetUserRightsForPersonalEvent(UserId, eventId);
            }
            return rights;
        }
        protected void InitCollection()
        { 
            EventsCollection = EventsDataFactory.GetPersonalEventslList(Idperson);
            Labels = new List<LabelData>();
            Labels.Add(new LabelData() { Label="Date From",Width= "200px" });
            Labels.Add(new LabelData() { Label = "Place", Width = "200px" });
            Labels.Add(new LabelData() { Label = "Category", Width = "300px" });
            Labels.Add(new LabelData() { Label = "", Width = "50px" });
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
                int rights = GetRights(pe.Idevent);
                if ((rights & Constants.Values.CAN_DELETE) > 0)
                {
                    lst.Add($"{Constants.Values.MarkerDelete}:{"PersonalEvent"}|{"DeleteEvent"}|{pe.Idevent}");
                }
                else
                {
                    lst.Add("");
                }

                Data.Add(lst);
            }
        }
    }
}
