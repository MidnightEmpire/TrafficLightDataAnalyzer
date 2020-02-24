using NUnit.Framework;
using System;
using System.Collections.Generic;
using TrafficLightDataAnalyzer.Common;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// Traffic light color model tests fixture
    /// </summary>
    [TestFixture]
    internal class TrafficLightColorModelFixture
    {
        /// <summary>
        /// Equal traffic light color model test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> EqualTrafficLightColorModelTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(NullInstance.Of<SevenSegmentDigitModel>(), NullInstance.Of<SevenSegmentDigitModel>());
                yield return new TestCaseData(TrafficLightColorModel.Undefined, TrafficLightColorModel.Undefined);
                yield return new TestCaseData(TrafficLightColorModel.Red, TrafficLightColorModel.Red);
                yield return new TestCaseData(TrafficLightColorModel.Green, TrafficLightColorModel.Green);
            }
        }

        /// <summary>
        /// Inequal traffic light color model test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> InequalTrafficLightColorModelTestCaseCollection
        {
            get
            {
                var allColors = TrafficLightColorModel.AllColors;
                var allColorsCount = allColors.Count;

                for (int i = allColorsCount + 1; --i >= 0;)
                {
                    for (int j = allColorsCount + 1; --j >= 0;)
                    {
                        if (i != j)
                        {
                            var firstColor = i == allColorsCount ? null : allColors[i];
                            var secondColor = j == allColorsCount ? null : allColors[j];

                            yield return new TestCaseData(firstColor, secondColor);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Valid traffic light color model names with corresponding models test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> ValidTrafficLightColorModelNamesTestCaseCollection
        {
            get
            {
                yield return new TestCaseData("Red", TrafficLightColorModel.Red);
                yield return new TestCaseData("Green", TrafficLightColorModel.Green);
            }
        }

        /// <summary>
        /// Invalid traffic light color model names test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> InvalidTrafficLightColorModelNamesTestCaseCollection
        {
            get
            {
                yield return new TestCaseData("unknowncolor");
                yield return new TestCaseData("_sdf_1");
                yield return new TestCaseData(string.Empty);
                yield return new TestCaseData(null);
            }
        }

        /// <summary>
        /// Equality checking method
        /// </summary>
        /// <param name="first">First traffic light color model to compare</param>
        /// <param name="second">Second traffic light color model to compare</param>
        [Test]
        [TestCaseSource("EqualTrafficLightColorModelTestCaseCollection")]
        public void TrafficLightColorModel_WhenCheckEquality_ReturnProperEqualityResult(TrafficLightColorModel first, TrafficLightColorModel second)
        {
            Assert.IsTrue(first == second);
        }

        /// <summary>
        /// Inequality checking method
        /// </summary>
        /// <param name="first">First traffic light color model to compare</param>
        /// <param name="second">Second traffic light color model to compare</param>
        [Test]
        [TestCaseSource("InequalTrafficLightColorModelTestCaseCollection")]
        public void TrafficLightColorModel_WhenCheckInequality_ReturnProperInequalityResult(TrafficLightColorModel first, TrafficLightColorModel second)
        {
            Assert.IsTrue(first != second);
        }

        /// <summary>
        /// Correct name finding checking method
        /// </summary>
        /// <param name="colorName">Correct traffic light color name value</param>
        /// <param name="expectedColorModel">Expected traffic light color model class reference value</param>
        [Test]
        [TestCaseSource("ValidTrafficLightColorModelNamesTestCaseCollection")]
        public void TrafficLightColorModel_WhenSearchingByValidColorName_ReturnProperColorModel(string colorName, TrafficLightColorModel expectedColorModel)
        {
            var foundColorModel = TrafficLightColorModel.FindByName(colorName);

            Assert.AreEqual(expectedColorModel, foundColorModel);
        }

        /// <summary>
        /// Correct name finding with ignore case checking method
        /// </summary>
        /// <param name="colorName">Correct traffic light color name value</param>
        /// <param name="expectedColorModel">Expected traffic light color model class reference value</param>
        [Test]
        [TestCaseSource("ValidTrafficLightColorModelNamesTestCaseCollection")]
        public void TrafficLightColorModel_WhenSearchingByValidColorNameWithIgnoredCase_ReturnProperColorModel(string colorName, TrafficLightColorModel expectedColorModel)
        {
            var foundColorModel = TrafficLightColorModel.FindByName(colorName?.ToLower(), StringComparison.OrdinalIgnoreCase);

            Assert.AreEqual(expectedColorModel, foundColorModel);
        }

        /// <summary>
        /// Incorrect name finding checking method
        /// </summary>
        /// <param name="colorName">Incorrect color name value</param>
        [Test]
        [TestCaseSource("InvalidTrafficLightColorModelNamesTestCaseCollection")]
        public void TrafficLightColorModel_WhenSearchingByInvalidColorName_ReturnUndefinedColorModel(string colorName)
        {
            var foundColorModel = TrafficLightColorModel.FindByName(colorName);

            Assert.AreEqual(TrafficLightColorModel.Undefined, foundColorModel);
        }

        /// <summary>
        /// Incorrect name finding with ignored case checking method
        /// </summary>
        /// <param name="colorName">Incorrect color name value</param>
        [Test]
        [TestCaseSource("InvalidTrafficLightColorModelNamesTestCaseCollection")]
        public void TrafficLightColorModel_WhenSearchingByInvalidColorNameWithIgnoredCase_ReturnUndefinedColorModel(string colorName)
        {
            var foundColorModel = TrafficLightColorModel.FindByName(colorName, StringComparison.OrdinalIgnoreCase);

            Assert.AreEqual(TrafficLightColorModel.Undefined, foundColorModel);
        }
    }
}
