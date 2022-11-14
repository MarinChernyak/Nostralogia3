using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class EventHistorScale
    {
        public EventHistorScale()
        {
            EventHistorScaleVals = new HashSet<EventHistorScaleVal>();
        }

        public short Id { get; set; }
        public short KindEvent { get; set; }
        public string ScaleName { get; set; }
        public string DescrScale { get; set; }
        public int Sc0 { get; set; }
        public string Descr0 { get; set; }
        public int Sc1 { get; set; }
        public string Descr1 { get; set; }
        public int Sc2 { get; set; }
        public string Descr2 { get; set; }
        public int Sc3 { get; set; }
        public string Descr3 { get; set; }
        public int Sc4 { get; set; }
        public string Descr4 { get; set; }
        public int Sc5 { get; set; }
        public string Descr5 { get; set; }
        public int Sc6 { get; set; }
        public string Descr6 { get; set; }
        public int Sc7 { get; set; }
        public string Descr7 { get; set; }
        public int Sc8 { get; set; }
        public string Descr8 { get; set; }
        public int Sc9 { get; set; }
        public string Descr9 { get; set; }
        public int Sc10 { get; set; }
        public string Descr10 { get; set; }

        public virtual KeyWord1 KindEventNavigation { get; set; }
        public virtual ICollection<EventHistorScaleVal> EventHistorScaleVals { get; set; }
    }
}
