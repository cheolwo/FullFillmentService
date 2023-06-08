using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaverCommon.Direction
{

    public class RootObject
    {
        public int code { get; set; }
        public string message { get; set; }
        public DateTime currentDateTime { get; set; }
        public Route route { get; set; }
    }

    public class Route
    {
        public Traoptimal[] traoptimal { get; set; }
    }

    public class Traoptimal
    {
        public Summary summary { get; set; }
        public float[][] path { get; set; }
        public Section[] section { get; set; }
        public Guide[] guide { get; set; }
    }

    public class Summary
    {
        public Start start { get; set; }
        public Goal goal { get; set; }
        public int distance { get; set; }
        public int duration { get; set; }
        public int etaServiceType { get; set; }
        public DateTime departureTime { get; set; }
        public float[][] bbox { get; set; }
        public int tollFare { get; set; }
        public int taxiFare { get; set; }
        public int fuelPrice { get; set; }
    }

    public class Start
    {
        public float[] location { get; set; }
    }

    public class Goal
    {
        public float[] location { get; set; }
        public int dir { get; set; }
    }

    public class Section
    {
        public int pointIndex { get; set; }
        public int pointCount { get; set; }
        public int distance { get; set; }
        public string name { get; set; }
        public int congestion { get; set; }
        public int speed { get; set; }
    }

    public class Guide
    {
        public int pointIndex { get; set; }
        public int type { get; set; }
        public string instructions { get; set; }
        public int distance { get; set; }
        public int duration { get; set; }
    }

}
