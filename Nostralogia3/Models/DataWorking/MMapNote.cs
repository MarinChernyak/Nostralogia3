using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.DataWorking
{
    public class MMapNote
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public int? IdContributor { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
