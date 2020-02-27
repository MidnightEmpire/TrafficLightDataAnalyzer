namespace TrafficLightDataAnalyzer.Interface
{
    /// <summary>
    /// Accotiative navigator interface
    /// </summary>
    internal interface IAssociativeNavigator<TItemType> where TItemType : class
    {
        /// <summary>
        /// Navigate to previous item method
        /// </summary>
        /// <param name="currentItem">Current item reference value</param>
        /// <returns>Previous item reference value</returns>
        TItemType Previous(TItemType currentItem);

        /// <summary>
        /// Navigate to next item method
        /// </summary>
        /// <param name="currentItem">Current item reference value</param>
        /// <returns>Next item reference value</returns>
        TItemType Next(TItemType currentItem);

        /// <summary>
        /// Navigate to previous N-th item method
        /// </summary>
        /// <param name="currentItem">Current item reference value</param>
        /// <param name="count">N-th relative position of previous item value</param>
        /// <returns>Previous item reference value</returns>
        TItemType PreviousBefore(TItemType currentItem, int count);

        /// <summary>
        /// Navigate to next N-th item method
        /// </summary>
        /// <param name="currentItem">Current item reference value</param>
        /// <param name="count">N-th relative position of next item value</param>
        /// <returns>Next item reference value</returns>
        TItemType NextAfter(TItemType currentItem, int count);
    }
}
