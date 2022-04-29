using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels.MapNotes
{
    public class MapNotesVM : ViewModelBase
    {
        public List<SingleMapNoteVM> _NotesDataList { get; set; } = new();
        public int IdRef { get; set; }
        public string NewNote { get; set; }
        public MapNotesVM()
        {

        }
        public MapNotesVM(ISession session, int idRef)
        {
            _session = session;
            IdRef = idRef;
            InitCollection();
        }
        protected void InitCollection()
        {
            string sulevel = SessionHelper.GetObjectFromJson(_session, Constants.SessionCoockies.SessionULevel);

            int userlevel = 0;
            if(!string.IsNullOrEmpty(sulevel))
            {
                userlevel = Convert.ToInt32(sulevel);
            }
            
            List<MMapNote> lstnotes = PersonalDataFactory.GetMapNotes(IdRef, userlevel);
            foreach(MMapNote item in lstnotes)
            {
                SingleMapNoteVM model = new SingleMapNoteVM(_session)
                {
                    MapNote = item
                };
                _NotesDataList.Add(model);
            }
        }

    }
}
