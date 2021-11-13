using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class PotentialSeverity
    {
        public PotentialSeverity()
        {
            CharacteristicsDisasters = new HashSet<CharacteristicsDisaster>();
        }

        public byte Id { get; set; }
        public string Severity { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CharacteristicsDisaster> CharacteristicsDisasters { get; set; }
    }
}
