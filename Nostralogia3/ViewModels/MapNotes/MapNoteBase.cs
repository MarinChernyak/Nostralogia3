using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels.MapNotes
{
    public class MapNoteBase : ViewModelBase
    {
        public MMapNote MapNote { get; set; } = new MMapNote();
        public MapNoteBase() { }
        public MapNoteBase(int idRef)
        {
            MapNote.IdPerson=idRef;

        }
        public async Task<bool> SaveNewNote()
        {
            MapNote.Id = await PersonalDataFactory.CreaNewMapNote(MapNote.IdPerson, MapNote.Note, GetUID());
            return MapNote.Id > 0;
        }
    }
}
