using NUnit.Framework;
using System;
using System.Collections.Generic;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Navigation;
using TrafficLightDataAnalyzer.Model.Navigation.Navigator.TrafficLight;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// Traffic light <see cref="DigitNavigatorModel">DigitNavigatorModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class DigitNavigatorModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Navigation to previous <see cref="DigitModel">DigitModel</see> item valid data test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> PreviousBeforeValidNavigationDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(DigitModel.Digit0, 4, DigitModel.Digit6);
                yield return new TestCaseData(DigitModel.Digit1, 4, DigitModel.Digit7);
                yield return new TestCaseData(DigitModel.Digit2, 4, DigitModel.Digit8);
                yield return new TestCaseData(DigitModel.Digit3, 4, DigitModel.Digit9);
                yield return new TestCaseData(DigitModel.Digit4, 4, DigitModel.Digit0);
                yield return new TestCaseData(DigitModel.Digit5, 4, DigitModel.Digit1);
                yield return new TestCaseData(DigitModel.Digit6, 4, DigitModel.Digit2);
                yield return new TestCaseData(DigitModel.Digit7, 4, DigitModel.Digit3);
                yield return new TestCaseData(DigitModel.Digit8, 4, DigitModel.Digit4);
                yield return new TestCaseData(DigitModel.Digit9, 4, DigitModel.Digit5);

                yield return new TestCaseData(DigitModel.Digit9, 54, DigitModel.Digit5);
            }
        }

        /// <summary>
        /// Navigation to next <see cref="DigitModel">DigitModel</see> item valid data test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> NextAfterValidNavigationDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(DigitModel.Digit0, 3, DigitModel.Digit3);
                yield return new TestCaseData(DigitModel.Digit1, 3, DigitModel.Digit4);
                yield return new TestCaseData(DigitModel.Digit2, 3, DigitModel.Digit5);
                yield return new TestCaseData(DigitModel.Digit3, 3, DigitModel.Digit6);
                yield return new TestCaseData(DigitModel.Digit4, 3, DigitModel.Digit7);
                yield return new TestCaseData(DigitModel.Digit5, 3, DigitModel.Digit8);
                yield return new TestCaseData(DigitModel.Digit6, 3, DigitModel.Digit9);
                yield return new TestCaseData(DigitModel.Digit7, 3, DigitModel.Digit0);
                yield return new TestCaseData(DigitModel.Digit8, 3, DigitModel.Digit1);
                yield return new TestCaseData(DigitModel.Digit9, 3, DigitModel.Digit2);

                yield return new TestCaseData(DigitModel.Digit9, 33, DigitModel.Digit2);
            }
        }

        #endregion

        /// <summary>
        /// Proper instance of <see cref="INavigator{TItemType}">INavigator</see> creation service method.
        /// </summary>
        /// <returns>Proper instance of <see cref="INavigator{TItemType}">INavigator</see>.</returns>
        private INavigator<DigitModel> createNavigator()
        {
            var navigationFactory = new NavigationFactoryModel();

            return navigationFactory.CreateDigitNavigator();
        }

        /// <summary>
        /// Navigation to previous <see cref="DigitModel">DigitModel</see> item with null <see cref="DigitModel">DigitModel</see> value pass checking method.
        /// </summary>
        /// <param name="shift">Navigation shift value.</param>
        [Test]
        [TestCase(3)]
        [TestCase(-1)]
        public void PreviousBefore_NullDigitModel_ThrowsArgumentNullException(int shift)
        {
            var navigator = this.createNavigator();

            Assert.Catch<ArgumentNullException>(() => navigator.PreviousBefore(null, shift));
        }

        /// <summary>
        /// Navigation to next <see cref="DigitModel">DigitModel</see> item with null <see cref="DigitModel">DigitModel</see> value pass checking method.
        /// </summary>
        /// <param name="shift">Navigation shift value.</param>
        [Test]
        [TestCase(3)]
        [TestCase(-1)]
        public void NextAfter_NullDigitModel_ThrowsArgumentNullException(int shift)
        {
            var navigator = this.createNavigator();

            Assert.Catch<ArgumentNullException>(() => navigator.NextAfter(null, shift));
        }

        /// <summary>
        /// Navigation to previous <see cref="DigitModel">DigitModel</see> item with <see cref="DigitModel.Undefined">Undefined</see> current value pass checking method.
        /// </summary>
        [Test]
        public void PreviousBefore_UndefinedDigitModel_ThrowsArgumentOutOfRangeException()
        {
            var navigator = this.createNavigator();

            Assert.Catch<ArgumentOutOfRangeException>(() => navigator.PreviousBefore(DigitModel.Undefined, 2));
        }

        /// <summary>
        /// Navigation to next <see cref="DigitModel">DigitModel</see> item with <see cref="DigitModel.Undefined">Undefined</see> current value pass checking method.
        /// </summary>
        [Test]
        public void NextAfter_UndefinedDigitModel_ThrowsArgumentOutOfRangeException()
        {
            var navigator = this.createNavigator();

            Assert.Catch<ArgumentOutOfRangeException>(() => navigator.NextAfter(DigitModel.Undefined, 2));
        }

        /// <summary>
        /// Navigation to previous <see cref="DigitModel">DigitModel</see> item with invalid <paramref name="shift" /> value pass checking method.
        /// </summary>
        /// <param name="shift">Navigation shift value.</param>
        [Test]
        [TestCase(-43)]
        [TestCase(0)]
        public void PreviousBefore_ShiftIsLessThan1_ThrowsArgumentOutOfRangeException(int shift)
        {
            var navigator = this.createNavigator();

            Assert.Catch<ArgumentOutOfRangeException>(() => navigator.PreviousBefore(DigitModel.Digit2, shift));
        }

        /// <summary>
        /// Navigation to next <see cref="DigitModel">DigitModel</see> item with invalid <paramref name="shift" /> value pass checking method.
        /// </summary>
        /// <param name="shift">Navigation shift value.</param>
        [Test]
        [TestCase(-43)]
        [TestCase(0)]
        public void NextAfter_ShiftIsLessThan1_TThrowsArgumentOutOfRangeException(int shift)
        {
            var navigator = this.createNavigator();

            Assert.Catch<ArgumentOutOfRangeException>(() => navigator.NextAfter(DigitModel.Digit2, shift));
        }

        /// <summary>
        /// Navigation to previous <see cref="DigitModel">DigitModel</see> item with valid data pass checking method.
        /// </summary>
        /// <param name="currentDigitModel">Start/current <see cref="DigitModel">DigitModel</see> reference value.</param>
        /// <param name="shift">Navigation shift value.</param>
        /// <param name="expectedDigitModel">Expected <see cref="DigitModel">DigitModel</see> reference value.</param>
        [Test]
        [TestCaseSource(nameof(DigitNavigatorModelFixture.PreviousBeforeValidNavigationDataTestCaseCollection))]
        public void PreviousBefore_ValidNavigationData_ReturnsProperDigitModel(
            DigitModel currentDigitModel,
            int shift,
            DigitModel expectedDigitModel
        ) {
            var navigator = this.createNavigator();

            var navigatedDigitModel = navigator.PreviousBefore(currentDigitModel, shift);

            Assert.AreEqual(expectedDigitModel, navigatedDigitModel);
        }

        /// <summary>
        /// Navigation to next <see cref="DigitModel">DigitModel</see> item with valid data pass checking method.
        /// </summary>
        /// <param name="currentDigitModel">Start/current <see cref="DigitModel">DigitModel</see> reference value.</param>
        /// <param name="shift">Navigation shift value.</param>
        /// <param name="expectedDigitModel">Expected <see cref="DigitModel">DigitModel</see> reference value.</param>
        [Test]
        [TestCaseSource(nameof(DigitNavigatorModelFixture.NextAfterValidNavigationDataTestCaseCollection))]
        public void NextAfter_ValidNavigationData_ReturnsProperDigitModel(
            DigitModel currentDigitModel,
            int shift,
            DigitModel expectedDigitModel
        ) {
            var navigator = this.createNavigator();

            var navigatedDigitModel = navigator.NextAfter(currentDigitModel, shift);

            Assert.AreEqual(expectedDigitModel, navigatedDigitModel);
        }
    }
}
