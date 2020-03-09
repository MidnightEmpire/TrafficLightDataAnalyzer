using System.Collections.Generic;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;
using TrafficLightDataAnalyzer.Model.Observation.State.TrafficLight;
using TrafficLightDataAnalyzer.Model.Validation.Validator.Common;
using TrafficLightDataAnalyzer.Model.Validation.Validator.TrafficLight;

namespace TrafficLightDataAnalyzer.Model.Validation
{
    /// <summary>
    /// Validation factory model class.
    /// </summary>
    internal class ValidationFactoryModel
    {
        /// <summary>
        /// <see cref="GuidStringFormatValidatorModel">GuidStringFormatValidatorModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="GuidStringFormatValidatorModel">GuidStringFormatValidatorModel</see>.</returns>
        public IValidator<string> CreateGuidStringFormatValidator()
        {
            return new GuidStringFormatValidatorModel();
        }

        /// <summary>
        /// <see cref="ColorNameValidatorModel">ColorNameValidatorModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="ColorNameValidatorModel">ColorNameValidatorModel</see>.</returns>
        public IValidator<string> CreateColorNameValidator()
        {
            return new ColorNameValidatorModel();
        }

        /// <summary>
        /// <see cref="DigitValueValidatorModel">DigitValueValidatorModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="DigitValueValidatorModel">DigitValueValidatorModel</see>.</returns>
        public IValidator<sbyte> CreateDigitValueValidator()
        {
            return new DigitValueValidatorModel();
        }

        /// <summary>
        /// <see cref="SevenSegmentBinaryCodeStringValidatorModel">SevenSegmentBinaryCodeStringValidatiorModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="SevenSegmentBinaryCodeStringValidatorModel">SevenSegmentBinaryCodeStringValidatiorModel</see>.</returns>
        public IValidator<string> CreateSevenSegmentBinaryCodeStringValidator()
        {
            return new SevenSegmentBinaryCodeStringValidatorModel();
        }

        /// <summary>
        /// <see cref="DigitsValueValidatorModel">DigitsValueValidatorModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="DigitsValueValidatorModel">DigitValueValidatorModel</see>.</returns>
        public IValidator<DigitsValueModel> CreateDigitsValueValidator()
        {
            return new DigitsValueValidatorModel();
        }

        /// <summary>
        /// <see cref="SealedObservationStatesFirstStateValidatorModel">SealedObservationStatesFirstStateValidatorModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="SealedObservationStatesFirstStateValidatorModel">SealedObservationStatesFirstStateValidatorModel</see>.</returns>
        public IValidator<IList<ObservedObjectStateModel>> CreateSealedObservationStatesFirstStateValidator()
        {
            return new SealedObservationStatesFirstStateValidatorModel();
        }

        /// <summary>
        /// <see cref="SealedObservationStatesLastStateValidatorModel">SealedObservationStatesLastStateValidatorModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="SealedObservationStatesLastStateValidatorModel">SealedObservationStatesLastStateValidatorModel</see>.</returns>
        public IValidator<IList<ObservedObjectStateModel>> CreateSealedObservationStatesLastStateValidator()
        {
            return new SealedObservationStatesLastStateValidatorModel();
        }
    }
}
