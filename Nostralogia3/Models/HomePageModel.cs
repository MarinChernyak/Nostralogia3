using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.Authentication;
using Nostralogia3.Models.Events;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Persons;
using Nostralogia3.Models.UserControls;
using Nostralogia3.Models.UserControls.Tables;
using Nostralogia3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models
{
    public class HomePageModel :ViewModelBase
    { 


        public HomePeopleTable PeopleTable { get; protected set; }
        public NostraTable EventTable { get; protected set; }
        public bool ReadOnly { get; }
        public HomePageModel(ISession session)
        {
            _session = session;
            
            //ReadOnly = level>

            PeopleTable = new HomePeopleTable("Last 10 people added", session,false);
            EventTable = new WorldEventsTable("Last 10 world events added", session);
        }

    }
}
