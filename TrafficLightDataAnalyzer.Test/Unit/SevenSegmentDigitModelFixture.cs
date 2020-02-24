using NUnit.Framework;
using System.Collections.Generic;
using TrafficLightDataAnalyzer.Common;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// Temporary stub fixture
    /// </summary>
    [TestFixture]
    class SevenSegmentDigitModelFixture
    {
        /// <summary>
        /// Equal 7-segment digit models test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> EqualSevenSegmentDigitModelsTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(NullInstance.Of<SevenSegmentDigitModel>(), NullInstance.Of<SevenSegmentDigitModel>());
                yield return new TestCaseData(SevenSegmentDigitModel.Digit0, SevenSegmentDigitModel.Digit0);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit1, SevenSegmentDigitModel.Digit1);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit2, SevenSegmentDigitModel.Digit2);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit3);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit4);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit5, SevenSegmentDigitModel.Digit5);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit6, SevenSegmentDigitModel.Digit6);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit7, SevenSegmentDigitModel.Digit7);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit8, SevenSegmentDigitModel.Digit8);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit9, SevenSegmentDigitModel.Digit9);
            }
        }

        /// <summary>
        /// Inqqual 7-segment digit models test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> InequalSevenSegmentDigitModelsTestCaseCollection
        {
            get
            {
                var allDigits = SevenSegmentDigitModel.AllDigits;

                for (int i = 0; i < 11; ++i)
                {
                    for (int j = 0; j < 11; ++j)
                    {
                        if (i != j)
                        {
                            var firstDigit = i < 10 ? allDigits[i] : null;
                            var secondDigit = j < 10 ? allDigits[j] : null;

                            yield return new TestCaseData(firstDigit, secondDigit);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 7-segment digit model amount checking method
        /// </summary>
        [Test]
        public void SevenSegmentDigitModel_AllDigits_Containsly10Items()
        {
            var digitsAmout = SevenSegmentDigitModel.AllDigits.Count;

            Assert.AreEqual(digitsAmout, 10);
        }

        /// <summary>
        /// Equality checking method
        /// </summary>
        /// <param name="first">First 7-segment digit model to compare</param>
        /// <param name="second">Second 7-segment digit model to compare</param>
        [Test]
        [TestCaseSource("EqualSevenSegmentDigitModelsTestCaseCollection")]
        public void SevenSegmentDigitModel_WhenCheckEquality_ReturnProperEqualityResult(SevenSegmentDigitModel first, SevenSegmentDigitModel second)
        {
            Assert.IsTrue(first == second);
        }

        /// <summary>
        /// Inequality checking method
        /// </summary>
        /// <param name="first">First 7-segment digit model to compare</param>
        /// <param name="second">Second 7-segment digit model to compare</param>
        [Test]
        [TestCaseSource("InequalSevenSegmentDigitModelsTestCaseCollection")]
        public void SevenSegmentDigitModel_WhenCheckInequality_ReturnProperInequalityResult(SevenSegmentDigitModel first, SevenSegmentDigitModel second)
        {
            Assert.IsTrue(first != second);
        }
    }
}
