namespace TrafficLightDataAnalyzer.Interface
{
    /// <summary>
    /// Object of some <typeparamref name="TObject" /> type validation interface.
    /// </summary>
    /// <typeparam name="TObject">Type of object which one must be validated.</typeparam>
    internal interface IValidator<TObject>
    {
        /// <summary>
        /// Object validation method.
        /// </summary>
        /// <param name="objectForCheck">Object which one must be validated.</param>
        /// <returns>True, if object seems to be valid one. Otherwise, returns false.</returns>
        bool IsValid(TObject objectForCheck);
    }
}
