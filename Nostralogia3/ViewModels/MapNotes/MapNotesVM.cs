using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
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
            List<MMapNote> lstnotes = PersonalDataFactory.GetMapNotes(IdRef);
            foreach(MMapNote item in lstnotes)
            {
                SingleMapNoteVM model = new SingleMapNoteVM()
                {
                    MapNote = item
                };
                _NotesDataList.Add(model);
            }
        }

    }
}
