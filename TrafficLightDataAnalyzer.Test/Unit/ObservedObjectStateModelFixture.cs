using NUnit.Framework;
using System;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Model.Observation.State.TrafficLight;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class ObservedObjectStateModelFixture
    {
        /// <summary>
        /// Source 7-digit <paramref name="binaryCodesObjects" /> array to <see cref="ValueTuple{T1, T2}">ValueTuple</see> conversion service method.
        /// </summary>
        /// <param name="binaryCodesObjects">7-digit binary codes strings (as objects) array value.</param>
        /// <returns>Properly converted <see cref="ValueTuple{T1, T2}">ValueTuple</see>.</returns>
        private ValueTuple<string, string> convertToTuple(object[] binaryCodesObjects)
        {
            return ((string) binaryCodesObjects[0], (string) binaryCodesObjects[1]);
        }

        /// <summary>
        /// <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see> constructor with null color name value pass checking method.
        /// </summary>
        [Test]
        public void Constructor_ColorNameIsNull_ThrowsArgumentNullException()
        {
            Assert.Catch<ArgumentNullException>(() => new ObservedObjectStateModel(null, ("0000000", "0000000")));
        }

        /// <summary>
        /// <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see> constructor with any null-containing <paramref name="binaryCodesObjects" /> value pass checking method.
        /// </summary>
        /// <param name="binaryCodesObjects">7-digit binary codes strings (as objects) array value.</param>
        [Test]
        [TestCase(new object[] { null, null })]
        [TestCase(new object[] { null, "0111111" })]
        [TestCase(new object[] { "1110111", null })]
        public void Constructor_AnyBinaryCodeStringIsNull_ThrowsArgumentNullException(object[] binaryCodesObjects)
        {
            var binaryCodesStrings = this.convertToTuple(binaryCodesObjects);

            Assert.Catch<ArgumentNullException>(() => new ObservedObjectStateModel("red", binaryCodesStrings));
        }

        /// <summary>
        /// <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see> constructor with invalid <paramref name="colorName" /> value pass checking method.
        /// </summary>
        /// <param name="colorName">Traffic light color name value.</param>
        [Test]
        [TestCase("")]
        [TestCase("red1")]
        [TestCase("deR")]
        [TestCase("undefined")]
        [TestCase("_11")]
        public void Constructor_InvalidColorName_ThrowsWrongObservationDataException(string colorName)
        {
            Assert.Catch<WrongObservationDataException>(() => new ObservedObjectStateModel(colorName, ("0000000", "0000000")));
        }

        /// <summary>
        /// <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see> constructor with any invalid-containing <paramref name="binaryCodesObjects" /> value pass checking method.
        /// </summary>
        /// <param name="binaryCodesObjects">7-digit binary codes strings (as objects) array value.</param>
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
        public void Constructor_AnyBinaryCodeStringIsInvalid_ThrowsWrongObservationDataException(object[] binaryCodesObjects)
        {
            var binaryCodesStrings = this.convertToTuple(binaryCodesObjects);

            Assert.Catch<WrongObservationDataException>(() => new ObservedObjectStateModel("red", binaryCodesStrings));
        }

        /// <summary>
        /// <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see> constructor with valid
        /// <paramref name="colorName" /> and <paramref name="binaryCodesObjects" /> values pass checking method.
        /// </summary>
        /// <param name="colorName">Traffic light color name value.</param>
        /// <param name="binaryCodesObjects">7-digit binary codes strings (as objects) array value.</param>
        [Test]
        [TestCase("red", new object[] { "1111111", "0111011" })]
        [TestCase("rEd", new object[] { "1111110", "0000000" })]
        [TestCase("green", new object[] { "1111111", "1101111" })]
        [TestCase("grEen", new object[] { "1101110", "1010101" })]
        public void Constructor_ValidArguments_ThrowsNoException(string colorName, object[] binaryCodesObjects)
        {
            var binaryCodesStrings = this.convertToTuple(binaryCodesObjects);

            Assert.DoesNotThrow(() => new ObservedObjectStateModel(colorName, binaryCodesStrings));
        }
    }
}
