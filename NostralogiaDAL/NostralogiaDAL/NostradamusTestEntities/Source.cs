using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Source
    {
        public Source()
        {
            RectTimeVariants = new HashSet<RectTimeVariant>();
        }

        public byte Idsource { get; set; }
        public string IdsSource { get; set; }
        public string SourceDescription { get; set; }
        public string IdsComments { get; set; }
        public string CommentDescription { get; set; }

        public virtual ICollection<RectTimeVariant> RectTimeVariants { get; set; }
    }
}
