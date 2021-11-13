using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class VwRelative
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int IdRelative { get; set; }
        public string FirstNameRelative { get; set; }
        public string LastNameRelative { get; set; }
        public byte Idrelationship { get; set; }
        public string AdvRelationship { get; set; }
        public string DescriptionRelationship { get; set; }
    }
}
