using NUnit.Framework;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Conversion;
using TrafficLightDataAnalyzer.Model.Conversion.Converter;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="ByteToBinaryStringConverterModel">ByteToBinaryStringConverterModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class ByteToBinaryStringConverterModelFixture
    {
        /// <summary>
        /// Proper instance of <see cref="ISimpleConverter{TSourceType, TTargetType}">ISimpleConverter</see> creation service method.
        /// </summary>
        /// <returns>Proper instance of <see cref="ISimpleConverter{TSourceType, TTargetType}">ISimpleConverter</see>.</returns>
        private ISimpleConverter<byte, string> createConverter()
        {
            var conversionFactory = new ConversionFactoryModel();

            return conversionFactory.CreateByteToBinaryStringConverter();
        }

        /// <summary>
        /// Conversion of source byte value to binary string checking method.
        /// </summary>
        /// <param name="valueToConvert">Value, which one must be converted.</param>
        /// <param name="expectedConvertedValue">Converted value.</param>
        [Test]
        [TestCase(0, "00000000")]
        [TestCase(3, "00000011")]
        [TestCase(8, "00001000")]
        [TestCase(100, "01100100")]
        public void Convert_ValidValue_ReturnsProperlyConvertedValue(byte valueToConvert, string expectedConvertedValue)
        {
            var converter = this.createConverter();

            var convertedValue = converter.Convert(valueToConvert);

            Assert.AreEqual(expectedConvertedValue, convertedValue);
        }

        /// <summary>
        /// Reverse-conversion of valid binary source string value to byte value checking method.
        /// </summary>
        /// <param name="valueToConvert">Value, which one must be converted.</param>
        /// <param name="expectedConvertedValue">Converted value.</param>
        [Test]
        [TestCase("00000000", 0)]
        [TestCase("00", 0)]
        [TestCase("00000011", 3)]
        [TestCase("00001000", 8)]
        [TestCase("01100100", 100)]
        [TestCase("1100100", 100)]
        public void ConvertBack_ValidBinaryStringValue_ReturnsProperlyConvertedValue(string valueToConvert, byte expectedConvertedValue)
        {
            var converter = this.createConverter();

            var convertedValue = converter.ConvertBack(valueToConvert);

            Assert.AreEqual(expectedConvertedValue, convertedValue);
        }

        /// <summary>
        /// Reverse-conversion of invalid binary source string value to byte value checking method.
        /// </summary>
        /// <param name="valueToConvert">Value, which one must be converted.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("111111111")]
        [TestCase("000a0000")]
        [TestCase("0`")]
        [TestCase("0 000100")]
        public void ConvertBack_InvalidBinaryStringValue_ThrowsException(string valueToConvert)
        {
            var converter = this.createConverter();

            Assert.Catch<System.Exception>(() => converter.ConvertBack(valueToConvert));
        }
    }
}
