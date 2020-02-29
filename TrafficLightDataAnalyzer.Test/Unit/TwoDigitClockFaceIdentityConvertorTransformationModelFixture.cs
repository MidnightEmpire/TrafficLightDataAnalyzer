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
    /// Two digit clock face identity convertor transformation model tests fixture
    /// </summary>
    [TestFixture]
    internal class TwoDigitClockFaceIdentityConvertorTransformationModelFixture
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

                    new List<TwoDigitClockFaceObservationBinaryCodeValueModel>()
                    {
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0011_1010, 0b0001_0010),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0101_1011, 0b0101_0010),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0111_1111, 0b0110_1111),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0101_1011, 0b0111_1111),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0111_0111, 0b0111_0111),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0101_1011, 0b0101_1101),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0101_1101, 0b0001_0010),
                        new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0001_0010, 0b0101_1101)
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
        /// Range transformation with invalid data pass checking method
        /// </summary>
        /// <param name="source">Source range to transform reference value</param>
        [Test]
        [TestCase(null)]
        public void TwoDigitClockFaceIdentityConvertorTransformationModel_WhenTryToTransformsWithInvalidData_ThrowsArgumentOutOfRangeException(
            IEnumerable<TwoDigitClockFaceValueModel> source
        ) {
            var transformationFactory = new TransformationFactoryModel();

            var transformer = transformationFactory.CreateTwoDigitClockFaceIdentityConvertorTransformer();

            Assert.Catch<ArgumentOutOfRangeException>(() => transformer.Transform(source).ToList());
        }

        /// <summary>
        /// Range transformation with proper data checking method
        /// </summary>
        /// <param name="source">Source range to transform reference value</param>
        /// <param name="expectedRange">Expected transformed range collection reference value</param>
        [Test]
        [TestCaseSource("ValidTransformationSourceDataTestCaseCollection")]
        public void TwoDigitClockFaceIdentityConvertorTransformationModel_WhenTransformsRangeWithValidData_ObtainProperRange(
            IEnumerable<TwoDigitClockFaceValueModel> source,
            IEnumerable<TwoDigitClockFaceObservationBinaryCodeValueModel> expectedRange
        ) {
            var transformationFactory = new TransformationFactoryModel();

            var transformer = transformationFactory.CreateTwoDigitClockFaceIdentityConvertorTransformer();

            var result = transformer.Transform(source).ToList();

            Assert.AreEqual(expectedRange, result);
        }
    }
}
