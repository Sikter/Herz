using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;

namespace Herz.Algorithm
{
    public class Delay : IFilter<ECGSample>
    {
        private int sampleDelay;

        public Delay(int delay) 
        {
            sampleDelay = delay;
        }

        public IEnumerable<ECGSample> Execute(IEnumerable<ECGSample> input)
        {
            foreach (ECGSample sample in input)
                sample.Index -= sampleDelay;

            return input;
        }

        public int GetDelay()
        {
            return 0;
        }
    }
}
