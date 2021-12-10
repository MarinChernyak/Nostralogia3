using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.DataWorking
{
    public class MSource
    {
        public MSource()
        {
        }

        public byte Idsource { get; set; }
        //public string IdsSource { get; set; }
        public string SourceDescription { get; set; }
        //public string IdsComments { get; set; }
        public string CommentDescription { get; set; }
    }
}
