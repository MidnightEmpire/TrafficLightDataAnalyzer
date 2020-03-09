using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Conversion.Converter;
using TrafficLightDataAnalyzer.Model.Conversion.Converter.TrafficLight.ClockFace;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;

namespace TrafficLightDataAnalyzer.Model.Conversion
{
    /// <summary>
    /// Conversion factory model class.
    /// </summary>
    internal class ConversionFactoryModel
    {
        /// <summary>
        /// 7-segment binary code pattern mask constant.
        /// </summary>
        public const byte SevenSegmentBinaryCodePatternMask = 0b0111_1111;

        /// <summary>
        /// <see cref="ByteToBinaryStringConverterModel">ByteToBinaryStringConverterModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="ByteToBinaryStringConverterModel">ByteToBinaryStringConverterModel</see>.</returns>
        public ISimpleConverter<byte, string> CreateByteToBinaryStringConverter()
        {
            return new ByteToBinaryStringConverterModel();
        }

        /// <summary>
        /// <see cref="DigitTo7SegmentCodeConverterModel">DigitTo7SegmentCodeConverterModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="DigitTo7SegmentCodeConverterModel">DigitTo7SegmentCodeConverterModel</see>.</returns>
        public ISimpleConverter<DigitModel, byte> CreateDigitTo7SegmentCodeConverter()
        {
            return new DigitTo7SegmentCodeConverterModel();
        }

        /// <summary>
        /// <see cref="IntegerToDigitsValueModelConverterModel">IntegerToDigitsValueModelConverterModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="IntegerToDigitsValueModelConverterModel">IntegerToDigitsValueModelConverterModel</see>.</returns>
        public ISimpleConverter<int, DigitsValueModel> CreateIntegerToDigitsValueModelConverter()
        {
            return new IntegerToDigitsValueModelConverterModel();
        }
    }
}
