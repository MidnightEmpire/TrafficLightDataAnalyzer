using System.Collections.Generic;

namespace TrafficLightDataAnalyzer.Interface
{
    /// <summary>
    /// <typeparamref name="TRangeItem" /> values  range generator interface.
    /// </summary>
    /// <typeparam name="TRangeItem">Type of result range items.</typeparam>
    internal interface IRangeGenerator<TRangeItem>
    {
        /// <summary>
        /// Items range making method.
        /// </summary>
        /// <param name="from">Start range item value. Will be included into result range.</param>
        /// <param name="to">End range item value. Will be included into result range.</param>
        /// <returns>Result <see cref="IEnumerable{T}">enumerable</see> range reference value.</returns>
        IEnumerable<TRangeItem> MakeRange(TRangeItem from, TRangeItem to);
    }
}
