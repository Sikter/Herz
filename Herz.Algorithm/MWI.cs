using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;

namespace Herz.Algorithm
{
    public class MWI : IFilter<ECGSample>
    {
        List<double> elements = new List<double>(46);

        public MWI() 
        {
            for (int i = 0; i < 46; i++)
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

            for (int i = 0; i < 46; i++)
                result += elements[i];

            sample.Value = result;
        }

        public int GetDelay()
        {
            return elements.Capacity / 2;
        }
    }
}
