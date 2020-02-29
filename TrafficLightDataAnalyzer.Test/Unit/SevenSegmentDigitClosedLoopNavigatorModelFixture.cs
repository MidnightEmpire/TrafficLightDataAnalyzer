using NUnit.Framework;
using System;
using System.Collections.Generic;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Navigation;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// Seven segment digit closed loop navigator model tests fixture
    /// </summary>
    [TestFixture]
    internal class SevenSegmentDigitClosedLoopNavigatorModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Navigates to another 7-segment digit model item valid data test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> NavigatesToAnotherItemWithValidDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(SevenSegmentDigitModel.Digit0, 3, SevenSegmentDigitModel.Digit3);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit1, 3, SevenSegmentDigitModel.Digit4);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit2, 3, SevenSegmentDigitModel.Digit5);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit3, 3, SevenSegmentDigitModel.Digit6);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit4, 3, SevenSegmentDigitModel.Digit7);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit5, 3, SevenSegmentDigitModel.Digit8);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit6, 3, SevenSegmentDigitModel.Digit9);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit7, 3, SevenSegmentDigitModel.Digit0);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit8, 3, SevenSegmentDigitModel.Digit1);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit9, 3, SevenSegmentDigitModel.Digit2);

                yield return new TestCaseData(SevenSegmentDigitModel.Digit9, 33, SevenSegmentDigitModel.Digit2);

                yield return new TestCaseData(SevenSegmentDigitModel.Digit0, -5, SevenSegmentDigitModel.Digit5);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit1, -5, SevenSegmentDigitModel.Digit6);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit2, -5, SevenSegmentDigitModel.Digit7);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit3, -5, SevenSegmentDigitModel.Digit8);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit4, -5, SevenSegmentDigitModel.Digit9);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit5, -5, SevenSegmentDigitModel.Digit0);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit6, -5, SevenSegmentDigitModel.Digit1);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit7, -5, SevenSegmentDigitModel.Digit2);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit8, -5, SevenSegmentDigitModel.Digit3);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit9, -5, SevenSegmentDigitModel.Digit4);

                yield return new TestCaseData(SevenSegmentDigitModel.Digit9, -55, SevenSegmentDigitModel.Digit4);
            }
        }

        /// <summary>
        /// Navigates to another 7-segment digit model item invalid data test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> NavigatesToAnotherItemWithInvalidDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(null, 3);
                yield return new TestCaseData(null, -1);
                yield return new TestCaseData(null, 0);
                yield return new TestCaseData(SevenSegmentDigitModel.Digit1, -1);
            }
        }

        #endregion

        /// <summary>
        /// Navigation to next digit model item with invalid data pass checking method
        /// </summary>
        /// <param name="currentDigitModel">Start/current 7-segment digit model reference value</param>
        /// <param name="shift">Navigation shift value</param>
        [Test]
        [TestCaseSource("NavigatesToAnotherItemWithInvalidDataTestCaseCollection")]
        public void SevenSegmentDigitClosedLoopNavigatorModel_WhenNavigatesToNextItemWithInvalidData_ThrowsArgumentOutOfRangeException(
            SevenSegmentDigitModel currentDigitModel,
            int shift
        ) {
            var navigationFactory = new NavigationFactoryModel();

            var navigator = navigationFactory.CreateSequentialCountdownDigitRangeGenerator();

            Assert.Catch<ArgumentOutOfRangeException>(() => navigator.NextAfter(currentDigitModel, shift));
        }

        /// <summary>
        /// Navigation to previous digit model item with invalid data pass checking method
        /// </summary>
        /// <param name="currentDigitModel">Start/current 7-segment digit model reference value</param>
        /// <param name="shift">Navigation shift value</param>
        [Test]
        [TestCaseSource("NavigatesToAnotherItemWithInvalidDataTestCaseCollection")]
        public void SevenSegmentDigitClosedLoopNavigatorModel_WhenNavigatesToPreviousItemWithInvalidData_ThrowsArgumentOutOfRangeException(
            SevenSegmentDigitModel currentDigitModel,
            int shift
        ) {
            var navigationFactory = new NavigationFactoryModel();

            var navigator = navigationFactory.CreateSequentialCountdownDigitRangeGenerator();

            Assert.Catch<ArgumentOutOfRangeException>(() => navigator.PreviousBefore(currentDigitModel, shift));
        }

        /// <summary>
        /// Navigation checking method
        /// Yes, using shift for both two functions check is not canonical and best practice, but seems to be non-critical in current case
        /// </summary>
        /// <param name="currentDigitModel">Start/current 7-segment digit model reference value</param>
        /// <param name="shift">Navigation shift value. If > 0, next will be used, otherwise, previous will be used</param>
        /// <param name="currentDigitModel">Expected 7-segment digit model reference value</param>
        [Test]
        [TestCaseSource("NavigatesToAnotherItemWithValidDataTestCaseCollection")]
        public void SevenSegmentDigitClosedLoopNavigatorModel_WhenNavigatesToAnotherItemWithValidData_ObtainProperItemResult(
            SevenSegmentDigitModel currentDigitModel,
            int shift,
            SevenSegmentDigitModel expectedDigitModel
        ) {
            var navigationFactory = new NavigationFactoryModel();

            var navigator = navigationFactory.CreateSequentialCountdownDigitRangeGenerator();

            var navigatedDigitModel = shift > 0 ?
                navigator.NextAfter(currentDigitModel, shift) :
                navigator.PreviousBefore(currentDigitModel, -shift);

            Assert.AreEqual(expectedDigitModel, navigatedDigitModel);
        }
    }
}
