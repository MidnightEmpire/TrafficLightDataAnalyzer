using NUnit.Framework;
using System.Collections.Generic;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;
using TrafficLightDataAnalyzer.Model.Validation;
using TrafficLightDataAnalyzer.Model.Validation.Validator.TrafficLight;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="DigitsValueValidatorModel">DigitsValueValidatorModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class DigitsValueValidatorModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Valid <see cref="DigitsValueModel">DigitsValueModel</see> values test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> ValidDigitsValuesTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit1, DigitModel.Digit3));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit0, DigitModel.Digit0));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit9, DigitModel.Digit5));
            }
        }

        /// <summary>
        /// Invalid <see cref="DigitsValueModel">DigitsValueModel</see> values test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> InvalidDigitsValuesTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(new DigitsValueModel(null, null));
                yield return new TestCaseData(new DigitsValueModel(null, DigitModel.Digit3));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit3, null));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Undefined, DigitModel.Digit5));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit5, DigitModel.Undefined));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Undefined, DigitModel.Undefined));
            }
        }

        #endregion

        /// <summary>
        /// Proper instance of <see cref="IValidator{TObject}">IValidator</see> creation service method.
        /// </summary>
        /// <returns>Proper instance of <see cref="IValidator{TObject}">IValidator</see>.</returns>
        private IValidator<DigitsValueModel> createValidator()
        {
            var validationFactory = new ValidationFactoryModel();

            return validationFactory.CreateDigitsValueValidator();
        }

        /// <summary>
        /// Invalid <see cref="DigitsValueModel">DigitsValueModel</see> value validation checking method.
        /// </summary>
        /// <param name="digitsValue">Invalid <see cref="DigitsValueModel">DigitsValueModel</see> value.</param>
        [Test]
        [TestCaseSource(nameof(DigitsValueValidatorModelFixture.InvalidDigitsValuesTestCaseCollection))]
        public void IsValid_InvalidDigitsValues_ReturnsFalse(DigitsValueModel digitsValue)
        {
            var validator = this.createValidator();

            Assert.IsFalse(validator.IsValid(digitsValue));
        }

        /// <summary>
        /// Valid <see cref="DigitsValueModel">DigitsValueModel</see> value validation checking method.
        /// </summary>
        /// <param name="digitsValue">Valid <see cref="DigitsValueModel">DigitsValueModel</see> value.</param>
        [Test]
        [TestCaseSource(nameof(DigitsValueValidatorModelFixture.ValidDigitsValuesTestCaseCollection))]
        public void IsValid_ValidDigitsValue_ReturnsTrue(DigitsValueModel digitsValue)
        {
            var validator = this.createValidator();

            Assert.IsTrue(validator.IsValid(digitsValue));
        }
    }
}
