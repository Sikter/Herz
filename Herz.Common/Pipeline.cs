using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herz.Common
{
    /// <summary>
    /// Pipeline class containing list of filters that will be applied sequentialy on 
    /// incoming data chunks. Generic implementation of Pipeline Filter desing pattern.
    /// </summary>
    /// <typeparam name="T">Generic data type that is processed in filters.</typeparam>
    public class Pipeline<T>
    {
        /// <summary>
        /// Internal container for filters.
        /// </summary>
        private readonly List<IFilter<T>> filters = new List<IFilter<T>>();

        public IEnumerable<T> Current { get; set; }

        /// <summary>
        /// Registers given filter in pipeline. Filters will be executed in order they 
        /// are registered.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pipeline<T> Register(IFilter<T> filter)
        {
            filters.Add(filter);
            return this;
        }

        /// <summary>
        /// Executes pipeline.
        /// </summary>
        /// <param name="ecgChunk"></param>
        public IEnumerable<T> Execute(IEnumerable<T> ecgChunk)
        {
            //IEnumerable<T> current = ecgChunk;//.ToList<T>();
            Current = ecgChunk;
            foreach (IFilter<T> filter in filters)
            {
                Current = filter.Execute(Current);
            }
            //IEnumerator<T> enumerator = Current.GetEnumerator();
            //while (enumerator.MoveNext()) ;

            return Current;
        }
    }
}
