using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;

namespace TrafficLightDataAnalyzer.Model.Predictor.Simple
{
    /// <summary>
    /// Possible seven segment digits by source broken code prediction model class
    /// </summary>
    internal class PossibleSevenSegmentDigitsByCodePredictorModel : IPredictor<byte, IEnumerable<SevenSegmentDigitModel>>
    {
        /// <summary>
        /// Make guess/prediction based on source input data method
        /// </summary>
        /// <param name="source">Source input data value to analyze</param>
        /// <returns>Guess/prediction value</returns>
        public IEnumerable<SevenSegmentDigitModel> MakeGuess(byte source)
        {
            var result = SevenSegmentDigitModel
                .AllDigits
                .Where(
                    (digit) => (byte) (digit.BinaryCode & source & SevenSegmentDigitModel.BinaryCodePatternMask) == source
                );

            return result;
        }
    }
}
