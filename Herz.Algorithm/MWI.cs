using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;

namespace Herz.Algorithm
{
    public class MWI : IFilter<ECGSample>
    {
        List<double> elements = new List<double>(5);

        public MWI() 
        {
            for (int i = 0; i < 80; i++)
                elements.Add(0);
        }

        public IEnumerable<ECGSample> Execute(IEnumerable<ECGSample> input)
        {
            foreach (ECGSample sample in input)
            {
                Integrate(sample);
            }
            return input;
        }

        private void Integrate(ECGSample sample)
        {
            double result = 0;

            if (elements.Capacity >= elements.Count)
                elements.RemoveAt(0);
            elements.Add(sample.Value);

            for (int i = 0; i < 80; i++)
                result += elements[i];

            sample.Value = result;
        }
    }
}
