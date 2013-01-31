using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;

namespace Herz.Estimator
{
    public class Segment
    {
        public double StartTime { get; set; }
        public double EndTime { get; set; }
        public bool IsBaseline { get; set; }
        public int Index { get; set; }

        private int signalSampleRate = 0;

        public Segment(double startTime, double endTime, int index, int signalSampleRate, bool isBaseline = false) 
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Index = index;
            this.signalSampleRate = signalSampleRate;
            this.IsBaseline = isBaseline;
        }

        public int StartTimeToIndex() 
        {
            return (int)(StartTime * signalSampleRate);
        }

        public int EndTimeToIndex()
        {
            return (int)(EndTime * signalSampleRate) - 1;
        }
    }
}
