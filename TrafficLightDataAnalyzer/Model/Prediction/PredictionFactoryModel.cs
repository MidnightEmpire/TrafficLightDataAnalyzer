using System.Collections.Generic;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Prediction.Predictor.Simple.TrafficLight;

namespace TrafficLightDataAnalyzer.Model.Prediction
{
    /// <summary>
    /// Prediction factory model class.
    /// </summary>
    internal class PredictionFactoryModel
    {
        /// <summary>
        /// <see cref="PossibleDigitsByBinaryCodePredictorModel">PossibleDigitsByBinaryCodePredictorModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="PossibleDigitsByBinaryCodePredictorModel">PossibleDigitsByBinaryCodePredictorModel</see>.</returns>
        public IPredictor<byte, IEnumerable<DigitModel>> CreatePossibleDigitsByBinaryCodePredictor()
        {
            return new PossibleDigitsByBinaryCodePredictorModel();
        }
    }
}
