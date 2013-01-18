using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;

namespace Herz.Algorithm
{
    public class Detector : IFilter<ECGSample>
    {
        private List<ECGSample> samples = new List<ECGSample>();
        private int sampleFrequency;

        private double PEAK = 0;
        private double SPKI = 0;
        private double NPKI = 0;
        private double RRAVERAGE1;
        private double RRAVERAGE2;
        private double RR_LOW_LIMIT;
        private double RR_HIGH_LIMIT;
        private double RR_MISSED_LIMIT;
        private double TRESHOLD1 = 0;
        private double TRESHOLD2 = 0;
        private int lastQRS = 0;

        //private bool initializationComplete = false;

        public List<ECGSample> RR { get; set; }
        public List<ECGSample> RR2 { get; set; }

        List<ECGSample> newlyDetected = new List<ECGSample>();

        public Detector(int frequency) 
        {
            RR = new List<ECGSample>();
            RR2 = new List<ECGSample>();
            samples.Add(new ECGSample(625, 0.0674857247903559));
            samples.Add(new ECGSample(1525, 0.068899481733875584));
            samples.Add(new ECGSample(2497, 0.069719186260481819));
            samples.Add(new ECGSample(3531, 0.0758428563792688));
            samples.Add(new ECGSample(4520, 0.066008737954933228));
            samples.Add(new ECGSample(5493, 0.06246584950895441));
            samples.Add(new ECGSample(6482, 0.066965563339300357));
            samples.Add(new ECGSample(7459, 0.068204732722367045));
            

            sampleFrequency = frequency;
            UpdateTresholds2();

        }

        public IEnumerable<ECGSample> Execute(IEnumerable<ECGSample> input)
        {
            newlyDetected.Clear();
            ECGSample peakCandidate;

            try
            {
                peakCandidate = input.Where(x => x.Index - lastQRS >= RR_LOW_LIMIT && 
                                            x.Index - lastQRS < RR_HIGH_LIMIT)
                                     .MaxBy(y => y.Value);

                if (peakCandidate.Value > TRESHOLD1)
                {
                    SPKI = 0.125 * peakCandidate.Value + 0.875 * SPKI;
                    RR.Add(new ECGSample(peakCandidate.Index, peakCandidate.Index - lastQRS));
                    newlyDetected.Add(new ECGSample(peakCandidate.Index, peakCandidate.Index - lastQRS));

                    lastQRS = peakCandidate.Index;
                    UpdateTresholds();
                    samples.Clear();
                }
                else
                    NPKI = 0.125 * peakCandidate.Value + 0.875 * NPKI;
            }
            catch 
            {
                // No peaks found in input
                foreach (ECGSample s in input)
                {
                    samples.Add(new ECGSample(s.Index, s.Value));
                    if (s.Index - lastQRS > RR_HIGH_LIMIT)
                        DoSearchback();
                }
            }

            TRESHOLD1 = NPKI + 0.25 * (SPKI - NPKI);
            TRESHOLD2 = 0.5 * TRESHOLD1;

            return newlyDetected;
        }

        private void DoSearchback()
        {
            ECGSample peakCandidate = samples.MaxBy(x => x.Value);

            if (peakCandidate.Value > TRESHOLD2)
            {
                SPKI = 0.25 * peakCandidate.Value + 0.75 * SPKI;
                RR.Add(new ECGSample(peakCandidate.Index, peakCandidate.Index - lastQRS));
                RR2.Add(new ECGSample(peakCandidate.Index, peakCandidate.Index - lastQRS));
                newlyDetected.Add(new ECGSample(peakCandidate.Index, peakCandidate.Index - lastQRS));
                lastQRS = peakCandidate.Index;
                UpdateTresholds();
                samples.Clear();
            }
        }

        private void UpdateTresholds()
        {
            double r = 0;
            double r2 = 0;

            if (RR.Count >= 8)
            {
                for (int i = 8; i > 0; i--)
                    r += RR[RR.Count - i].Value;
                RRAVERAGE1 = 0.125 * r;
            }

            if( RR2.Count >= 8)
            {
                for (int i = 8; i > 0; i--)
                    r2 += RR2[RR2.Count - i].Value;
                RRAVERAGE2 = 0.125 * r2;
            }

            RR_LOW_LIMIT = 0.92 * RRAVERAGE2;
            RR_HIGH_LIMIT = 1.16 * RRAVERAGE2;
            RR_MISSED_LIMIT = 1.66 * RRAVERAGE2;
        }

        private void UpdateTresholds2()
        {
            lastQRS = 0;
            
            foreach (ECGSample s in samples) 
            {
                SPKI = 0.125 * s.Value + 0.875 * SPKI;
                TRESHOLD1 = NPKI + 0.25 * (SPKI - NPKI);
                TRESHOLD2 = TRESHOLD1 * 0.5;

                RR.Add(new ECGSample(s.Index, s.Index - lastQRS));
                lastQRS = s.Index;
            }

            foreach (ECGSample s in RR) 
            {
                RRAVERAGE1 += s.Value;
            }

            RRAVERAGE1 = 0.125 * RRAVERAGE1;
            RRAVERAGE2 = RRAVERAGE1;

            RR_HIGH_LIMIT = RRAVERAGE2 * 1.16;
            RR_LOW_LIMIT = RRAVERAGE2 * 0.92;
            RR_MISSED_LIMIT = RRAVERAGE2 * 1.66;

            samples.Clear();
            RR.Clear();
            lastQRS = 0;
        }

        public int GetDelay()
        {
            return 0;
        }
    }


}
