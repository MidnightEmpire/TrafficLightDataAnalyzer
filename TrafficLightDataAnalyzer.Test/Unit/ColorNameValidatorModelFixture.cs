using NUnit.Framework;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Validation;
using TrafficLightDataAnalyzer.Model.Validation.Validator.TrafficLight;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="ColorNameValidatorModel">ColorNameValidatorModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class ColorNameValidatorModelFixture
    {
        /// <summary>
        /// Proper instance of <see cref="IValidator{TObject}">IValidator</see> creation service method.
        /// </summary>
        /// <returns>Proper instance of <see cref="IValidator{TObject}">IValidator</see>.</returns>
        private IValidator<string> createValidator()
        {
            var validationFactory = new ValidationFactoryModel();

            return validationFactory.CreateColorNameValidator();
        }

        /// <summary>
        /// Invalid <see cref="ColorModel">ColorModel</see> name validation checking method.
        /// </summary>
        /// <param name="colorName">Invalid <see cref="ColorModel">ColorModel</see> color name value.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("deR")]
        [TestCase("0`")]
        public void IsValid_InvalidColorName_ReturnsFalse(string colorName)
        {
            var validator = this.createValidator();

            Assert.IsFalse(validator.IsValid(colorName));
        }

        /// <summary>
        /// Valid <see cref="ColorModel">ColorModel</see> name validation checking method.
        /// </summary>
        /// <param name="colorName">Valid <see cref="ColorModel">ColorModel</see> color name value.</param>
        [Test]
        [TestCase("Red")]
        [TestCase("red")]
        [TestCase("Green")]
        [TestCase("green")]
        public void IsValid_ValidColorName_ReturnsTrue(string colorName)
        {
            var validator = this.createValidator();

            Assert.IsTrue(validator.IsValid(colorName));
        }
    }
}
