using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;

namespace Herz.Estimator
{
    public class Estimator
    {
        public int SampleRate { get; set; }
        public List<Segment> Segments { get; set; }
        public List<ECGSample> RRPeaks { get; set; }

        public Estimator(List<double> startTimes, List<double> endTimes, int sampleRate) 
        {
            Segments = new List<Segment>();
            RRPeaks = new List<ECGSample>();

            foreach (double start in startTimes) 
            {
                // If first entry in startTimes list than that segment is baseline
                if(startTimes.IndexOf(start) == 0)
                    Segments.Add(new Segment(start, endTimes[startTimes.IndexOf(start)], 
                                             startTimes.IndexOf(start), sampleRate, true));
                // else, it's regular segment
                else
                    Segments.Add(new Segment(start, endTimes[startTimes.IndexOf(start)],
                                             startTimes.IndexOf(start), sampleRate));
            }
        }

        private List<ECGSample> GetPeaks(int segmentIndex)
        {
            int startIndex = Segments[segmentIndex].StartTimeToIndex();
            int endIndex = Segments[segmentIndex].EndTimeToIndex();

            return RRPeaks.Where(x => x.Index >= startIndex &&
                                      x.Index < endIndex).ToList();
        }

        public double CalcMeanX(int segmentIndex) 
        {
            List<ECGSample> peaks = GetPeaks(segmentIndex);
            if (peaks.Count > 0)
                return FeatureCalc.MeanX(peaks);
            else
                return 0;
        }

        public double CalcStdX(int segmentIndex)
        {
            List<ECGSample> peaks = GetPeaks(segmentIndex);
            double meanX = CalcMeanX(segmentIndex);

            if (peaks.Count > 0)
                return FeatureCalc.StdX(peaks, meanX);
            else
                return 0;
        }

        public double CalcMinX(int segmentIndex) 
        {
            List<ECGSample> peaks = GetPeaks(segmentIndex);
            if (peaks.Count > 0)
                return FeatureCalc.MinX(peaks);
            else
                return 0;
        }

        public double CalcMaxX(int segmentIndex)
        {
            List<ECGSample> peaks = GetPeaks(segmentIndex);
            if (peaks.Count > 0)
                return FeatureCalc.MaxX(peaks);
            else
                return 0;
        }

        public double CalcDiffMMX(int segmentIndex) 
        {
            return CalcMaxX(segmentIndex) - CalcMinX(segmentIndex);
        }

        public double CalcMeanAbsFD(int segmentIndex)
        {
            List<ECGSample> peaks = GetPeaks(segmentIndex);
            double sum = 0;

            if (peaks.Count > 0)
            {
                for (int i = 0; i < peaks.Count - 1; i++)
                    sum += Math.Abs(peaks[i + 1].Value - peaks[i].Value);

                return sum / (peaks.Count - 1);
            }
            else
                return 0;
        }

        public double CalcMeanAbsFD2(int segmentIndex)
        {
            List<ECGSample> peaks = GetPeaks(segmentIndex);
            double sum = 0;

            if (peaks.Count > 0)
            {
                for (int i = 0; i < peaks.Count - 2; i++)
                    sum += Math.Abs(peaks[i + 2].Value - peaks[i].Value);

                return sum / (peaks.Count - 2);
            }
            else
                return 0;
        }


       
    }
}
