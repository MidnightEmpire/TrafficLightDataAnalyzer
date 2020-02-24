using System.Linq;
using TrafficLightDataAnalyzer.Interface;

namespace TrafficLightDataAnalyzer.Model.Validation.Validator
{
    /// <summary>
    /// Traffic light observation seven segment binary code string validation model class
    /// </summary>
    internal class SevenSegmentBinaryCodeStringValidationModel : IValidator<string>
    {
        /// <summary>
        /// Segment amount constant
        /// </summary>
        private const byte SegmentAmount = 7;

        /// <summary>
        /// Object validation method
        /// </summary>
        /// <param name="objectForCheck">Object which one will be validated</param>
        /// <returns>True, if object seems to be valid one. Otherwise, return false</returns>
        public bool IsValid(string objectForCheck)
        {
            return objectForCheck.Length == SevenSegmentBinaryCodeStringValidationModel.SegmentAmount &&
                   objectForCheck.All((codeChar) => codeChar == '0' || codeChar == '1');
        }
    }
}
