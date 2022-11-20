using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Relative
    {
        public int IdPerson1 { get; set; }
        public int IdPerson2 { get; set; }
        public byte Relationship { get; set; }
    }
}
