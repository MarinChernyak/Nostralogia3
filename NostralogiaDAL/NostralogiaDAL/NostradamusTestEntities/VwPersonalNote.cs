using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class VwPersonalNote
    {
        public int IdPerson { get; set; }
        public string Note { get; set; }
        public DateTime DateCreation { get; set; }
        public string UserName { get; set; }
        public int Id { get; set; }
        public int? IdContributor { get; set; }
    }
}
