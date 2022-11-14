using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Helpers;
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
            string userlevel = SessionHelper.GetObjectFromJson(_session, Constants.SessionCoockies.SessionULevel);
            int iulevel = 1;
            if(!string.IsNullOrEmpty(userlevel))
            {
                iulevel = Convert.ToInt32(userlevel);
            }
            People = PersonalDataFactory.GetPersonalDisplayDataList(NumberRecords, iulevel);
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
            string suid = _session.GetString(Constants.SessionCoockies.SessionUID);
            //string level = _session.GetString(Constants.SessionCoockies.SessionULevel);
            int uid;
            int.TryParse(suid, out uid);
            Data = new List<List<string>>();
            int user_rights = GetRights(uid);
            foreach (var p in People)
            {
                if ((user_rights & Constants.Values.CAN_VIEW)>0)
                {
                    List<string> lst = new List<string>();
                    lst.Add($"{p.SecondName} {p.FirstName.Substring(0, 1)}.");
                    lst.Add($"{p.BirthDay}-{p.BirthMonth}-{p.BirthYear}");
                    lst.Add($"{p.CityName} ({p.CountryAcronym})");
                    lst.Add(p.NumEvents.ToString());
                    lst.Add(p.NumKw.ToString());
                    lst.Add(p.NumPictures.ToString());



                    if ((user_rights & Constants.Values.CAN_EDIT) > 0)
                    {
                        lst.Add($"{Constants.Values.MarkerEdit}:DataWorking|EditPersonalData|{p.Id}");
                    }
                    else
                    {
                        lst.Add("");
                    }
                    if ((user_rights & Constants.Values.CAN_DELETE) > 0)
                    {
                        lst.Add($"{Constants.Values.MarkerDelete}:DataWorking|DeletePersonalData|{p.Id}");
                    }
                    if ((user_rights & Constants.Values.CAN_DEACTIVATE) > 0)
                    {
                        lst.Add($"{Constants.Values.MarkerDeactivate}:DataWorking|DeactivatePersonalData|{p.Id}");
                    }
                    else
                    {
                        lst.Add("");
                    }
                    Data.Add(lst);
                }
            }
        }
        public int GetRights(int personId)
        {
            int rights = Constants.DataTypes.DataPublic;
            if (UserId > 0)
            {
                rights = UsersFactory.GetUserRightData(UserId, personId);
            }
            return rights;
        }
    }
}
