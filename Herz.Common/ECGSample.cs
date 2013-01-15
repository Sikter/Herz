using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herz.Common
{
    /// <summary>
    /// One ECG signal sample. 
    /// Consists of index of the sample in the signal and the amplitude value of sample.
    /// </summary>
    public class ECGSample
    {
        /// <summary>
        /// Index of sample
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Value (amplitude) of sample
        /// </summary>
        public double Value { get; set; }

        public ECGSample(int ind, double val) 
        {
            Index = ind;
            Value = val;
        }
    }
}
