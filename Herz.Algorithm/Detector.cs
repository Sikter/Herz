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
        private int chunkSize;

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

        private bool initComplete = false;
        private List<ECGSample> initSamples = new List<ECGSample>();
        public List<ECGSample> initRR = new List<ECGSample>();

        public List<ECGSample> RR { get; set; }
        List<ECGSample> newlyDetected = new List<ECGSample>();

        public Detector(int frequency, int chunkSize)
        {
            RR = new List<ECGSample>();
            this.sampleFrequency = frequency;
            this.chunkSize = chunkSize;

        }

        public IEnumerable<ECGSample> Execute(IEnumerable<ECGSample> input)
        {
            newlyDetected.Clear();

            // Initialization period is first 8 seconds of incoming signal.
            // Samples are aggregated and for every 1 second period the highest peak is assumed to be R peak.
            // Initial tresholds are set after all 8 seconds are acquired.
            if (!initComplete)
            {
                DetectInitializationPeaks(input);
                // Tresholds are set, begin detecton from start
                if (initComplete)
                {
                    double d = (sampleFrequency * 8) / chunkSize;
                    int chunks = (int)Math.Ceiling(d);
                    for (int i = 0; i < chunks; i++)
                    {
                        List<ECGSample> data = initSamples.Where(x => x.Index >= i * chunkSize &&
                                                                 x.Index < (i + 1) * chunkSize).ToList();
                        PanTompkinsDetection(data);
                    }
                    return newlyDetected;
                }
            }
            else
            {
                PanTompkinsDetection(input);
            }

            return newlyDetected;
        }

        /// <summary>
        /// Detects peaks from first 8 seconds of signal which are used to initialy set treshold values.
        /// </summary>
        /// <param name="input"></param>
        private void DetectInitializationPeaks(IEnumerable<ECGSample> input)
        {
            if (initSamples.Count <= sampleFrequency * 7)
            {
                foreach (ECGSample s in input)
                {
                    initSamples.Add(new ECGSample(s.Index, s.Value));
                }
                return;
            }

            ECGSample peak;
            for (int i = 0; i < 7; i++)
            {
                peak = initSamples.Where(x => x.Index >= i * sampleFrequency &&
                                              x.Index < (i + 1) * sampleFrequency)
                                  .MaxBy(y => y.Value);
                initRR.Add(new ECGSample(peak.Index, peak.Value));
            }
            // Update initial treshold value.
            InitUpdateTresholds();
        }

        /// <summary>
        /// Pan-Tompkins detection algorithm. Used after intialization phase.
        /// 
        /// </summary>
        /// <param name="input">Chunk of proccesed ECG data.</param>
        private void PanTompkinsDetection(IEnumerable<ECGSample> input)
        {
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
                {
                    foreach (ECGSample s in input)
                        samples.Add(new ECGSample(s.Index, s.Value));

                    NPKI = 0.125 * peakCandidate.Value + 0.875 * NPKI;
                }
            }
            catch
            {
                // No peaks found in input
                foreach (ECGSample s in input)
                {
                    samples.Add(new ECGSample(s.Index, s.Value));
                    if (s.Index - lastQRS > RR_HIGH_LIMIT)
                    {
                        if (DoSearchback())
                            break;
                    }
                }
            }

            TRESHOLD1 = NPKI + 0.25 * (SPKI - NPKI);
            TRESHOLD2 = 0.5 * TRESHOLD1;
        }

        private bool DoSearchback()
        {
            ECGSample peakCandidate = samples.MaxBy(x => x.Value);
            if (peakCandidate != null && peakCandidate.Value > TRESHOLD2)
            {
                SPKI = 0.25 * peakCandidate.Value + 0.75 * SPKI;
                RR.Add(new ECGSample(peakCandidate.Index, peakCandidate.Index - lastQRS));
                newlyDetected.Add(new ECGSample(peakCandidate.Index, peakCandidate.Index - lastQRS));
                lastQRS = peakCandidate.Index;
                UpdateTresholds();
                samples.Clear();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates tresholds based on last 8 RR intervals.
        /// This method is normally used after initialization stage of algorithm.
        /// </summary>
        private void UpdateTresholds()
        {
            if (RR.Count >= 8)
            {
                double r = 0;
                List<ECGSample> lastR1 = RR.TakeLast(8).ToList();

                foreach (ECGSample lr in lastR1)
                    r += lr.Value;
                RRAVERAGE1 = r / lastR1.Count();

                RRAVERAGE2 = RRAVERAGE1;

                RR_LOW_LIMIT = 0.92 * RRAVERAGE2;
                RR_HIGH_LIMIT = 1.16 * RRAVERAGE2;
                RR_MISSED_LIMIT = 1.66 * RRAVERAGE2;
            }
        }

        /// <summary>
        /// Method for tresholds update for initialization phase.
        /// (first 8 seconds of incoming signal).
        /// </summary>
        private void InitUpdateTresholds()
        {
            lastQRS = 0;

            foreach (ECGSample s in initRR)
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

            //sample.Clear();
            RR.Clear();
            lastQRS = 0;
            initComplete = true;
        }

        public int GetDelay()
        {
            return 0;
        }
    }

}
