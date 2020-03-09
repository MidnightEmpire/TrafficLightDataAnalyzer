using NUnit.Framework;
using System;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Validation;
using TrafficLightDataAnalyzer.Model.Validation.Validator.Common;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="GuidStringFormatValidatorModel">GuidStringFormatValidatorModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class GuidStringFormatValidatorModelFixture
    {
        /// <summary>
        /// Proper instance of <see cref="IValidator{TObject}">IValidator</see> creation service method.
        /// </summary>
        /// <returns>Proper instance of <see cref="IValidator{TObject}">IValidator</see>.</returns>
        private IValidator<string> createValidator()
        {
            var validationFactory = new ValidationFactoryModel();

            return validationFactory.CreateGuidStringFormatValidator();
        }

        /// <summary>
        /// Invalid <see cref="Guid">GUID</see> string validation checking method.
        /// </summary>
        /// <param name="guidString"><see cref="Guid">GUID</see> string value.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("000000000000x0000000000000000000")]
        [TestCase("000000000afaq0000000000000000000")]
        [TestCase("00000000/0000-0000-0000-0000000000001")]
        [TestCase("00000000-0000-0000-0000-0ff00a000")]
        public void IsValid_Invalid7SegmentBinaryCodeString_ReturnsFalse(string guidString)
        {
            var validator = this.createValidator();

            Assert.IsFalse(validator.IsValid(guidString));
        }

        /// <summary>
        /// Valid <see cref="Guid">GUID</see> string validation checking method.
        /// </summary>
        /// <param name="guidString"><see cref="Guid">GUID</see> string value.</param>
        [Test]
        [TestCase("00000000000000000000000000000000")]
        [TestCase("0000000000000000aaf0000000000000")]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("00000000-0000-0000-0000-0ff0ba000000")]
        public void IsValid_Valid7SegmentBinaryCodeString_ReturnsTrue(string guidString)
        {
            var validator = this.createValidator();

            Assert.IsTrue(validator.IsValid(guidString));
        }
    }
}
