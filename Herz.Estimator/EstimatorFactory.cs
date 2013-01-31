using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using System.Globalization;

namespace Herz.Estimator
{
    public static class EstimatorFactory
    {
        public static Estimator CreateEstimatorFromFile(string startFile, string endFile, int sampleRate) 
        {
            List<double> start = ParseFromFile(startFile);
            List<double> end = ParseFromFile(endFile);

            return new Estimator(start, end, sampleRate);
        }

        private static List<double> ParseFromFile(string file) 
        {
            double d;
            CultureInfo culture = CultureInfo.InvariantCulture;
            List<double> timeMarks = new List<double>();

            var reader = new StreamReader(File.OpenRead(file));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                foreach (string s in values)
                {
                    if (Double.TryParse(s, NumberStyles.Number, culture, out d))
                        timeMarks.Add(d);
                }
            }

            return timeMarks;
        }
    }
}
