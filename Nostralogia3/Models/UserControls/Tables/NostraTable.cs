using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls
{

    public class NostraTable : NostraTableBase
    {
        //public string TableWidth { get; set; }
        public string TableLabel { get; set; }

        public bool Expanded { get; set; }
        public string GetclassExpanded() { return Expanded ? "collapse.show" : "collapse"; }

        
        public NostraTable(string label, bool collapsed=true)
        {
            TableLabel = label;
            
            Expanded = !collapsed;
        }

        public string ExpandCollapsAreaId()
        {
            return $"ExpCollapxe{index}";
        }
        public string ExpanderId()
        {
            return $"Expander{index}";
        }
    }
}
