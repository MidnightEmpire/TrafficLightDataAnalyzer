using System;
using TrafficLightDataAnalyzer.Common;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Model.Conversion;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;
using TrafficLightDataAnalyzer.Model.Validation;

namespace TrafficLightDataAnalyzer.Model.Observation.State.TrafficLight
{
    /// <summary>
    /// Traffic light observation state model class.
    /// </summary>
    internal class ObservedObjectStateModel : BaseObservedObjectStateModel
    {
        /// <summary>
        /// <see cref="ConversionFactoryModel">ConversionFactoryModel</see> reference field.
        /// </summary>
        private static readonly ConversionFactoryModel _conversionFactory;

        /// <summary>
        /// <see cref="ValidationFactoryModel">ValidationFactoryModel</see> reference field.
        /// </summary>
        private static readonly ValidationFactoryModel _validationFactory;

        /// <summary>
        /// Registered <see cref="ColorModel">ColorModel</see> value property.
        /// </summary>
        public ColorModel Color { get; }

        /// <summary>
        /// Registered <see cref="BinaryCodesValueModel">BinaryCodesValueModel</see> value array property.
        /// </summary>
        public BinaryCodesValueModel BinaryCodes { get; }

        /// <summary>
        /// Try raise <paramref name="colorName" /> exceptions for <see cref="ObservedObjectStateModel.ObservedObjectStateModel(string, (string, string))">constructor</see> method,
        /// if <paramref name="colorName" /> parameter is invalid one service method.
        /// </summary>
        /// <param name="colorName">Color name value.</param>
        /// <exception cref="ArgumentNullException">Throws, if <paramref name="colorName" /> is null one.</exception>
        /// <exception cref="WrongObservationDataException">Throws, if <paramref name="colorName" /> is invalid one.</exception>
        private void tryRaiseColorNameExceptions(string colorName)
        {
            if (colorName is null)
            {
                throw new ArgumentNullException(nameof(colorName));
            }

            var validator = ObservedObjectStateModel._validationFactory.CreateColorNameValidator();

            if (!validator.IsValid(colorName))
            {
                throw new WrongObservationDataException(StringsKeeper.ExceptionMessage.InvalidColorName);
            }
        }

        /// <summary>
        /// Try raise <paramref name="binaryCodeString" /> exceptions for <see cref="ObservedObjectStateModel.ObservedObjectStateModel(string, (string, string))">constructor</see> method,
        /// if <paramref name="binaryCodeString" /> parameter is invalid one service method.
        /// </summary>
        /// <param name="binaryCodeString">Binary code string value.</param>
        /// <param name="argumentName">Argument name value.</param>
        /// <exception cref="ArgumentNullException">Throws, if <paramref name="binaryCodeString" /> is null one.</exception>
        /// <exception cref="WrongObservationDataException">Throws, if <paramref name="binaryCodeString" /> is invalid one.</exception>
        private void tryRaiseBinaryCodeStringExceptions(string binaryCodeString, string argumentName)
        {
            if (binaryCodeString is null)
            {
                throw new ArgumentNullException(argumentName);
            }

            var validator = ObservedObjectStateModel._validationFactory.CreateSevenSegmentBinaryCodeStringValidator();

            if (!validator.IsValid(binaryCodeString))
            {
                throw new WrongObservationDataException($"{StringsKeeper.ExceptionMessage.Invalid7SegmentDigitCode} [{argumentName}]");
            }
        }

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="colorName">Registered traffic light color name value.</param>
        /// <param name="binaryCodesStrings"><see cref="ValueTuple{T1, T2}">ValueTuple</see> of traffic light clock face observed binary codes strings value.</param>
        /// <exception cref="ArgumentNullException">Throws, if <paramref name="colorName" />, or any item of <paramref name="binaryCodesStrings" /> tuple is null one.</exception>
        /// <exception cref="WrongObservationDataException">Throws, if <paramref name="colorName" />, or any item of <paramref name="binaryCodesStrings" /> tuple is invalid one.</exception>
        public ObservedObjectStateModel(string colorName, ValueTuple<string, string> binaryCodesStrings)
        {
            this.tryRaiseColorNameExceptions(colorName);

            var (higherDigitCodeString, lowerDigitCodeString) = binaryCodesStrings;

            this.tryRaiseBinaryCodeStringExceptions(higherDigitCodeString, nameof(higherDigitCodeString));
            this.tryRaiseBinaryCodeStringExceptions(lowerDigitCodeString, nameof(lowerDigitCodeString));

            this.Color = ColorModel.FindByName(colorName, StringComparison.OrdinalIgnoreCase);

            var converter = ObservedObjectStateModel._conversionFactory.CreateByteToBinaryStringConverter();

            this.BinaryCodes = (
                converter.ConvertBack(higherDigitCodeString),
                converter.ConvertBack(lowerDigitCodeString)
            );
        }

        /// <summary>
        /// Additional constructor: only color name required, all binary codes will be strings of 0b0000_0000 values.
        /// </summary>
        /// <param name="colorName">Registered traffic light color name value.</param>
        public ObservedObjectStateModel(string colorName) : this(colorName, ("0000000", "0000000"))
        {
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static ObservedObjectStateModel()
        {
            ObservedObjectStateModel._validationFactory = new ValidationFactoryModel();
            ObservedObjectStateModel._conversionFactory = new ConversionFactoryModel();
        }

        #region Object overrides

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.Color}, {this.BinaryCodes}";
        }

        #endregion
    }
}
