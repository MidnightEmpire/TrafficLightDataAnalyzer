namespace TrafficLightDataAnalyzer.Interface
{
    /// <summary>
    /// Simple double-direct conversion of some <typeparamref name="TSourceType" /> value to <typeparamref name="TTargetType" /> one interface.
    /// </summary>
    /// <typeparam name="TSourceType">Source value type.</typeparam>
    /// <typeparam name="TTargetType">Target value type.</typeparam>
    internal interface ISimpleConverter<TSourceType, TTargetType>
    {
        /// <summary>
        /// Value conversion method.
        /// </summary>
        /// <param name="source">Source value to convert.</param>
        /// <returns>Result/converted value.</returns>
        TTargetType Convert(TSourceType source);

        /// <summary>
        /// Value reverse-conversion method.
        /// </summary>
        /// <param name="source">Source value to reverse-convert.</param>
        /// <returns>Result/reverse-converted value.</returns>
        TSourceType ConvertBack(TTargetType source);
    }
}
