using System;
using System.Linq;
using TrafficLightDataAnalyzer.Model.Conversion;

namespace TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value
{
    /// <summary>
    /// Traffic light two digit clock face binary codes value keeping model class.
    /// </summary>
    internal class BinaryCodesValueModel : BaseTwoDigitValueModel<byte>
    {
        /// <summary>
        /// <see cref="ConversionFactoryModel">ConversionFactoryModel</see> reference field.
        /// </summary>
        private static readonly ConversionFactoryModel _conversionFactory;

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="higherDigitData">Higher digit data value.</param>
        /// <param name="lowerDigitData">Lower digit data value.</param>
        public BinaryCodesValueModel(byte higherDigitData, byte lowerDigitData)
            : base(higherDigitData, lowerDigitData)
        {
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static BinaryCodesValueModel()
        {
            BinaryCodesValueModel._conversionFactory = new ConversionFactoryModel();
        }

        #region Object overrides

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var converter = BinaryCodesValueModel._conversionFactory.CreateByteToBinaryStringConverter();

            var convertedCodes = this
                .Select((digit) => converter.Convert(digit))
                .Select((codeString) => $"0b{codeString}");

            var codesString = string.Join(", ", convertedCodes);

            return $"Codes: [{codesString}]";
        }

        #endregion

        #region Conversions

        /// <summary>
        /// Implicit conversion from usual <see cref="ValueTuple{T1, T2}">ValueTuple</see> type.
        /// </summary>
        /// <param name="source">Source <see cref="ValueTuple{T1, T2}">ValueTuple</see> to convert.</param>
        public static implicit operator BinaryCodesValueModel(ValueTuple<byte, byte> source)
        {
            return new BinaryCodesValueModel(
                source.Item1,
                source.Item2
            );
        }

        #endregion
    }
}
