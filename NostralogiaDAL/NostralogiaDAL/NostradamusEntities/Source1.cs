using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Source1
    {
        public Source1()
        {
            Worldevents = new HashSet<Worldevent>();
        }

        public byte Id { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public byte Rating { get; set; }

        public virtual ICollection<Worldevent> Worldevents { get; set; }
    }
}
