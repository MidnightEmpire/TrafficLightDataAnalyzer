using NUnit.Framework;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Validation;
using TrafficLightDataAnalyzer.Model.Validation.Validator.TrafficLight;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="SevenSegmentBinaryCodeStringValidatorModel">SevenSegmentBinaryCodeStringValidatorModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class SevenSegmentBinaryCodeStringValidatorModelFixture
    {
        /// <summary>
        /// Proper instance of <see cref="IValidator{TObject}">IValidator</see> creation service method.
        /// </summary>
        /// <returns>Proper instance of <see cref="IValidator{TObject}">IValidator</see>.</returns>
        private IValidator<string> createValidator()
        {
            var validationFactory = new ValidationFactoryModel();

            return validationFactory.CreateSevenSegmentBinaryCodeStringValidator();
        }

        /// <summary>
        /// Invalid 7-segment binary code validation checking method.
        /// </summary>
        /// <param name="binaryCodeString">7-segment binary code string value.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("011101101")]
        [TestCase("011")]
        [TestCase("111a111")]
        [TestCase("???????")]
        [TestCase("000 1111")]
        [TestCase("000 111")]
        [TestCase("\r\n")]
        public void IsValid_Invalid7SegmentBinaryCodeString_ReturnsFalse(string binaryCodeString)
        {
            var validator = this.createValidator();

            Assert.IsFalse(validator.IsValid(binaryCodeString));
        }

        /// <summary>
        /// Valid 7-segment binary code validation checking method.
        /// </summary>
        /// <param name="binaryCodeString">7-segment binary code string value.</param>
        [Test]
        [TestCase("0000001")]
        [TestCase("0101010")]
        [TestCase("1111000")]
        [TestCase("0000000")]
        public void IsValid_Valid7SegmentBinaryCodeString_ReturnsTrue(string binaryCodeString)
        {
            var validator = this.createValidator();

            Assert.IsTrue(validator.IsValid(binaryCodeString));
        }
    }
}
