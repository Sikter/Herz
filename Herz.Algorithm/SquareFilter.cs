using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;

namespace Herz.Algorithm
{
    public class SquareFilter : IFilter<ECGSample>
    {
        public IEnumerable<ECGSample> Execute(IEnumerable<ECGSample> input)
        {
            foreach (ECGSample s in input) 
            {
                s.Value = s.Value * s.Value;
            }
            return input;
        }
    }
}
