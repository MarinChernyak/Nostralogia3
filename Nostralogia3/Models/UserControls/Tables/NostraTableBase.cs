﻿using System;
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
    public class NostraTableBase
    {
        public List<LabelData> Labels { get; set; } = new();
        public List<List<string>> Data { get; set; } = new();

        protected int index { get; }
        public NostraTableBase()
        {
            index = Constants.Counter;
        }
        public string GetTbleId()
        {
            return $"tblNostra{index}";
        }
    }
}
