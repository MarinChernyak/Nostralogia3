using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class MapNote
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public int? IdContributor { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual Person IdPersonNavigation { get; set; }
    }
}
