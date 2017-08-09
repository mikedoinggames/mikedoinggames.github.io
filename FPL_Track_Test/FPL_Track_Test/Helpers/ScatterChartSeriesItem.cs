using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPL_Track_Test.Helpers
{
    public class ScatterChartSeriesItem
    {
        public float x;
        public float y;
        public string color;
        public int radius;
        public string symbol;
        public string name;
        public string key;
        public Dictionary<string,string> marker;

        public void addMarkerOption(string key, string value)
        {
            marker[key] = value;
        }
    }
}