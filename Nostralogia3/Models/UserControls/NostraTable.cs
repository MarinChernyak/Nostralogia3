using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls
{
    public class LabelData
    {
        public string Label { get; set; }
        public string Width { get; set; }
    }
    public class NostraTable
    {
        //public string TableWidth { get; set; }
        public string TableLabel { get; set; }
        public List<LabelData> Labels { get; set; } = new();
        public List<List<string>> Data { get; set; } = new();

        public bool Expanded { get; set; }
        public string GetclassExpanded() { return Expanded ? "collapse.show" : "collapse"; }

        protected int index { get; }
        public NostraTable(string label,/*string width="auto",*/ bool collapsed=true)
        {
            //TableWidth = width;
            TableLabel = label;
            index = Constants.Counter;
            Expanded = !collapsed;
        }
        public string GetTbleId()
        {
            return $"tblNostra{index}"; 
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
