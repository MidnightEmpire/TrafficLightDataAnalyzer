using System;
using System.Linq;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Conversion;

namespace TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value
{
    /// <summary>
    /// Traffic light two digit clock face <see cref="DigitModel">digits</see> value keeping model class.
    /// </summary>
    internal class DigitsValueModel : BaseTwoDigitValueModel<DigitModel>
    {
        /// <summary>
        /// <see cref="ConversionFactoryModel">ConversionFactoryModel</see> reference field.
        /// </summary>
        private static readonly ConversionFactoryModel _conversionFactory;

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="higherDigitData">Higher <see cref="DigitModel">digit data</see> value.</param>
        /// <param name="lowerDigitData">Lower <see cref="DigitModel">digit data</see> value.</param>
        public DigitsValueModel(DigitModel higherDigitData, DigitModel lowerDigitData)
            : base(higherDigitData, lowerDigitData)
        {
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static DigitsValueModel()
        {
            DigitsValueModel._conversionFactory = new ConversionFactoryModel();
        }

        #region Object overrides

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var digitsString = string.Join(", ", this.Select((digit) => DigitModel.ToString(digit)));

            return $"Digits: [{digitsString}]";
        }

        #endregion

        #region Conversions

        /// <summary>
        /// Implicit conversion from usual <see cref="ValueTuple{T1, T2}">ValueTuple</see> type.
        /// </summary>
        /// <param name="source">Source <see cref="ValueTuple{T1, T2}">ValueTuple</see> to convert.</param>
        public static implicit operator DigitsValueModel(ValueTuple<DigitModel, DigitModel> source)
        {
            return new DigitsValueModel(
                source.Item1,
                source.Item2
            );
        }

        /// <summary>
        /// Implicit conversion from usual integer value.
        /// </summary>
        /// <param name="source">Source integer value to convert.</param>
        public static implicit operator DigitsValueModel(int source)
        {
            var converter = DigitsValueModel._conversionFactory.CreateIntegerToDigitsValueModelConverter();

            return converter.Convert(source);
        }

        #endregion
    }
}
