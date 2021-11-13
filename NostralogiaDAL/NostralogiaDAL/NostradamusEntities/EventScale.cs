using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class EventScale
    {
        public EventScale()
        {
            EventScaleVals = new HashSet<EventScaleVal>();
        }

        public byte Id { get; set; }
        public string ScaleName { get; set; }
        public string ScaleDescr { get; set; }
        public short KkindEvent { get; set; }
        public string Sc1 { get; set; }
        public string Descr1 { get; set; }
        public string Sc2 { get; set; }
        public string Descr2 { get; set; }
        public string Sc3 { get; set; }
        public string Descr3 { get; set; }
        public string Sc4 { get; set; }
        public string Descr4 { get; set; }
        public string Sc5 { get; set; }
        public string Descr5 { get; set; }
        public string Sc6 { get; set; }
        public string Descr6 { get; set; }
        public string Sc7 { get; set; }
        public string Descr7 { get; set; }
        public string Sc8 { get; set; }
        public string Descr8 { get; set; }
        public string Sc9 { get; set; }
        public string Descr9 { get; set; }
        public string Sc10 { get; set; }
        public string Descr10 { get; set; }

        public virtual KeyWord1 KkindEventNavigation { get; set; }
        public virtual ICollection<EventScaleVal> EventScaleVals { get; set; }
    }
}
