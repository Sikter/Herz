using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;

namespace Herz.Algorithm
{
    public class LowPassFilter : IFilter<ECGSample>
    {
        private List<double> elements = new List<double>(61);
        private List<double> cf = new List<double>(61);

        public LowPassFilter() 
        {
            for (int i = 0; i <= 60; i++) 
            {
                elements.Add(0);
            }
            AddCoefficients();
        }

        public IEnumerable<ECGSample> Execute(IEnumerable<ECGSample> input)
        {
            foreach (ECGSample sample in input)
            {
                LowPass(sample);
            }
            return input;
        }

        private void LowPass(ECGSample sample)
        {
            double result = 0;

            if (elements.Capacity >= elements.Count)
                elements.RemoveAt(0);
            elements.Add(sample.Value);

            for (int i = 60; i >= 0; i--) 
            {
                result += elements[i] * cf[60 - i];
            }

            sample.Value = result;
        }

        private void AddCoefficients()
        {
            cf.Add(3.359626918191212e-006);
            cf.Add(1.174538201448818e-005);
            cf.Add(2.751129270325192e-005);
            cf.Add(5.408436863137363e-005);
            cf.Add(9.565996022636052e-005);
            cf.Add(0.000157173626742541);
            cf.Add(0.0002442152730204958);
            cf.Add(0.0003628800019486373);
            cf.Add(0.0005195540155452326);
            cf.Add(0.0007206384832557158);
            cf.Add(0.0009722192897158698);
            cf.Add(0.001279695617407989);
            cf.Add(0.001647385012397174);
            cf.Add(0.002078126513336501);
            cf.Add(0.00257290620892021);
            cf.Add(0.003130530899767552);
            cf.Add(0.003747375141565446);
            cf.Add(0.004417224719387483);
            cf.Add(0.005131235566688701);
            cf.Add(0.005878021458320244);
            cf.Add(0.006643876775944007);
            cf.Add(0.007413132690125003);
            cf.Add(0.008168636744935441);
            cf.Add(0.008892337645154571);
            cf.Add(0.009565949625002318);
            cf.Add(0.01017166468126628);
            cf.Add(0.01069287666627227);
            cf.Add(0.0111148791235626);
            cf.Add(0.01142549902791992);
            cf.Add(0.0116156313076346);
            cf.Add(0.01167964404894326);
            cf.Add(0.0116156313076346);
            cf.Add(0.01142549902791992);
            cf.Add(0.0111148791235626);
            cf.Add(0.01069287666627227);
            cf.Add(0.01017166468126628);
            cf.Add(0.009565949625002318);
            cf.Add(0.008892337645154571);
            cf.Add(0.008168636744935441);
            cf.Add(0.007413132690125003);
            cf.Add(0.006643876775944007);
            cf.Add(0.005878021458320244);
            cf.Add(0.005131235566688701);
            cf.Add(0.004417224719387483);
            cf.Add(0.003747375141565446);
            cf.Add(0.003130530899767552);
            cf.Add(0.00257290620892021);
            cf.Add(0.002078126513336501);
            cf.Add(0.001647385012397174);
            cf.Add(0.001279695617407989);
            cf.Add(0.0009722192897158698);
            cf.Add(0.0007206384832557158);
            cf.Add(0.0005195540155452326);
            cf.Add(0.0003628800019486373);
            cf.Add(0.0002442152730204958);
            cf.Add(0.000157173626742541);
            cf.Add(9.565996022636052e-005);
            cf.Add(5.408436863137363e-005);
            cf.Add(2.751129270325192e-005);
            cf.Add(1.174538201448818e-005);
            cf.Add(3.359626918191212e-006);
            
        }
    }
}
