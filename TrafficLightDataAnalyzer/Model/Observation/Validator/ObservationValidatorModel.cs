using System.Linq;
using TrafficLightDataAnalyzer.Common;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Model.Validation;

namespace TrafficLightDataAnalyzer.Model.Observation.Validator
{
    /// <summary>
    /// Observation constructor arguments validator model class
    /// </summary>
    internal class ObservationValidatorModel
    {
        /// <summary>
        /// Validation factory reference field
        /// </summary>
        private readonly ValidationFactoryModel _validationFactory;

        /// <summary>
        /// Traffic light color name validation method
        /// </summary>
        /// <param name="binaryCodesStrings">Registered traffic light color name reference value</param>
        public void ValidateTrafficLightColorName(string colorName)
        {
            var trafficLightColorValidator = this._validationFactory.GetTrafficLightColorNameValidator();

            if (!trafficLightColorValidator.IsValid(colorName))
            {
                throw new WrongObservationDataException(StringsKeeper.ExceptionMessage.InvalidTrafficLightColor);
            }
        }

        /// <summary>
        /// Registered digits binary codes strings validation method
        /// </summary>
        /// <param name="binaryCodesStrings">Registered digits binary codes strings array reference value</param>
        public void ValidateBinaryCodesStrings(string[] binaryCodesStrings)
        {
            var sevenSegmentsBinaryCodesStringsAmountValidator = this._validationFactory.GetSevenSegmentBinaryCodesStringsAmountValidator();

            if (!sevenSegmentsBinaryCodesStringsAmountValidator.IsValid(binaryCodesStrings))
            {
                throw new WrongObservationDataException(StringsKeeper.ExceptionMessage.InvalidDigitCodesAmount);
            }

            var sevenSegmentBinaryCodeStringValidator = this._validationFactory.GetSevenSegmentBinaryCodeStringValidator();

            if (binaryCodesStrings.Any((binaryCodeString) => !sevenSegmentBinaryCodeStringValidator.IsValid(binaryCodeString)))
            {
                throw new WrongObservationDataException(StringsKeeper.ExceptionMessage.InvalidDigitCode);
            }
        }

        /// <summary>
        /// Main constructor
        /// </summary>
        public ObservationValidatorModel()
        {
            this._validationFactory = new ValidationFactoryModel();
        }
    }
}
