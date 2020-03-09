namespace TrafficLightDataAnalyzer.Common
{
    /// <summary>
    /// Null instances of any null-allowed type creation factory class.
    /// </summary>
    internal static class NullInstance
    {
        /// <summary>
        /// Null instance of specified null-allowed <typeparamref name="TType" /> obtaining method.
        /// </summary>
        /// <typeparam name="TType">Null-allowed type of instance which null instance is required.</typeparam>
        /// <returns>Null instance of specified null-allowed <typeparamref name="TType" />.</returns>
        public static TType Of<TType>() where TType : class
        {
            return null;
        }
    }
}
