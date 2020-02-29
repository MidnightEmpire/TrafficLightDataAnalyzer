using System.Collections.Generic;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Prediction.Predictor.Simple;

namespace TrafficLightDataAnalyzer.Model.Prediction
{
    /// <summary>
    /// Prediction factory model class
    /// </summary>
    internal class PredictionFactoryModel
    {
        /// <summary>
        /// Possible seven segment digits by code predictor model instance obtaining method
        /// </summary>
        /// <returns>New instance of possible seven segment digits by code predictor model</returns>
        public IPredictor<byte, IEnumerable<SevenSegmentDigitModel>> CreatePossibleSevenSegmentDigitsByCodePredictor()
        {
            return new PossibleSevenSegmentDigitsByCodePredictorModel();
        }
    }
}
