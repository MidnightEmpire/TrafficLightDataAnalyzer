using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Observation;
using TrafficLightDataAnalyzer.Model.ObservationSequence;
using TrafficLightDataAnalyzer.Test.Environment;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// Observation sequence model tests fixture
    /// </summary>
    [TestFixture]
    internal class ObservationSequenceModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Valid observation sequence data test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> ValidObservationSequenceDataTestCaseCollection
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

                yield return new TestCaseData("00000000000000000000000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("0000000000000000aaf0000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-0ff0ba000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000000000000000000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000000000000000000000000000", null);
                yield return new TestCaseData("0000000000000000aaf0000000000000", null);
                yield return new TestCaseData("00000000-0000-0000-0000-000000000000", null);
                yield return new TestCaseData("00000000-0000-0000-0000-0ff0ba000000", null);
                yield return new TestCaseData("00000000000000000000000000000000", null);

                observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddSequentialObservationRange(
                    TrafficLightColorModel.Green,
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit0),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit1, SevenSegmentDigitModel.Digit1)
                );

                yield return new TestCaseData("00000000000000000000000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("0000000000000000aaf0000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-0ff0ba000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000000000000000000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000000000000000000000000000", null);
                yield return new TestCaseData("0000000000000000aaf0000000000000", null);
                yield return new TestCaseData("00000000-0000-0000-0000-000000000000", null);
                yield return new TestCaseData("00000000-0000-0000-0000-0ff0ba000000", null);
                yield return new TestCaseData("00000000000000000000000000000000", null);
            }
        }

        /// <summary>
        /// Invalid observation sequence data test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> InvalidObservationSequenceDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(null, null);

                var observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddSequentialObservationRange(
                    TrafficLightColorModel.Green,
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit0),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit0, SevenSegmentDigitModel.Digit1)
                );

                observationGenerator.AddObservation(TrafficLightColorModel.Red);

                yield return new TestCaseData(null, observationGenerator.Observations.ToArray());
                yield return new TestCaseData("000000000000x0000000000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("000000000afaq0000000000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000/0000-0000-0000-0000000000001", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-0ff00a000", observationGenerator.Observations.ToArray());

                observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddSequentialObservationRange(
                    TrafficLightColorModel.Green,
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit0),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit1, SevenSegmentDigitModel.Digit1)
                );

                yield return new TestCaseData(null, observationGenerator.Observations.ToArray());
                yield return new TestCaseData("000000000000x0000000000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("000000000afaq0000000000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000/0000-0000-0000-0000000000001", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-0ff00a000", observationGenerator.Observations.ToArray());

                observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddSequentialObservationRange(
                    TrafficLightColorModel.Green,
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit0),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit1, SevenSegmentDigitModel.Digit1)
                );

                observationGenerator.AddObservation(TrafficLightColorModel.Red);

                observationGenerator.AddSequentialObservationRange(
                    TrafficLightColorModel.Green,
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit1, SevenSegmentDigitModel.Digit0),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit0, SevenSegmentDigitModel.Digit1)
                );

                yield return new TestCaseData("00000000000000000000000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("0000000000000000aaf0000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-0ff0ba000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000000000000000000000000000", observationGenerator.Observations.ToArray());

                observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddObservation(TrafficLightColorModel.Red);
                observationGenerator.AddObservation(TrafficLightColorModel.Green);

                yield return new TestCaseData("00000000000000000000000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("0000000000000000aaf0000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-0ff0ba000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000000000000000000000000000", observationGenerator.Observations.ToArray());

                observationGenerator = new ObservationSequenceGenerator();

                observationGenerator.AddObservation(TrafficLightColorModel.Red);

                yield return new TestCaseData("00000000000000000000000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("0000000000000000aaf0000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-000000000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000-0000-0000-0000-0ff0ba000000", observationGenerator.Observations.ToArray());
                yield return new TestCaseData("00000000000000000000000000000000", observationGenerator.Observations.ToArray());
            }
        }

        #endregion

        /// <summary>
        /// Observation sequence constructor doesn't throw any exception if valid observation sequence data passed in constructor method
        /// </summary>
        /// <param name="sequenceGuid">Observation sequence GUID string reference value</param>
        /// <param name="observations">Sequence of observations collection reference value</param>
        [Test]
        [TestCaseSource("ValidObservationSequenceDataTestCaseCollection")]
        public void ObservationSequenceModel_WhenCreatingNewInstanceWithValidData_CreationPassedWithNoException(
            string sequenceGuid,
            ObservationModel[] observations
        ) {
            Assert.DoesNotThrow(() => new ObservationSequenceModel(sequenceGuid, observations));
        }

        /// <summary>
        /// Observation sequence constructor throws exception if invalid observation sequence data passed in constructor method
        /// </summary>
        /// <param name="sequenceGuid">Observation sequence GUID string reference value</param>
        /// <param name="observations">Sequence of observations collection reference value</param>
        [Test]
        [TestCaseSource("InvalidObservationSequenceDataTestCaseCollection")]
        public void ObservationSequenceModel_WhenCreatingNewInstanceWithInvalidData_ConstructorThrowsWrongObservationDataException(
            string sequenceGuid,
            ObservationModel[] observations
        ) {
            Assert.Catch<WrongObservationDataException>(() => new ObservationSequenceModel(sequenceGuid, observations));
        }

        /// <summary>
        /// Observation sequence add method throws exception when red color observation added into empty observation sequence method
        /// </summary>
        [Test]
        public void ObservationSequenceModel_WhenTryingToAddRedIntoEmptySequence_MethodThrowsWrongObservationDataException()
        {
            var observationModel = new ObservationModel("red");

            var observationSequence = new ObservationSequenceModel(Guid.Empty.ToString());

            Assert.Catch<WrongObservationDataException>(() => observationSequence.RegisterNewObservation(observationModel));
        }

        /// <summary>
        /// Observation sequence add method throws exception if observation sequence is sealed method
        /// </summary>
        /// <param name="observationColorName">Observation string color name to add reference value</param>
        [Test]
        [TestCase("red")]
        [TestCase("green")]
        public void ObservationSequenceModel_WhenTryingToAddIntoSealedSequence_MethodThrowsWrongObservationDataException(
            string observationColorName
        )
        {
            var observationModel = new ObservationModel(observationColorName);

            var observationSequence = new ObservationSequenceModel(
                Guid.Empty.ToString(),
                new ObservationModel("green"),
                new ObservationModel("red")
            );

            Assert.Catch<WrongObservationDataException>(() => observationSequence.RegisterNewObservation(observationModel));
        }

        /// <summary>
        /// Observation sequence add method throws no exception if observation sequence is non-empty non-sealed one method
        /// </summary>
        /// <param name="observationColorName">Observation string color name to add reference value</param>
        [Test]
        [TestCase("red")]
        [TestCase("green")]
        public void ObservationSequenceModel_WhenTryingToAddIntoNonEmptyNonSealedSequence_MethodPassWithNoException(
            string observationColorName
        ) {
            var observationModel = new ObservationModel(observationColorName);

            var observationSequence = new ObservationSequenceModel(
                Guid.Empty.ToString(),
                new ObservationModel("green")
            );

            Assert.DoesNotThrow(() => observationSequence.RegisterNewObservation(observationModel));
        }
    }
}
