using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Keyword
    {
        public Keyword()
        {
            InverseReference = new HashSet<Keyword>();
            Peoplekeywordsstores = new HashSet<Peoplekeywordsstore>();
        }

        public short Idkw { get; set; }
        public short? ReferenceId { get; set; }
        public byte AccessLevel { get; set; }
        public string AdvKeyWord { get; set; }
        public string KeyWordDescription { get; set; }

        public virtual Keyword Reference { get; set; }
        public virtual ICollection<Keyword> InverseReference { get; set; }
        public virtual ICollection<Peoplekeywordsstore> Peoplekeywordsstores { get; set; }
    }
}
