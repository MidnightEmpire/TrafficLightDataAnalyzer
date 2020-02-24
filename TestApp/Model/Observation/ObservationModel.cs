using System;
using System.Linq;
using TestApp.Model.Common.EnumerableSet;
using TestApp.Model.Observation.Validator;
using TestApp.Model.Validation;

namespace TestApp.Model.Observation
{
    /// <summary>
    /// Observation model class
    /// Yes, it has validator in constructor. SRP principle may be broken a bit, but...
    /// </summary>
    internal class ObservationModel
    {
        /// <summary>
        /// Corresponding observation validator model reference field
        /// </summary>
        private static readonly ObservationValidatorModel _observationValidator;

        /// <summary>
        /// Registered traffic light color property
        /// </summary>
        public TrafficLightColorModel Color { get; }

        /// <summary>
        /// Registered digits binary codes array property
        /// </summary>
        public byte[] BinaryCodes { get; }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="colorName">Registered traffic light color name</param>
        /// <param name="binaryCodesStrings">Binary codes strings array. Despite the fact of any string array size, require strict DigitAmout items amount</param>
        public ObservationModel(string colorName, params string[] binaryCodesStrings)
        {
            var validationFactory = new ValidationFactoryModel();

            ObservationModel._observationValidator.ValidateTrafficLightColorName(colorName);
            ObservationModel._observationValidator.ValidateBinaryCodesStrings(binaryCodesStrings);

            this.Color = TrafficLightColorModel.FindByName(colorName, StringComparison.OrdinalIgnoreCase);

            this.BinaryCodes = binaryCodesStrings
                .Select((binaryCodeString) => Convert.ToByte(binaryCodeString, 2))
                .ToArray();
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static ObservationModel()
        {
            ObservationModel._observationValidator = new ObservationValidatorModel();
        }

        #region Object overrides

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns>A string that represents the current object</returns>
        public override string ToString()
        {
            var binaryCodesStrings = this.BinaryCodes
                .Select((binaryCode) => Convert.ToString(binaryCode, 2))
                .Select((binaryCodeString) => $"0b{binaryCodeString.PadLeft(8, '0')}")
                .ToArray();

            var binaryCodeString = string.Join(", ", binaryCodesStrings);

            return $"Color: {this.Color.Name}, Codes: [{binaryCodeString}]";
        }

        #endregion
    }
}
