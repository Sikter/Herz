using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;

namespace Herz.Estimator
{
    public static class FeatureCalc
    {
        public static double MeanX(List<ECGSample> rrPeaks)
        {
            double sum = 0;
            foreach (ECGSample s in rrPeaks)
            {
                sum += s.Value;
            }

            return sum / rrPeaks.Count;
        }

        public static double StdX(List<ECGSample> rrPeaks, double meanX) 
        {
            double sum = 0;
            foreach (ECGSample s in rrPeaks) 
            {
                sum += Math.Pow((s.Value - meanX), 2);
            }

            sum = sum / (rrPeaks.Count - 1);

            return Math.Sqrt(sum);
        }

        public static double MinX(List<ECGSample> rrPeaks)
        {
            return rrPeaks.Min(x => x.Value);
        }

        public static double MaxX(List<ECGSample> rrPeaks)
        {
            return rrPeaks.Max(x => x.Value);
        }
    }
}
