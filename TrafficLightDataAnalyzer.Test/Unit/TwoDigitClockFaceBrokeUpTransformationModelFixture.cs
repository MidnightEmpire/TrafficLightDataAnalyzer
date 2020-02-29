using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Transformation;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// Two digit clock face broke up transformation model tests fixture
    /// </summary>
    [TestFixture]
    internal class TwoDigitClockFaceBrokeUpTransformationModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Valid transformation source data test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> ValidTransformationSourceDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(
                    new List<TwoDigitClockFaceValueModel>()
                    {
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit1),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit7),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit8, SevenSegmentDigitModel.Digit6),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit8),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit0, SevenSegmentDigitModel.Digit0),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit2),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit2, SevenSegmentDigitModel.Digit1),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit1, SevenSegmentDigitModel.Digit2)
                    },

                    new TwoDigitClockFaceObservationBinaryCodeValueModel(
                        0b1111_1111,
                        0b1111_1111
                    ),

                    new List<TwoDigitClockFaceObservationBinaryCodeValueModel>()
                    {
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0000_0000, 0b0000_0000),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0000_0000, 0b0000_0000),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0000_0000, 0b0000_0000),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0000_0000, 0b0000_0000),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0000_0000, 0b0000_0000),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0000_0000, 0b0000_0000),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0000_0000, 0b0000_0000),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0000_0000, 0b0000_0000)
                    }
                );

                yield return new TestCaseData(
                    new List<TwoDigitClockFaceValueModel>()
                    {
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit4, SevenSegmentDigitModel.Digit1),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit7),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit8, SevenSegmentDigitModel.Digit6),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit8),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit0, SevenSegmentDigitModel.Digit0),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit3, SevenSegmentDigitModel.Digit2),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit2, SevenSegmentDigitModel.Digit1),
                        new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit1, SevenSegmentDigitModel.Digit2)
                    },

                    new TwoDigitClockFaceObservationBinaryCodeValueModel(
                        0b1001_0011,
                        0b1001_1100
                    ),

                    new List<TwoDigitClockFaceObservationBinaryCodeValueModel>()
                    {
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0010_1000, 0b0000_0010),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0100_1000, 0b0100_0010),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0110_1100, 0b0110_0011),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0100_1000, 0b0110_0011),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0110_0100, 0b0110_0011),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0100_1000, 0b0100_0001),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0100_1100, 0b0000_0010),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0000_0000, 0b0100_0001)
                    }
                );
            }
        }

        /// <summary>
        /// Invalid transformation source data test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> InvalidTransformationSourceDataTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(
                    null,
                    new TwoDigitClockFaceObservationBinaryCodeValueModel(
                        0b1111_1111,
                        0b1111_1111
                    )
                );

                yield return new TestCaseData(
                    null,
                    new TwoDigitClockFaceObservationBinaryCodeValueModel(
                        0b0000_0000,
                        0b0000_0000
                    )
                );
            }
        }

        #endregion

        /// <summary>
        /// Range transformation with invalid data pass constructor checking method
        /// </summary>
        /// <param name="binaryCodeMasks">Binary code transformation masks reference value</param>
        [Test]
        [TestCase(null)]
        public void TwoDigitClockFaceBrokeUpTransformationModel_WhenTryToConstructTransformerWithEmptyBinaryCodes_ThrowsArgumentOutOfRangeException(
            TwoDigitClockFaceObservationBinaryCodeValueModel binaryCodeMasks
        ) {
            var transformationFactory = new TransformationFactoryModel();

            Assert.Catch<ArgumentOutOfRangeException>(() => transformationFactory.CreateTwoDigitClockFaceBrokeUpTransformer(binaryCodeMasks));
        }

        /// <summary>
        /// Range transformation with invalid data pass checking method
        /// </summary>
        /// <param name="source">Source range to transform reference value</param>
        /// <param name="binaryCodeMasks">Binary code transformation masks reference value</param>
        [Test]
        [TestCaseSource("InvalidTransformationSourceDataTestCaseCollection")]
        public void TwoDigitClockFaceBrokeUpTransformationModel_WhenTryToTransformsWithInvalidData_ThrowsArgumentOutOfRangeException(
            IEnumerable<TwoDigitClockFaceValueModel> source,
            TwoDigitClockFaceObservationBinaryCodeValueModel binaryCodeMasks
        ) {
            var transformationFactory = new TransformationFactoryModel();

            var transformer = transformationFactory.CreateTwoDigitClockFaceBrokeUpTransformer(binaryCodeMasks);

            Assert.Catch<ArgumentOutOfRangeException>(() => transformer.Transform(source).ToList());
        }

        /// <summary>
        /// Range transformation with proper data checking method
        /// </summary>
        /// <param name="source">Source range to transform reference value</param>
        /// <param name="binaryCodeMasks">Binary code transformation masks reference value</param>
        /// <param name="expectedRange">Expected transformed range collection reference value</param>
        [Test]
        [TestCaseSource("ValidTransformationSourceDataTestCaseCollection")]
        public void TwoDigitClockFaceBrokeUpTransformationModel_WhenTransformsRangeWithValidData_ObtainProperRange(
            IEnumerable<TwoDigitClockFaceValueModel> source,
            TwoDigitClockFaceObservationBinaryCodeValueModel binaryCodeMasks,
            IEnumerable<TwoDigitClockFaceObservationBinaryCodeValueModel> expectedRange
        ) {
            var transformationFactory = new TransformationFactoryModel();

            var transformer = transformationFactory.CreateTwoDigitClockFaceBrokeUpTransformer(binaryCodeMasks);

            var result = transformer.Transform(source).ToList();

            Assert.AreEqual(expectedRange, result);
        }
    }
}
