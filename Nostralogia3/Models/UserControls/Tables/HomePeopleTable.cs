using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls.Tables
{
    public class HomePeopleTable : NostraTable
    {
        protected List<MVwPersonalDisplayDatum> People { get; set; }
        private const int NumberRecords = 10; 
        public HomePeopleTable(string label, ISession session,  bool collapsed = true)
            :base( label, session, collapsed )
        {

            InitData();
            InitLabels();
            InitOutDataList();
        }
        protected void InitData()
        {
            People = PersonalDataFactory.GetPersonalDisplayDataList(NumberRecords);
        }
        protected void InitLabels()
        {
            Labels = new List<LabelData>()
            { new LabelData()
                {
                    Label="Name",
                    Width="150px"
                },
                new LabelData()
                {
                    Label = "DOB",
                    Width = "120px"
                },
                new LabelData()
                {
                    Label = "Birth place",
                    Width = "150px"
                },
                new LabelData()
                {
                    Label = "Events",
                    Width = "70px"
                },
                new LabelData()
                {
                    Label = "Keywords",
                    Width = "70px"
                },
                new LabelData()
                {
                    Label = "Pictures",
                    Width = "70px"
                },
                new LabelData()
                {
                    Label = "",
                    Width = "50px"
                },
                new LabelData()
                {
                    Label = "",
                    Width = "50px"
                }
            };
        }
        protected void InitOutDataList()
        {
            Data = new List<List<string>>();
            foreach (var p in People)
            {
         
                List<string> lst = new List<string>();
                lst.Add($"{p.SecondName} {p.FirstName.Substring(0, 1)}.");
                lst.Add($"{p.BirthDay}-{p.BirthMonth}-{p.BirthYear}");
                lst.Add($"{p.CityName} ({p.CountryAcronym})");
                lst.Add(p.NumEvents.ToString());
                lst.Add(p.NumKw.ToString());
                lst.Add(p.NumPictures.ToString());
                lst.Add($"{Constants.Values.MarkerEdit}:DataWorking|EditPersonalData|{p.Id}");
                int rights = GetRights(p.Id);
                if ((rights & Constants.Values.CAN_DELETE) > 0)
                {
                    lst.Add($"{Constants.Values.MarkerDelete}:DataWorking|DeletePersonalData|{p.Id}");
                }
                else
                {
                    lst.Add("");
                }
                Data.Add(lst);
            }
        }
        public int GetRights(int personId)
        {
            int rights = 0;
            if (UserId > 0)
            {
                rights = UsersFactory.GetUserRightData(UserId, personId);
            }
            return rights;
        }
    }
}
