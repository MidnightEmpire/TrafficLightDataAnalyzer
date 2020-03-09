using NUnit.Framework;
using System.Collections.Generic;
using TrafficLightDataAnalyzer.Common;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="DigitModel">DigitModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class DigitModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Equal <see cref="DigitModel">DigitModel</see> pairs test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> EqualDigitModelPairsTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(NullInstance.Of<DigitModel>(), NullInstance.Of<DigitModel>());
                yield return new TestCaseData(DigitModel.Digit0, DigitModel.Digit0);
                yield return new TestCaseData(DigitModel.Digit1, DigitModel.Digit1);
                yield return new TestCaseData(DigitModel.Digit2, DigitModel.Digit2);
                yield return new TestCaseData(DigitModel.Digit3, DigitModel.Digit3);
                yield return new TestCaseData(DigitModel.Digit4, DigitModel.Digit4);
                yield return new TestCaseData(DigitModel.Digit5, DigitModel.Digit5);
                yield return new TestCaseData(DigitModel.Digit6, DigitModel.Digit6);
                yield return new TestCaseData(DigitModel.Digit7, DigitModel.Digit7);
                yield return new TestCaseData(DigitModel.Digit8, DigitModel.Digit8);
                yield return new TestCaseData(DigitModel.Digit9, DigitModel.Digit9);
            }
        }

        /// <summary>
        /// Inequal <see cref="DigitModel">DigitModel</see> pairs test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> InequalDigitModelPairsTestCaseCollection
        {
            get
            {
                var allDigitModels = new List<DigitModel>(DigitModel.AllDigits);

                allDigitModels.Add(DigitModel.Undefined);

                var digitModelsAmount = allDigitModels.Count;

                for (int i = digitModelsAmount + 1; --i >= 0;)
                {
                    for (int j = digitModelsAmount + 1; --j >= 0;)
                    {
                        if (i != j)
                        {
                            var firstDigit = i == digitModelsAmount ? null : allDigitModels[i];
                            var secondDigit = j == digitModelsAmount ? null : allDigitModels[j];

                            yield return new TestCaseData(firstDigit, secondDigit);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Valid <see cref="DigitModel">DigitModel</see> digit value to find with matching <see cref="DigitModel">DigitModel</see> instance pairs test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> ValidDigitValueSearchPairsTestCaseCollection
        {
            get
            {
                yield return new TestCaseData((sbyte) 0, DigitModel.Digit0);
                yield return new TestCaseData((sbyte) 1, DigitModel.Digit1);
                yield return new TestCaseData((sbyte) 2, DigitModel.Digit2);
                yield return new TestCaseData((sbyte) 3, DigitModel.Digit3);
                yield return new TestCaseData((sbyte) 4, DigitModel.Digit4);
                yield return new TestCaseData((sbyte) 5, DigitModel.Digit5);
                yield return new TestCaseData((sbyte) 6, DigitModel.Digit6);
                yield return new TestCaseData((sbyte) 7, DigitModel.Digit7);
                yield return new TestCaseData((sbyte) 8, DigitModel.Digit8);
                yield return new TestCaseData((sbyte) 9, DigitModel.Digit9);
            }
        }

        /// <summary>
        /// Invalid <see cref="DigitModel">DigitModel</see> digit values to find test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> InvalidDigitValuesToFindTestCaseCollection
        {
            get
            {
                yield return new TestCaseData((sbyte) -1);
                yield return new TestCaseData((sbyte) -5);
                yield return new TestCaseData((sbyte) -15);
                yield return new TestCaseData((sbyte) 34);
                yield return new TestCaseData((sbyte) 90);
            }
        }

        #endregion

        /// <summary>
        /// <see cref="DigitModel">DigitModel</see> <see cref="DigitModel.Undefined">Undefined</see> instance is excluded from
        /// collection of all instances checking method.
        /// </summary>
        [Test]
        public void AllDigitsPropertyIndexOf_UndefinedDigitInstance_ReturnsNotFoundIndex()
        {
            var allDigitModels = DigitModel.AllDigits;

            var undefinedIndex = allDigitModels.IndexOf(DigitModel.Undefined);

            Assert.Less(undefinedIndex, 0);
        }

        /// <summary>
        /// <see cref="DigitModel">DigitModel</see> all non-undefined digits amount checking method.
        /// </summary>
        [Test]
        public void AllDigitsCount_Always_Returns10()
        {
            const int ExpectedDigitAmount = 10;

            var digitsAmout = DigitModel.AllDigits.Count;

            Assert.AreEqual(ExpectedDigitAmount, digitsAmout);
        }

        /// <summary>
        /// <see cref="DigitModel">DigitModel</see> equality operator checking method.
        /// </summary>
        /// <param name="first">First <see cref="DigitModel">DigitModel</see> instance to compare.</param>
        /// <param name="second">Second <see cref="DigitModel">DigitModel</see> instance to compare.</param>
        [Test]
        [TestCaseSource(nameof(DigitModelFixture.EqualDigitModelPairsTestCaseCollection))]
        public void EqualityOperator_EqualOperands_ReturnsTrue(DigitModel first, DigitModel second)
        {
            Assert.IsTrue(first == second);
        }

        /// <summary>
        /// <see cref="DigitModel">DigitModel</see> inequality operator checking method.
        /// </summary>
        /// <param name="first">First <see cref="DigitModel">DigitModel</see> instance to compare.</param>
        /// <param name="second">Second <see cref="DigitModel">DigitModel</see> instance to compare.</param>
        [Test]
        [TestCaseSource(nameof(DigitModelFixture.InequalDigitModelPairsTestCaseCollection))]
        public void EqualityOperator_InequalOperands_ReturnsFalse(DigitModel first, DigitModel second)
        {
            Assert.IsTrue(first != second);
        }

        /// <summary>
        /// <see cref="DigitModel">DigitModel</see> instance by valid digit value search checking method.
        /// </summary>
        /// <param name="value">Valid <see cref="DigitModel">DigitModel</see> digit value.</param>
        /// <param name="expectedDigitModel">Matching/expected <see cref="DigitModel">DigitModel</see> instance reference value.</param>
        [Test]
        [TestCaseSource(nameof(DigitModelFixture.ValidDigitValueSearchPairsTestCaseCollection))]
        public void FindByName_ValidDigitValue_ReturnsMatchedDigitModelInstance(sbyte value, DigitModel expectedDigitModel)
        {
            var foundDigitModel = DigitModel.FindByValue(value);

            Assert.AreEqual(expectedDigitModel, foundDigitModel);
        }

        /// <summary>
        /// <see cref="DigitModel">DigitModel</see> instance by invalid digit value search checking method.
        /// </summary>
        /// <param name="digitValue">Invalid <see cref="DigitModel">DigitModel</see> digit value.</param>
        [Test]
        [TestCaseSource(nameof(DigitModelFixture.InvalidDigitValuesToFindTestCaseCollection))]
        public void FindByName_InvalidDigitValue_ReturnsUndefinedDigitModelInstance(sbyte digitValue)
        {
            var foundDigitModel = DigitModel.FindByValue(digitValue);

            Assert.AreEqual(DigitModel.Undefined, foundDigitModel);
        }
    }
}
