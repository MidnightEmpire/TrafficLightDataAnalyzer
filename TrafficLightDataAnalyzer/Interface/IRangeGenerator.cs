using System.Collections.Generic;

namespace TrafficLightDataAnalyzer.Interface
{
    /// <summary>
    /// Some type values range generator interface
    /// </summary>
    /// <typeparam name="TRangeItem">Type of range items</typeparam>
    internal interface IRangeGenerator<TRangeItem>
    {
        /// <summary>
        /// Items range making method
        /// </summary>
        /// <param name="from">Start range value. Will be included into result range</param>
        /// <param name="to">End range value. Will be included into result range</param>
        /// <returns>Required range collection reference value</returns>
        IEnumerable<TRangeItem> MakeRange(TRangeItem from, TRangeItem to);
    }
}
