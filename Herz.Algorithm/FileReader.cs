using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herz.Common;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using System.Globalization;
using System.Collections.Concurrent;

namespace Herz.Algorithm
{
    /// <summary>
    /// Reads ECG data from a file.
    /// </summary>
    public class CSVReader : IDataReader
    {
        private List<ECGSample> _buffer;
        private int _bufferSize;

        public int Frequency { get; set; }
        public string FileName { get; set; }
        public event EventHandler<DataReadyEventArgs> DataReady;


        public CSVReader(string fileName, int bufferSize, int frequency) 
        {
            _buffer = new List<ECGSample>();
            _bufferSize = bufferSize;
            FileName = fileName;
            Frequency = frequency;
        }

        public void Read() 
        {
            using (CsvReader csv = 
                new CsvReader(new StreamReader(FileName), true))
            {
                // Replaces missing field with empty string.
                csv.MissingFieldAction = MissingFieldAction.ReplaceByEmpty;
                // number of fields
                int index = 0;
                CultureInfo culture = CultureInfo.InvariantCulture;
                // Read csv data one by one until EOF.
                while (csv.ReadNextRecord())
                {
                    
                    double val = 0;
                    string data = csv[index, 0];
                    // Parse data as ECGSample, if it fails given data is skipped.
                    if (Double.TryParse(data, NumberStyles.Number, culture, out val))
                        _buffer.Add(new ECGSample((int)csv.CurrentRecordIndex, val));

                    // Buffer is filled, raise event to send data for processing. Clear buffer for new data.
                    if (_buffer.Count >= _bufferSize)
                    {
                        OnBufferFullEvent(new DataReadyEventArgs(_buffer));
                        _buffer.Clear();
                        System.Threading.Thread.Sleep(125);
                    }
                    index++;
                }
            }
        }

        /// <summary>
        /// Wrapper method for event invocation.
        /// </summary>
        /// <param name="e">ECG data chunk.</param>
        protected virtual void OnBufferFullEvent(DataReadyEventArgs e)
        {
            EventHandler<DataReadyEventArgs> handler = DataReady;

            // handler will be null if there are no subscribers to event
            if (handler != null) 
                //e.ECGSignalChunk = _buffer;
                handler(this, e); // raise event

        }
    }
}
