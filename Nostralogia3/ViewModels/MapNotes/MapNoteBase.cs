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
        public MapNoteBase(int id, int idRef)
        {
            MapNote.Id = id;
            
            MapNote.IdPerson = idRef;
            if (id > 0)
            {
                GetNote();
            }
        }
        public async Task<bool> SaveNote()
        {
            if(MapNote.Id==0)
            {
                return await SaveNewNote();
            }
            else
            {
                return await UpdateNote();
            }
        }
        protected void GetNote()
        {
            MMapNote note = PersonalDataFactory.GetNote(MapNote.Id);
            if(note!=null)
            {
                MapNote=note;
            }
        }
        public async Task<bool> SaveNewNote()
        {
            MapNote.Id = await PersonalDataFactory.CreaNewMapNote(MapNote.IdPerson, MapNote.Note, GetUID());
            return MapNote.Id > 0;
        }
        public async Task<bool> UpdateNote()
        {
            return await PersonalDataFactory.UpdatewMapNote(MapNote.Id, MapNote.Note, GetUID());
           
        }
    }
}
