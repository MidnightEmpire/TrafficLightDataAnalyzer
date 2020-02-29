using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Observation;
using TrafficLightDataAnalyzer.Model.ObservationSequence.Validator;
using TrafficLightDataAnalyzer.Test.Environment;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// Observation sequence validator model tests fixture
    /// </summary>
    [TestFixture]
    internal class ObservationSequenceValidatorModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Valid observation data test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> GenerateValidObservationDataTestCaseCollection
        {
            get
            {
                var observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddSequentialObservationRange(
                    TrafficLightColorModel.Green,
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit0),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit0, SevenSegmentDigitModel.Digit1)
                );

                observationGenerator.AddObservation(TrafficLightColorModel.Red);

                yield return new TestCaseData(true, observationGenerator.Observations.ToList());

                observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddSequentialObservationRange(
                    TrafficLightColorModel.Green,
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit0),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit1, SevenSegmentDigitModel.Digit1)
                );

                observationGenerator.AddObservation(TrafficLightColorModel.Red);

                yield return new TestCaseData(true, observationGenerator.Observations.ToList());

                observationGenerator.AddSequentialObservationRange(
                    TrafficLightColorModel.Green,
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit2, SevenSegmentDigitModel.Digit0),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit1, SevenSegmentDigitModel.Digit3)
                );

                yield return new TestCaseData(false, observationGenerator.Observations.ToList());

                observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddObservation(TrafficLightColorModel.Green);
                observationGenerator.AddObservation(TrafficLightColorModel.Red);

                yield return new TestCaseData(true, observationGenerator.Observations.ToList());
            }
        }


        /// <summary>
        /// Invalid observation data test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> GenerateInvalidObservationDataTestCaseCollection
        {
            get
            {
                var observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddObservation(TrafficLightColorModel.Red);

                observationGenerator.AddSequentialObservationRange(
                    TrafficLightColorModel.Green,
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit0),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit0, SevenSegmentDigitModel.Digit1)
                );

                yield return new TestCaseData(true, observationGenerator.Observations.ToList());

                observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddSequentialObservationRange(
                    TrafficLightColorModel.Green,
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit0),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit1, SevenSegmentDigitModel.Digit1)
                );

                yield return new TestCaseData(true, observationGenerator.Observations.ToList());

                observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddObservation(TrafficLightColorModel.Red);

                yield return new TestCaseData(true, observationGenerator.Observations.ToList());

                yield return new TestCaseData(true, null);
            }
        }

        #endregion

        /// <summary>
        /// Observation sequence validator doesn't throw any exception if valid observation sequence GUID passed in validation method
        /// </summary>
        /// <param name="sequenceGuid">Observation sequence GUID string reference value</param>
        [Test]
        [TestCase("00000000000000000000000000000000")]
        [TestCase("000000000afa00000000000000000000")]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("00000000-0000-0000-0000-0ff00a000000")]
        public void ObservationSequenceValidatorModel_WhenCheckingValidGuidFormat_MethodPassedWithNoException(string sequenceGuid)
        {
            var observationSequenceValidatorModel = new ObservationSequenceValidatorModel();

            Assert.DoesNotThrow(() => observationSequenceValidatorModel.ValidateObservationSequenceGuid(sequenceGuid));
        }

        /// <summary>
        /// Observation sequence validator throws exception if invalid observation sequence GUID passed in validation method
        /// </summary>
        /// <param name="sequenceGuid">Observation sequence GUID string reference value</param>
        [Test]
        [TestCase("000000000000x0000000000000000000")]
        [TestCase("000000000afaq0000000000000000000")]
        [TestCase("00000000/0000-0000-0000-0000000000001")]
        [TestCase("00000000-0000-0000-0000-0ff00a000")]
        public void ObservationSequenceValidatorModel_WhenCheckingInvalidGuidFormat_MethodThrowsWrongObservationDataException(string sequenceGuid)
        {
            var observationSequenceValidatorModel = new ObservationSequenceValidatorModel();

            Assert.Catch<WrongObservationDataException>(() => observationSequenceValidatorModel.ValidateObservationSequenceGuid(sequenceGuid));
        }

        /// <summary>
        /// Observation sequence validator doesn't throw any exception if valid observation sequence passed in validation method
        /// </summary>
        /// <param name="isSealed">Observation sequence is sealed by traffic light red color observation flag value</param>
        /// <param name="observations">Sequence of observations collection reference value</param>
        [Test]
        [TestCaseSource("GenerateValidObservationDataTestCaseCollection")]
        public void ObservationSequenceValidatorModel_WhenCheckingValidObservationSequence_MethodPassedWithNoException(
            bool isSealed,
            List<ObservationModel> observations
        ) {
            var observationSequenceValidatorModel = new ObservationSequenceValidatorModel();

            Assert.DoesNotThrow(() => observationSequenceValidatorModel.ValidateObservationSequence(isSealed, observations));
        }

        /// <summary>
        /// Observation sequence validator throws exception if invalid observation sequence passed in validation method
        /// </summary>
        /// <param name="isSealed">Observation sequence is sealed by traffic light red color observation flag value</param>
        /// <param name="observations">Sequence of observations collection reference value</param>
        [Test]
        [TestCaseSource("GenerateInvalidObservationDataTestCaseCollection")]
        public void ObservationSequenceValidatorModel_WhenCheckingInvalidObservationSequence_MethodThrowsWrongObservationDataException(
            bool isSealed,
            List<ObservationModel> observations
        ) {
            var observationSequenceValidatorModel = new ObservationSequenceValidatorModel();

            Assert.Catch<WrongObservationDataException>(() => observationSequenceValidatorModel.ValidateObservationSequence(isSealed, observations));
        }
    }
}
