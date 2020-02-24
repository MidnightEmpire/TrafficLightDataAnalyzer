namespace TestApp.Interface
{
    /// <summary>
    /// Validation interface
    /// </summary>
    /// <typeparam name="TObject">Type of object which one will be validated</typeparam>
    internal interface IValidator<TObject>
    {
        /// <summary>
        /// Object validation method
        /// </summary>
        /// <param name="objectForCheck">Object which one will be validated</param>
        /// <returns>True, if object seems to be valid one. Otherwise, return false</returns>
        bool IsValid(TObject objectForCheck);
    }
}
