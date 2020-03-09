using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Conversion;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;

namespace TrafficLightDataAnalyzer.Model.Prediction.Predictor.Simple.TrafficLight
{
    /// <summary>
    /// Possible <see cref="DigitModel">DigitModel</see> values by source broken code value prediction model class.
    /// </summary>
    internal class PossibleDigitsByBinaryCodePredictorModel : IPredictor<byte, IEnumerable<DigitModel>>
    {
        /// <summary>
        /// <see cref="ConversionFactoryModel">ConversionFactoryModel</see> reference field.
        /// </summary>
        private static readonly ConversionFactoryModel _conversionFactory;

        /// <summary>
        /// Make guess/prediction based on <paramref name="source" /> input data method.
        /// </summary>
        /// <param name="source">Source input data value to analyze.</param>
        /// <returns>Guess/prediction value.</returns>
        public IEnumerable<DigitModel> MakeGuess(byte source)
        {
            var converter = PossibleDigitsByBinaryCodePredictorModel._conversionFactory.CreateDigitTo7SegmentCodeConverter();

            var result = DigitModel
                .AllDigits
                .Where(
                    (digit) => (byte) (converter.Convert(digit) & source & ConversionFactoryModel.SevenSegmentBinaryCodePatternMask) == source
                );

            return result;
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static PossibleDigitsByBinaryCodePredictorModel()
        {
            PossibleDigitsByBinaryCodePredictorModel._conversionFactory = new ConversionFactoryModel();
        }
    }
}
