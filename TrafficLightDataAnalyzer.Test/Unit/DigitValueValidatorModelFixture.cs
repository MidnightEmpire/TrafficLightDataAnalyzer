using NUnit.Framework;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Validation;
using TrafficLightDataAnalyzer.Model.Validation.Validator.TrafficLight;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="DigitValueValidatorModel">DigitValueValidatorModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class DigitValueValidatorModelFixture
    {
        /// <summary>
        /// Proper instance of <see cref="IValidator{TObject}">IValidator</see> creation service method.
        /// </summary>
        /// <returns>Proper instance of <see cref="IValidator{TObject}">IValidator</see>.</returns>
        private IValidator<sbyte> createValidator()
        {
            var validationFactory = new ValidationFactoryModel();

            return validationFactory.CreateDigitValueValidator();
        }

        /// <summary>
        /// Invalid <see cref="DigitModel">DigitModel</see> value validation checking method.
        /// </summary>
        /// <param name="digitValue">Invalid <see cref="DigitModel">DigitModel</see> value.</param>
        [Test]
        [TestCase(-2)]
        [TestCase(88)]
        public void IsValid_InvalidDigitValue_ReturnsFalse(sbyte digitValue)
        {
            var validator = this.createValidator();

            Assert.IsFalse(validator.IsValid(digitValue));
        }

        /// <summary>
        /// Valid <see cref="DigitModel">DigitModel</see> value validation checking method.
        /// </summary>
        /// <param name="digitValue">Valid <see cref="DigitModel">DigitModel</see> value.</param>
        [Test]
        [TestCase(0)]
        [TestCase(6)]
        public void IsValid_ValidDigitValue_ReturnsTrue(sbyte digitValue)
        {
            var validator = this.createValidator();

            Assert.IsTrue(validator.IsValid(digitValue));
        }
    }
}
