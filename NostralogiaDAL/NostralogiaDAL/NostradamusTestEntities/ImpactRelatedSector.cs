using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class ImpactRelatedSector
    {
        public ImpactRelatedSector()
        {
            CharacteristicsDisasters = new HashSet<CharacteristicsDisaster>();
        }

        public byte Id { get; set; }
        public string Impact { get; set; }
        public string ImpactDescr { get; set; }
        public string Details { get; set; }
        public string DetailsDescr { get; set; }

        public virtual ICollection<CharacteristicsDisaster> CharacteristicsDisasters { get; set; }
    }
}
