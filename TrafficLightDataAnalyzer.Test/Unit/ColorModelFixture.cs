using NUnit.Framework;
using System;
using System.Collections.Generic;
using TrafficLightDataAnalyzer.Common;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="ColorModel">ColorModel</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class ColorModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Equal <see cref="ColorModel">ColorModel</see> pairs test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> EqualColorModelPairsTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(NullInstance.Of<ColorModel>(), NullInstance.Of<ColorModel>());
                yield return new TestCaseData(ColorModel.Undefined, ColorModel.Undefined);
                yield return new TestCaseData(ColorModel.Red, ColorModel.Red);
                yield return new TestCaseData(ColorModel.Green, ColorModel.Green);
            }
        }

        /// <summary>
        /// Inequal <see cref="ColorModel">ColorModel</see> pairs test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> InequalColorModelPairsTestCaseCollection
        {
            get
            {
                var allColorModels = new List<ColorModel>(ColorModel.AllColors);

                allColorModels.Add(ColorModel.Undefined);

                var colorModelsAmount = allColorModels.Count;

                for (int i = colorModelsAmount + 1; --i >= 0;)
                {
                    for (int j = colorModelsAmount + 1; --j >= 0;)
                    {
                        if (i != j)
                        {
                            var firstColor = i == colorModelsAmount ? null : allColorModels[i];
                            var secondColor = j == colorModelsAmount ? null : allColorModels[j];

                            yield return new TestCaseData(firstColor, secondColor);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Valid <see cref="ColorModel">ColorModel</see> color name to find with matching <see cref="ColorModel">ColorModel</see> instance pairs test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> ValidColorNameSearchPairsTestCaseCollection
        {
            get
            {
                yield return new TestCaseData("Red", ColorModel.Red);
                yield return new TestCaseData("Green", ColorModel.Green);
            }
        }

        /// <summary>
        /// Invalid <see cref="ColorModel">ColorModel</see> color names to find test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> InvalidColorNamesToFindTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(null);
                yield return new TestCaseData("unknowncolor");
                yield return new TestCaseData("_sdf_1");
                yield return new TestCaseData(string.Empty);
            }
        }

        #endregion

        /// <summary>
        /// <see cref="ColorModel">ColorModel</see> <see cref="ColorModel.Undefined">Undefined</see> instance is excluded from
        /// collection of all instances checking method.
        /// </summary>
        [Test]
        public void AllColorsPropertyIndexOf_UndefinedColorInstance_ReturnsNotFoundIndex()
        {
            var allColorModels = ColorModel.AllColors;

            var undefinedIndex = allColorModels.IndexOf(ColorModel.Undefined);

            Assert.Less(undefinedIndex, 0);
        }

        /// <summary>
        /// <see cref="ColorModel">ColorModel</see> equality operator with equal operands checking method.
        /// </summary>
        /// <param name="first">First <see cref="ColorModel">ColorModel</see> instance to compare.</param>
        /// <param name="second">Second <see cref="ColorModel">ColorModel</see> instance to compare.</param>
        [Test]
        [TestCaseSource(nameof(ColorModelFixture.EqualColorModelPairsTestCaseCollection))]
        public void EqualityOperator_EqualOperands_ReturnsTrue(ColorModel first, ColorModel second)
        {
            Assert.IsTrue(first == second);
        }

        /// <summary>
        /// <see cref="ColorModel">ColorModel</see> inequality operator checking method.
        /// </summary>
        /// <param name="first">First <see cref="ColorModel">ColorModel</see> instance to compare.</param>
        /// <param name="second">Second <see cref="ColorModel">ColorModel</see> instance to compare.</param>
        [Test]
        [TestCaseSource(nameof(ColorModelFixture.InequalColorModelPairsTestCaseCollection))]
        public void EqualityOperator_InequalOperands_ReturnsFalse(ColorModel first, ColorModel second)
        {
            Assert.IsTrue(first != second);
        }

        /// <summary>
        /// <see cref="ColorModel">ColorModel</see> instance by valid color name search checking method.
        /// </summary>
        /// <param name="colorName">Valid <see cref="ColorModel">ColorModel</see> color name value.</param>
        /// <param name="expectedColorModel">Matching/expected <see cref="ColorModel">ColorModel</see> instance reference value.</param>
        [Test]
        [TestCaseSource(nameof(ColorModelFixture.ValidColorNameSearchPairsTestCaseCollection))]
        public void FindByName_ValidColorName_ReturnsMatchedColorModelInstance(string colorName, ColorModel expectedColorModel)
        {
            var foundColorModel = ColorModel.FindByName(colorName);

            Assert.AreEqual(expectedColorModel, foundColorModel);
        }

        /// <summary>
        /// <see cref="ColorModel">ColorModel</see> instance by valid color name search with ignored case checking method.
        /// </summary>
        /// <param name="colorName">Valid <see cref="ColorModel">ColorModel</see> name value.</param>
        /// <param name="expectedColorModel">Matching/expected <see cref="ColorModel">ColorModel</see> instance reference value.</param>
        [Test]
        [TestCaseSource(nameof(ColorModelFixture.ValidColorNameSearchPairsTestCaseCollection))]
        public void FindByNameWithIgnoredCase_ValidColorName_ReturnsMatchedColorModelInstance(string colorName, ColorModel expectedColorModel)
        {
            var foundColorModel = ColorModel.FindByName(colorName?.ToLower(), StringComparison.OrdinalIgnoreCase);

            Assert.AreEqual(expectedColorModel, foundColorModel);
        }

        /// <summary>
        /// <see cref="ColorModel">ColorModel</see> instance by invalid color name search checking method.
        /// </summary>
        /// <param name="colorName">Invalid <see cref="ColorModel">ColorModel</see> name value.</param>
        [Test]
        [TestCaseSource(nameof(ColorModelFixture.InvalidColorNamesToFindTestCaseCollection))]
        public void FindByName_InvalidColorName_ReturnsUndefinedColorModelInstance(string colorName)
        {
            var foundColorModel = ColorModel.FindByName(colorName);

            Assert.AreEqual(ColorModel.Undefined, foundColorModel);
        }

        /// <summary>
        /// <see cref="ColorModel">ColorModel</see> instance by invalid color name search with ignored case checking method.
        /// </summary>
        /// <param name="colorName">Invalid <see cref="ColorModel">ColorModel</see> name value.</param>
        [Test]
        [TestCaseSource(nameof(ColorModelFixture.InvalidColorNamesToFindTestCaseCollection))]
        public void FindByNameWithIgnoredCase_ValidColorName_ReturnsMatchedColorModelInstance(string colorName)
        {
            var foundColorModel = ColorModel.FindByName(colorName, StringComparison.OrdinalIgnoreCase);

            Assert.AreEqual(ColorModel.Undefined, foundColorModel);
        }
    }
}
