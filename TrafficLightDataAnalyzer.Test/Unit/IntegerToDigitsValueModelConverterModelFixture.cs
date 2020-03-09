using NUnit.Framework;
using System;
using System.Collections.Generic;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Conversion;
using TrafficLightDataAnalyzer.Model.Conversion.Converter.TrafficLight.ClockFace;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="IntegerToDigitsValueModelConverterModel">IntegerToDigitsValueModelConverterModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class IntegerToDigitsValueModelConverterModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Valid integer to <see cref="DigitsValueModel">DigitsValueModel</see> conversion pair data test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> ValidConversionPairDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(33, new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit3));
                yield return new TestCaseData(51, new DigitsValueModel(DigitModel.Digit5, DigitModel.Digit1));
                yield return new TestCaseData(0,  new DigitsValueModel(DigitModel.Digit0, DigitModel.Digit0));
                yield return new TestCaseData(1,  new DigitsValueModel(DigitModel.Digit0, DigitModel.Digit1));
            }
        }

        /// <summary>
        /// Valid <see cref="DigitsValueModel">DigitsValueModel</see> to integer reverse-conversion pair data test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> ValidReverseConversionPairDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit3), 33);
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit5, DigitModel.Digit1), 51);
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit0, DigitModel.Digit0), 0);
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit0, DigitModel.Digit1), 1);
            }
        }

        /// <summary>
        /// Invalid <see cref="DigitsValueModel">DigitsValueModel</see> to integer reverse-conversion data test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> InvalidReverseConversionDigitsValuesDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(new DigitsValueModel(null, null));
                yield return new TestCaseData(new DigitsValueModel(null, DigitModel.Digit1));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit0, (DigitModel) null));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Undefined, DigitModel.Digit1));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit4, DigitModel.Undefined));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Undefined, DigitModel.Undefined));
            }
        }

        #endregion

        /// <summary>
        /// Proper instance of <see cref="ISimpleConverter{TSourceType, TTargetType}">ISimpleConverter</see> creation service method.
        /// </summary>
        /// <returns>Proper instance of <see cref="ISimpleConverter{TSourceType, TTargetType}">ISimpleConverter</see>.</returns>
        private ISimpleConverter<int, DigitsValueModel> createConverter()
        {
            var conversionFactory = new ConversionFactoryModel();

            return conversionFactory.CreateIntegerToDigitsValueModelConverter();
        }

        /// <summary>
        /// Conversion of source integer value with invalid (very big or small) value pass checking method.
        /// </summary>
        /// <param name="valueToConvert">Value, which one must be converted.</param>
        [Test]
        [TestCase(-4)]
        [TestCase(-1)]
        [TestCase(100)]
        [TestCase(342)]
        public void Convert_InvalidIntegerValue_ThrowsArgumentOutOfRangeException(int valueToConvert)
        {
            var converter = this.createConverter();

            Assert.Catch<ArgumentOutOfRangeException>(() => converter.Convert(valueToConvert));
        }

        /// <summary>
        /// Conversion of valid source integer value to <see cref="DigitsValueModel">DigitsValueModel</see> value checking method.
        /// </summary>
        /// <param name="valueToConvert">Value, which one must be converted.</param>
        /// <param name="expectedConvertedValue">Converted value.</param>
        [Test]
        [TestCaseSource(nameof(IntegerToDigitsValueModelConverterModelFixture.ValidConversionPairDataTestCaseCollection))]
        public void Convert_ValidValue_ReturnsProperlyConvertedValue(int valueToConvert, DigitsValueModel expectedConvertedValue)
        {
            var converter = this.createConverter();

            var convertedValue = converter.Convert(valueToConvert);

            Assert.AreEqual(expectedConvertedValue, convertedValue);
        }

        /// <summary>
        /// Reverse-conversion of source <see cref="DigitsValueModel">DigitsValueModel</see> with null <see cref="DigitsValueModel">DigitsValueModel</see> value pass checking method.
        /// </summary>
        [Test]
        public void ConvertBack_NullDigitsValueModel_ThrowsArgumentNullException()
        {
            var converter = this.createConverter();

            Assert.Catch<ArgumentNullException>(() => converter.ConvertBack(null));
        }

        /// <summary>
        /// Reverse-conversion of source <see cref="DigitsValueModel">DigitsValueModel</see> with invalid <see cref="DigitsValueModel">DigitsValueModel</see> value pass checking method.
        /// </summary>
        /// <param name="valueToConvert">Value, which one must be converted.</param>
        [Test]
        [TestCaseSource(nameof(IntegerToDigitsValueModelConverterModelFixture.InvalidReverseConversionDigitsValuesDataTestCaseCollection))]
        public void ConvertBack_InvalidDigitsValueModel_ThrowsInvalidArgumentStateException(DigitsValueModel valueToConvert)
        {
            var converter = this.createConverter();

            Assert.Catch<InvalidArgumentStateException>(() => converter.ConvertBack(valueToConvert));
        }

        /// <summary>
        /// Reverse-conversion of valid source <see cref="DigitsValueModel">DigitsValueModel</see> value to integer value checking method.
        /// </summary>
        /// <param name="valueToConvert">Value, which one must be converted.</param>
        /// <param name="expectedConvertedValue">Converted value.</param>
        [Test]
        [TestCaseSource(nameof(IntegerToDigitsValueModelConverterModelFixture.ValidReverseConversionPairDataTestCaseCollection))]
        public void ConvertBack_ValidValue_ReturnsProperlyConvertedValue(DigitsValueModel valueToConvert, int expectedConvertedValue)
        {
            var converter = this.createConverter();

            var convertedValue = converter.ConvertBack(valueToConvert);

            Assert.AreEqual(expectedConvertedValue, convertedValue);
        }
    }
}