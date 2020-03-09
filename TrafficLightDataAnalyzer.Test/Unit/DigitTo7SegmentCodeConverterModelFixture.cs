using NUnit.Framework;
using System;
using System.Collections.Generic;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Conversion;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="DigitTo7SegmentCodeConverterModel">ByteToBinaryStringConverterModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class DigitTo7SegmentCodeConverterModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Valid <see cref="DigitModel">DigitModel</see> to 7-segment digit code conversion pair data test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> ValidConversionPairDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(DigitModel.Digit0, (byte) 0b0111_0111);
                yield return new TestCaseData(DigitModel.Digit3, (byte) 0b0101_1011);
                yield return new TestCaseData(DigitModel.Digit9, (byte) 0b0111_1011);
            }
        }

        /// <summary>
        /// Valid 7-segment digit code to <see cref="DigitModel">DigitModel</see> reverse-conversion pair data test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> ValidReverseConversionPairDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData((byte) 0b0111_0111, DigitModel.Digit0);
                yield return new TestCaseData((byte) 0b0101_1011, DigitModel.Digit3);
                yield return new TestCaseData((byte) 0b0111_1011, DigitModel.Digit9);
            }
        }

        #endregion

        /// <summary>
        /// Proper instance of <see cref="ISimpleConverter{TSourceType, TTargetType}">ISimpleConverter</see> creation service method.
        /// </summary>
        /// <returns>Proper instance of <see cref="ISimpleConverter{TSourceType, TTargetType}">ISimpleConverter</see>.</returns>
        private ISimpleConverter<DigitModel, byte> createConverter()
        {
            var conversionFactory = new ConversionFactoryModel();

            return conversionFactory.CreateDigitTo7SegmentCodeConverter();
        }

        /// <summary>
        /// Conversion of source <see cref="DigitModel">DigitModel</see> with null <see cref="DigitModel">DigitModel</see> value pass checking method.
        /// </summary>
        [Test]
        public void Convert_NullDigitModel_ThrowsArgumentNullException()
        {
            var converter = this.createConverter();

            Assert.Catch<ArgumentNullException>(() => converter.Convert(null));
        }

        /// <summary>
        /// Conversion of source <see cref="DigitModel">DigitModel</see> with <see cref="DigitModel.Undefined">Undefined</see> value pass checking method.
        /// </summary>
        [Test]
        public void Convert_UndefinedDigitModel_ThrowsArgumentOutOfRangeException()
        {
            var converter = this.createConverter();

            Assert.Catch<ArgumentOutOfRangeException>(() => converter.Convert(DigitModel.Undefined));
        }

        /// <summary>
        /// Conversion of valid source <see cref="DigitModel">DigitModel</see> value to 7-segment code value checking method.
        /// </summary>
        /// <param name="valueToConvert">Value, which one must be converted.</param>
        /// <param name="expectedConvertedValue">Converted value.</param>
        [Test]
        [TestCaseSource(nameof(DigitTo7SegmentCodeConverterModelFixture.ValidConversionPairDataTestCaseCollection))]
        public void Convert_ValidValue_ReturnsProperlyConvertedValue(DigitModel valueToConvert, byte expectedConvertedValue)
        {
            var converter = this.createConverter();

            var convertedValue = converter.Convert(valueToConvert);

            Assert.AreEqual(expectedConvertedValue, convertedValue);
        }

        /// <summary>
        /// Reverse-conversion of invalid binary source string value to byte value checking method.
        /// </summary>
        /// <param name="valueToConvert">Value, which one must be converted.</param>
        [Test]
        [TestCase(0b1000_0000)]
        [TestCase(0b0000_0001)]
        [TestCase(0b0000_0000)]
        [TestCase(0b0011_1111)]
        public void ConvertBack_Invalid7SegmentCode_ReturnsUndefinedDigitModel(byte valueToConvert)
        {
            var converter = this.createConverter();

            var convertedValue = converter.ConvertBack(valueToConvert);

            Assert.AreEqual(DigitModel.Undefined, convertedValue);
        }

        /// <summary>
        /// Reverse-conversion of valid source 7-segment code value to <see cref="DigitModel">DigitModel</see> value checking method.
        /// </summary>
        /// <param name="valueToConvert">Value, which one must be converted.</param>
        /// <param name="expectedConvertedValue">Converted value.</param>
        [Test]
        [TestCaseSource(nameof(DigitTo7SegmentCodeConverterModelFixture.ValidReverseConversionPairDataTestCaseCollection))]
        public void ConvertBack_ValidValue_ReturnsProperlyConvertedValue(byte valueToConvert, DigitModel expectedConvertedValue)
        {
            var converter = this.createConverter();

            var convertedValue = converter.ConvertBack(valueToConvert);

            Assert.AreEqual(expectedConvertedValue, convertedValue);
        }
    }
}