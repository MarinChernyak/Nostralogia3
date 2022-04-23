using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Datatype
    {
        public Datatype()
        {
            People = new HashSet<Person>();
            Worldevents = new HashSet<Worldevent>();
        }

        public byte Idtype { get; set; }
        public string Adv { get; set; }
        public string AdvAppl { get; set; }
        public string DataType1 { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Worldevent> Worldevents { get; set; }
    }
}
