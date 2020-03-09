using System.Collections.Generic;

namespace TrafficLightDataAnalyzer.Interface
{
    /// <summary>
    /// Some <typeparamref name="TSourceItem" /> value transforming to some another <typeparamref name="TTargetItem" /> value interface.
    /// </summary>
    /// <typeparam name="TSourceItem">Type of source item.</typeparam>
    /// <typeparam name="TTargetItem">Type of target item.</typeparam>
    internal interface ITransformer<TSourceItem, TTargetItem>
    {
        /// <summary>
        /// Item transformation performing method.
        /// </summary>
        /// <param name="source">Source item value.</param>
        /// <returns>Result/transformed item value.</returns>
        TTargetItem Transform(TSourceItem source);
    }
}
