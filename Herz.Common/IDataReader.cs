using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herz.Common
{
    /// <summary>
    /// Data source interface. Must be implemented in data acquisition class.
    /// </summary>
    public interface IDataReader
    {
        event EventHandler<DataReadyEventArgs> DataReady;
    }

    /// <summary>
    /// Custom envent argument for DataReady event. 
    /// Represents a chunk of ECG signal aquired from source.
    /// </summary>
    public class DataReadyEventArgs : EventArgs 
    {
        public List<ECGSample> ECGSignalChunk { get; set; }

        public DataReadyEventArgs(List<ECGSample> ecgChunk) 
        {
            ECGSignalChunk = ecgChunk;
        }
    }
}
