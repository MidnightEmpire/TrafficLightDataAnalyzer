using System;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;
using TrafficLightDataAnalyzer.Model.Validation;

namespace TrafficLightDataAnalyzer.Model.Conversion.Converter.TrafficLight.ClockFace
{
    /// <summary>
    /// Integer to traffic light two-digit clock face <see cref="DigitModel">digits</see> value model convertor model class.
    /// </summary>
    internal class IntegerToDigitsValueModelConverterModel : ISimpleConverter<int, DigitsValueModel>
    {
        /// <summary>
        /// <see cref="ValidationFactoryModel">ValidationFactoryModel</see> reference field.
        /// </summary>
        private static readonly ValidationFactoryModel _validationFactory;

        /// <summary>
        /// Value conversion method.
        /// </summary>
        /// <param name="source">Source value to convert.</param>
        /// <returns>Result/converted value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws, if <paramref name="source" /> is less than 0, or has 3 or more digits.</exception>
        /// <exception cref="InvalidOperationException">Throws, if <see cref="DigitModel">DigitModel</see> has invalid state (some digits are missing ones).</exception>
        public DigitsValueModel Convert(int source)
        {
            if (source < 0 ||
                source > 99
            ) {
                throw new ArgumentOutOfRangeException(nameof(source));
            }

            var lowerDigitValue = source % 10;
            var higherDigitValue = (source - lowerDigitValue) / 10;

            var higherDigit = DigitModel.FindByValue((sbyte) higherDigitValue);
            var lowerDigit = DigitModel.FindByValue((sbyte) lowerDigitValue);

            if (lowerDigit is null ||
                higherDigit is null
            ) {
                throw new InvalidOperationException(nameof(DigitModel.FindByValue));
            }

            return new DigitsValueModel(higherDigit, lowerDigit);
        }

        /// <summary>
        /// Value reverse-conversion method.
        /// </summary>
        /// <param name="source">Source value to reverse-convert.</param>
        /// <returns>Result/reverse-converted value.</returns>
        /// <exception cref="ArgumentNullException">Throws, if <paramref name="source" /> is null.</exception>
        /// <exception cref="InvalidArgumentStateException">Throws, if one of the <see cref="DigitsValueModel">DigitsValueModel</see> digits is null or undefined one.</exception>
        public int ConvertBack(DigitsValueModel source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var sourceValidator = IntegerToDigitsValueModelConverterModel._validationFactory.CreateDigitsValueValidator();

            if (!sourceValidator.IsValid(source))
            {
                throw new InvalidArgumentStateException(nameof(source));
            }

            return 10 * source.HigherDigitData.Value + source.LowerDigitData.Value;
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static IntegerToDigitsValueModelConverterModel()
        {
            IntegerToDigitsValueModelConverterModel._validationFactory = new ValidationFactoryModel();
        }
    }
}