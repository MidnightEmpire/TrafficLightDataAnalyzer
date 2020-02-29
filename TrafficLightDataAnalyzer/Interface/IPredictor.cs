namespace TrafficLightDataAnalyzer.Interface
{
    /// <summary>
    /// Common data prediction interface
    /// </summary>
    /// <typeparam name="TInputData">Source input data type</typeparam>
    /// <typeparam name="TPrediction">Result prediction data type</typeparam>
    internal interface IPredictor<TInputData, TPrediction>
    {
        /// <summary>
        /// Make guess/prediction based on source input data method
        /// </summary>
        /// <param name="source">Source input data value to analyze</param>
        /// <returns>Guess/prediction value</returns>
        TPrediction MakeGuess(TInputData source);
    }
}
