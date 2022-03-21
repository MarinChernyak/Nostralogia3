using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.Events;
using Nostralogia3.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls.Tables
{
    public class WorldEventsTable : NostraTable
    {
        public List<MVwWorldEvent> Events { get; protected set; }
        public WorldEventsTable(string label, ISession session)
            :base(label,session)
        {
            InitData();
            InitLabels();
            InitOutDataList();
        }
        protected int GetRights(int eventId)
        {
            int rights = 0;
            if (UserId > 0)
            {
                rights = WorldEventsFactory.GetUserRightData(UserId, eventId);
            }
            return rights;
        }
        protected void InitData()
        {
            Events = EventsDataFactory.GetEventslDisplayDataList();
        }
        protected void InitLabels()
        {
            int UserLevel = Convert.ToInt32(_session.GetString(Constants.SessionCoockies.SessionULevel));
            Labels = new List<LabelData>()
            { new LabelData()
                {
                    Label="Event Name",
                    Width="300px"
                },
                new LabelData()
                {
                    Label="Date",
                    Width="150px"
                },
                new LabelData()
                {
                    Label="Impact",
                    Width="150px"
                },
                new LabelData()
                {
                    Label="",
                    Width="50px"
                }
            };
        }

        protected void InitOutDataList()
        { 
            Data = new List<List<string>>();
            foreach (var e in Events)
            {
                if (UserLevel >= e.EventsDataType)
                {
                    List<string> lst = new List<string>();
                    Data.Add(new List<string>()
                    {
                        e.EventName,
                        $"{e.EventsDayFrom}-{e.EventsMonthFrom}-{e.EventsYearFrom}",
                        e.Impact,
                        e.UserName
                    });
                    int rights = GetRights(e.Id);
                    if ((rights & Constants.Values.CAN_DELETE) > 0)
                    {
                        lst.Add($"{Constants.Values.MarkerDelete}:DataWorking|DeletePersonalData|{e.Id}");
                    }
                    else
                    {
                        lst.Add("");
                    }
                }
            }
        }
    }
}
