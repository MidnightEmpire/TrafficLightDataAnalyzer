using System.Linq;
using TrafficLightDataAnalyzer.Interface;

namespace TrafficLightDataAnalyzer.Model.Validation.Validator.TrafficLight
{
    /// <summary>
    /// Traffic light 7-segment binary code string validator model class.
    /// </summary>
    internal class SevenSegmentBinaryCodeStringValidatorModel : IValidator<string>
    {
        /// <summary>
        /// Segment amount constant.
        /// </summary>
        private const byte SegmentAmount = 7;

        /// <summary>
        /// Object validation method.
        /// </summary>
        /// <param name="objectForCheck">Object which one must be validated.</param>
        /// <returns>True, if object seems to be valid one. Otherwise, returns false.</returns>
        public bool IsValid(string objectForCheck)
        {
            return objectForCheck != null &&
                   objectForCheck.Length == SevenSegmentBinaryCodeStringValidatorModel.SegmentAmount &&
                   objectForCheck.All((codeChar) => codeChar == '0' || codeChar == '1');
        }
    }
}
