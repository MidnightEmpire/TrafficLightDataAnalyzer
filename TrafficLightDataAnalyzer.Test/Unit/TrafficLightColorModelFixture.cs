using NUnit.Framework;
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
    }
}
