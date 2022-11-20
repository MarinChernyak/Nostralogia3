using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class CharacteristicsDisaster
    {
        public int Id { get; set; }
        public int IdEvent { get; set; }
        public int WictimsNumber { get; set; }
        public int SurviversNumber { get; set; }
        public double Damage { get; set; }
        public byte PotentialSeverity { get; set; }
        public byte ImpactRelatedSectors { get; set; }

        public virtual Worldevent IdEventNavigation { get; set; }
        public virtual ImpactRelatedSector ImpactRelatedSectorsNavigation { get; set; }
        public virtual PotentialSeverity PotentialSeverityNavigation { get; set; }
    }
}
