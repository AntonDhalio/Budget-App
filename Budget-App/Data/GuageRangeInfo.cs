﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_App.Data
{
    public class GaugeRangeInfo
    {
        public string Name { get; set; }
        public string Brush { get; set; }
        public string Outline { get; set; }
        public double StartValue { get; set; }
        public double EndValue { get; set; }
        public double InnerStartExtent { get; set; }
        public double InnerEndExtent { get; set; }
        public double OuterStartExtent { get; set; }
        public double OuterEndExtent { get; set; }
    }
}
