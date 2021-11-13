using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Peoplekeywordsstore
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public short KeyWord { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual Person IdPersonNavigation { get; set; }
        public virtual Keyword KeyWordNavigation { get; set; }
    }
}
