using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;

namespace Herz.Algorithm
{
    public class DerivativeFilter : IFilter<ECGSample>
    {
        List<double> elements = new List<double>(5);
        List<double> cf = new List<double>(5);

        public DerivativeFilter() 
        {
            for (int i = 0; i < 5; i++) 
                elements.Add(0);

            // Set coefficient list.
            cf.Add(2);
            cf.Add(1);
            cf.Add(0);
            cf.Add(-1);
            cf.Add(-2);
        }

        public IEnumerable<ECGSample> Execute(IEnumerable<ECGSample> input)
        {
            foreach (ECGSample sample in input) 
                Derivate(sample);

            return input;
        }

        private void Derivate(ECGSample sample)
        {
            double result = 0;

            if (elements.Capacity >= elements.Count)
                elements.RemoveAt(0);
            elements.Add(sample.Value);

            for (int i = 4; i >= 0; i--)
            {
                result += elements[i] * cf[4 - i];
            }

            sample.Value = result;
        }


        public int GetDelay()
        {
            return (elements.Capacity - 1) / 2;
        }
    }
}
