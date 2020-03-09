using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;
using TrafficLightDataAnalyzer.Model.Generation;
using TrafficLightDataAnalyzer.Model.Generation.Generator.Range.TrafficLight.ClockFace;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="SequentialDigitsValueModelGeneratorModel">SequentialDigitsValueModelGeneratorModel</see> tests fixture.
    /// </summary>
    [TestFixture]
    internal class SequentialDigitsValueModelGeneratorModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Valid <see cref="DigitsValueModel">DigitsValueModel</see> generation range values data triple test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> ValidGenerationTestRangeValuesTripleTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(
                    new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit1),
                    new DigitsValueModel(DigitModel.Digit2, DigitModel.Digit8),

                    new List<DigitsValueModel>()
                    {
                        new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit1),
                        new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit0),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit9),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit8),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit7),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit6),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit5),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit4),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit3),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit2),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit1),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit0),
                        new DigitsValueModel(DigitModel.Digit2, DigitModel.Digit9),
                        new DigitsValueModel(DigitModel.Digit2, DigitModel.Digit8)
                    }
                );

                yield return new TestCaseData(
                    new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit7),
                    new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit8),

                    new List<DigitsValueModel>()
                    {
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit7),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit8),
                        new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit9),
                        new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit0),
                        new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit1),
                        new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit2),
                        new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit3),
                        new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit4),
                        new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit5),
                        new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit6),
                        new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit7),
                        new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit8)
                    }
                );

                yield return new TestCaseData(
                    new DigitsValueModel(DigitModel.Digit9, DigitModel.Digit8),
                    new DigitsValueModel(DigitModel.Digit9, DigitModel.Digit8),

                    new List<DigitsValueModel>()
                    {
                        new DigitsValueModel(DigitModel.Digit9, DigitModel.Digit8)
                    }
                );
            }
        }

        /// <summary>
        /// Null <see cref="DigitsValueModel">DigitsValueModel</see> generation range values data test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> NullGenerationTestRangeValuesTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(null, null);
                yield return new TestCaseData(null, new DigitsValueModel(DigitModel.Digit9, DigitModel.Digit8));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit9, DigitModel.Digit8), null);
            }
        }

        /// <summary>
        /// Invalid <see cref="DigitsValueModel">DigitsValueModel</see> generation range values data test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> InvalidGenerationTestRangeValuesTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(new DigitsValueModel(null, null), new DigitsValueModel(null, null));
                yield return new TestCaseData(new DigitsValueModel(null, DigitModel.Undefined), new DigitsValueModel(DigitModel.Undefined, null));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Undefined, DigitModel.Undefined), new DigitsValueModel(DigitModel.Undefined, DigitModel.Undefined));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit1, DigitModel.Digit2), new DigitsValueModel(null, DigitModel.Digit4));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit1, DigitModel.Digit2), new DigitsValueModel(DigitModel.Digit4, null));
                yield return new TestCaseData(new DigitsValueModel(null, DigitModel.Digit4), new DigitsValueModel(DigitModel.Digit1, DigitModel.Digit2));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit4, null), new DigitsValueModel(DigitModel.Digit1, DigitModel.Digit2));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit1, DigitModel.Digit2), new DigitsValueModel(DigitModel.Undefined, DigitModel.Digit4));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit1, DigitModel.Digit2), new DigitsValueModel(DigitModel.Digit4, DigitModel.Undefined));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Undefined, DigitModel.Digit4), new DigitsValueModel(DigitModel.Digit1, DigitModel.Digit2));
                yield return new TestCaseData(new DigitsValueModel(DigitModel.Digit4, DigitModel.Undefined), new DigitsValueModel(DigitModel.Digit1, DigitModel.Digit2));

            }
        }

        #endregion

        /// <summary>
        /// Proper instance of <see cref="IRangeGenerator{TRangeItem}">IRangeGenerator</see> creation service method.
        /// </summary>
        /// <returns>Proper instance of <see cref="IRangeGenerator{TRangeItem}">IRangeGenerator</see>.</returns>
        private IRangeGenerator<DigitsValueModel> createGenerator()
        {
            var generationFactory = new GenerationFactoryModel();

            return generationFactory.CreateSequentialDigitsValueModelGenerator();
        }

        /// <summary>
        /// Range generation with any null argument pass checking method.
        /// </summary>
        /// <param name="from">Start range item value.</param>
        /// <param name="to">End range item value.</param>
        [Test]
        [TestCaseSource(nameof(SequentialDigitsValueModelGeneratorModelFixture.NullGenerationTestRangeValuesTestCaseCollection))]
        public void MakeRange_AnyArgumentIsNull_ThrowsArgumentNullException(DigitsValueModel from, DigitsValueModel to)
        {
            var generator = this.createGenerator();

            Assert.Catch<ArgumentNullException>(() => generator.MakeRange(from, to).ToList());
        }

        /// <summary>
        /// Range generation with any invalid argument pass checking method.
        /// </summary>
        /// <param name="from">Start range item value.</param>
        /// <param name="to">End range item value.</param>
        [Test]
        [TestCaseSource(nameof(SequentialDigitsValueModelGeneratorModelFixture.InvalidGenerationTestRangeValuesTestCaseCollection))]
        public void MakeRange_AnyArgumentIsInvalid_ThrowsInvalidArgumentStateException(DigitsValueModel from, DigitsValueModel to)
        {
            var generator = this.createGenerator();

            Assert.Catch<InvalidArgumentStateException>(() => generator.MakeRange(from, to).ToList());
        }

        /// <summary>
        /// Range generation with valid argument pass checking method.
        /// </summary>
        /// <param name="from">Start range item value.</param>
        /// <param name="to">End range item value.</param>
        /// <param name="expectedRange">Expected range collection value.</param>
        [Test]
        [TestCaseSource(nameof(SequentialDigitsValueModelGeneratorModelFixture.ValidGenerationTestRangeValuesTripleTestCaseCollection))]
        public void MakeRange_ValidRangeArguments_ReturnsProperRange(
            DigitsValueModel from,
            DigitsValueModel to,
            IEnumerable<DigitsValueModel> expectedRange
        ) {
            var generator = this.createGenerator();

            var result = generator.MakeRange(from, to).ToList();

            Assert.AreEqual(expectedRange, result);
        }
    }
}
