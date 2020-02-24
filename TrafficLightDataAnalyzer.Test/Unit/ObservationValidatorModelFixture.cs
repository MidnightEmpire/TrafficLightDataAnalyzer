using NUnit.Framework;
using System.Linq;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Model.Observation.Validator;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// Observation validator model tests fixture
    /// </summary>
    [TestFixture]
    internal class ObservationValidatorModelFixture
    {
        /// <summary>
        /// Observation validator doesn't throw any exception if valid color model name passed in validation method
        /// </summary>
        /// <param name="colorName">Traffic light color name value</param>
        [Test]
        [TestCase("red")]
        [TestCase("Red")]
        [TestCase("green")]
        [TestCase("Green")]
        public void ObservationValidatorModel_WhenCheckingValidTrafficLightColorName_MethodPassedWithNoException(string colorName)
        {
            var observationValidatorModel = new ObservationValidatorModel();

            Assert.DoesNotThrow(() => observationValidatorModel.ValidateTrafficLightColorName(colorName));
        }

        /// <summary>
        /// Observation validator throws exception if invalid color model name passed in validation method
        /// </summary>
        /// <param name="colorName">Traffic light color name value</param>
        [Test]
        [TestCase("red1")]
        [TestCase("deR")]
        [TestCase("undefined")]
        [TestCase("_11")]
        [TestCase("")]
        [TestCase(null)]
        public void ObservationValidatorModel_WhenCheckingInvalidTrafficLightColorName_MethodThrowsWrongObservationDataException(string colorName)
        {
            var observationValidatorModel = new ObservationValidatorModel();

            Assert.Catch<WrongObservationDataException>(() => observationValidatorModel.ValidateTrafficLightColorName(colorName));
        }

        /// <summary>
        /// Observation validator throws exception if invalid-sized binary code strings array passed in validation method
        /// </summary>
        /// <param name="binaryCodesObjects">Registered digits binary codes strings packed to objects array reference value</param>
        [Test]
        [TestCase(new object[] { "1111111" })]
        [TestCase(new object[] { "1111111", "1101111", "0111111" })]
        [TestCase(new object[] { "1110111", "0111111", "0111111", "1111111" })]
        public void ObservationValidatorModel_WhenCheckingWrongSizedBinaryCodesStrings_MethodThrowsWrongObservationDataException(object[] binaryCodesObjects)
        {
            var binaryCodeStrings = binaryCodesObjects
                .Cast<string>()
                .ToArray();

            var observationValidatorModel = new ObservationValidatorModel();

            Assert.Catch<WrongObservationDataException>(() => observationValidatorModel.ValidateBinaryCodesStrings(binaryCodeStrings));
        }

        /// <summary>
        /// Observation validator throws exception if invalid-sized binary code strings array passed in validation method
        /// </summary>
        /// <param name="binaryCodesObjects">Registered digits binary codes strings packed to objects array reference value</param>
        [Test]
        [TestCase(new object[] { "1111111", "0111011" })]
        [TestCase(new object[] { "1111111", "1101111" })]
        [TestCase(new object[] { "1101110", "1010101" })]
        public void ObservationValidatorModel_WhenCheckingValidBinaryCodesStrings_MethodPassedWithNoException(object[] binaryCodesObjects)
        {
            var binaryCodeStrings = binaryCodesObjects
                .Cast<string>()
                .ToArray();

            var observationValidatorModel = new ObservationValidatorModel();

            Assert.DoesNotThrow(() => observationValidatorModel.ValidateBinaryCodesStrings(binaryCodeStrings));
        }

        /// <summary>
        /// Observation validator throws exception if invalid-value-containig binary code strings array passed in validation method
        /// </summary>
        /// <param name="binaryCodesObjects">Registered digits binary codes strings packed to objects array reference value</param>
        [Test]
        [TestCase(new object[] { "111a111", "0111011" })]
        [TestCase(new object[] { "1111111", "011a011" })]
        [TestCase(new object[] { "111111", "0111011" })]
        [TestCase(new object[] { "1111111", "011011" })]
        [TestCase(new object[] { "???????", "" })]
        [TestCase(new object[] { "", "???????" })]
        [TestCase(new object[] { "13331", "1" })]
        [TestCase(new object[] { "1", "13331" })]
        [TestCase(new object[] { "\r\n", "1010101" })]
        [TestCase(new object[] { "1010101", "\r\n" })]
        public void ObservationValidatorModel_WhenCheckingInvalidValueContainingBinaryCodesStrings_MethodThrowsWrongObservationDataException(object[] binaryCodesObjects)
        {
            var binaryCodeStrings = binaryCodesObjects
                .Cast<string>()
                .ToArray();

            var observationValidatorModel = new ObservationValidatorModel();

            Assert.Catch<WrongObservationDataException>(() => observationValidatorModel.ValidateBinaryCodesStrings(binaryCodeStrings));
        }
    }
}
