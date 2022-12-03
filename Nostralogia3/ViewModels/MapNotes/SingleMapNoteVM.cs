using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels.MapNotes
{
    public class SingleMapNoteVM : MapNoteBase
    {
        public SingleMapNoteVM() { }
        public SingleMapNoteVM(ISession session )
        {
            _session = session;

        }
        public SingleMapNoteVM(ISession session, int id, string snote)
        {
            _session = session;
            MapNote.Note = snote;
            MapNote.Id = id;
        }
        public string GetId() { return $"SMapNote{_Index}"; }
        public string GetDevEditId() { return $"dvEditNotes{_Index}"; }
        public string GetDevViewId() { return $"dvViewNotes{_Index}"; }
        public string GetBtnEditId() { return $"btnEdit{_Index}"; }
        public string GetBtnSaveId() { return $"btnSave{_Index}"; }
        public string GetBtnCancelId() { return $"btnCancel{_Index}"; }
        public string GetExpanderId() { return $"btnExpander{_Index}"; }
        public string GetCollapserId() { return $"btnCollapser{_Index}"; }
        public string GetdvMapNoteId() { return $"dvMapNote{_Index}"; }
        public string GetDeactivateId() { return $"btnDeactivate{_Index}"; }
        public string GetActivateId() { return $"btnActivate{_Index}"; }
        public string GetDeleteId() { return $"btnDelete{_Index}"; }
        public string GetDate()
        {
            return $"{MapNote.Date.Day}/{MapNote.Date.Month}/{MapNote.Date.Year}";
        }
    }
}
