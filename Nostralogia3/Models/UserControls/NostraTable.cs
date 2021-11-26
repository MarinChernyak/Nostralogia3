using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls
{
    public class NostraTable
    {
        public string TableLabel { get; set; }
        public List<string> Labels { get; set; }
        public List<List<string>> Data { get; set; }

        protected int index { get; }
        public NostraTable(string label)
        {
            TableLabel = label;
            index = Constants.Counter; ;
        }
        public string GetTbleId()
        {
            return $"tblNostra{index}"; 
        }
        public string ExpandCollapsAreaId()
        {
            return $"ExpCollapxe{index}";
        }
    }
}
