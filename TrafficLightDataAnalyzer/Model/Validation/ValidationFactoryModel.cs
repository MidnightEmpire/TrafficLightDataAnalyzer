using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Validation.Validator;

namespace TrafficLightDataAnalyzer.Model.Validation
{
    /// <summary>
    /// Validation factory model class
    /// </summary>
    internal class ValidationFactoryModel
    {
        /// <summary>
        /// Traffic light color name validation model instance obtaining method
        /// </summary>
        /// <returns>New instance of traffic light color name validation model</returns>
        public IValidator<string> GetTrafficLightColorNameValidator()
        {
            return new TrafficLightColorNameValidationModel();
        }

        /// <summary>
        /// Traffic light observation seven segment binary code string validation model instance obtaining method
        /// </summary>
        /// <returns>New instance of traffic light observation seven segment binary code string validation model</returns>
        public IValidator<string> GetSevenSegmentBinaryCodeStringValidator()
        {
            return new SevenSegmentBinaryCodeStringValidationModel();
        }

        /// <summary>
        /// Traffic light observation seven segment binary codes strings amount validation model instance obtaining method
        /// </summary>
        /// <returns>New instance of traffic light observation seven segment binary codes strings amount validation model</returns>
        public IValidator<string[]> GetSevenSegmentBinaryCodesStringsAmountValidator()
        {
            return new SevenSegmentBinaryCodesStringsAmountValidationModel();
        }
    }
}
