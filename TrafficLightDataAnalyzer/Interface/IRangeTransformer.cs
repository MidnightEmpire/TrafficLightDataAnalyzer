using System.Collections.Generic;

namespace TrafficLightDataAnalyzer.Interface
{
    /// <summary>
    /// Some type values range transforming to some another type values range interface
    /// </summary>
    /// <typeparam name="TSourceRangeItem">Type of source range items</typeparam>
    /// <typeparam name="TTargetRangeItem">Type of target range items</typeparam>
    internal interface IRangeTransformer<TSourceRangeItem, TTargetRangeItem>
    {
        /// <summary>
        /// Items range transformation method
        /// </summary>
        /// <param name="source">Source range items collection reference value</param>
        /// <returns>Result/transformed range items collection reference value</returns>
        IEnumerable<TTargetRangeItem> Transform(IEnumerable<TSourceRangeItem> source);
    }
}
