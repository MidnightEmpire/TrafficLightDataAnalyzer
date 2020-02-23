namespace TestApp.Common
{
    /// <summary>
    /// Null instance of any type creation factory class
    /// </summary>
    internal static class NullInstance
    {
        /// <summary>
        /// Null instance of specified reference-based type obtaining method
        /// </summary>
        /// <typeparam name="TType">Reference-based type of instance which one must be null</typeparam>
        /// <returns>Null instance of specified reference-based type</returns>
        public static TType Of<TType>() where TType : class
        {
            return null;
        }
    }
}
