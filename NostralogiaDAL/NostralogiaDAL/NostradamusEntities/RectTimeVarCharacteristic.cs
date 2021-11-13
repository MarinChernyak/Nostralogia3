using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class RectTimeVarCharacteristic
    {
        public RectTimeVarCharacteristic()
        {
            RectTimeVariants = new HashSet<RectTimeVariant>();
        }

        public byte Id { get; set; }
        public byte Value { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RectTimeVariant> RectTimeVariants { get; set; }
    }
}
