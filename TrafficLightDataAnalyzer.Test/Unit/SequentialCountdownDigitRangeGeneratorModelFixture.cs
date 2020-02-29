using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Generation;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// Sequential countdown digit range generator model tests fixture
    /// </summary>
    [TestFixture]
    internal class SequentialCountdownDigitRangeGeneratorModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Generate range valid data test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> GenerateRangeWithValidDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit1),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit2, SevenSegmentDigitModel.Digit8),
                    new List<TwoDigitClockFaceValueModel>()
                    {
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit1),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit0),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit9),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit8),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit7),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit6),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit5),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit4),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit3),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit2),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit1),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit0),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit2, SevenSegmentDigitModel.Digit9),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit2, SevenSegmentDigitModel.Digit8)
                    }
                );

                yield return new TestCaseData(
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit7),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit8),
                    new List<TwoDigitClockFaceValueModel>()
                    {
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit8),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit7),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit6),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit5),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit4),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit3),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit2),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit1),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit0),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit9),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit8),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit7)
                    }
                );

                yield return new TestCaseData(
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit9, SevenSegmentDigitModel.Digit8),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit9, SevenSegmentDigitModel.Digit8),
                    new List<TwoDigitClockFaceValueModel>()
                    {
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit9, SevenSegmentDigitModel.Digit8)
                    }
                );
            }
        }

        /// <summary>
        /// Generate range valid data invalid test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> GenerateRangeWithInvalidDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(null, null);
                yield return new TestCaseData(null, new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit9, SevenSegmentDigitModel.Digit8));
                yield return new TestCaseData(new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit9, SevenSegmentDigitModel.Digit8), null);
            }
        }

        #endregion

        /// <summary>
        /// Range generation with invalid data pass checking method
        /// </summary>
        /// <param name="from">Range generator start reference value</param>
        /// <param name="to">Range generator end reference value</param>
        [Test]
        [TestCaseSource("GenerateRangeWithInvalidDataTestCaseCollection")]
        public void SequentialCountdownDigitRangeGeneratorModel_WhenGeneratesRangeWithInvalidData_ThrowsArgumentOutOfRangeException(
            TwoDigitClockFaceValueModel from,
            TwoDigitClockFaceValueModel to
        ) {
            var generationFactory = new GenerationFactoryModel();

            var generator = generationFactory.CreateSequentialCountdownDigitRangeGenerator();

            Assert.Catch<ArgumentOutOfRangeException>(() => generator.MakeRange(from, to).ToList());
        }

        /// <summary>
        /// Range generation with proper data checking method
        /// </summary>
        /// <param name="from">Range generator start reference value</param>
        /// <param name="to">Range generator end reference value</param>
        /// <param name="currentDigitModel">Expected range collection reference value</param>
        [Test]
        [TestCaseSource("GenerateRangeWithValidDataTestCaseCollection")]
        public void SequentialCountdownDigitRangeGeneratorModel_WhenGeneratesRangeWithValidData_ObtainProperRange(
            TwoDigitClockFaceValueModel from,
            TwoDigitClockFaceValueModel to,
            IEnumerable<TwoDigitClockFaceValueModel> expectedRange
        ) {
            var generationFactory = new GenerationFactoryModel();

            var generator = generationFactory.CreateSequentialCountdownDigitRangeGenerator();

            var result = generator.MakeRange(from, to).ToList();

            Assert.AreEqual(expectedRange, result);
        }
    }
}
