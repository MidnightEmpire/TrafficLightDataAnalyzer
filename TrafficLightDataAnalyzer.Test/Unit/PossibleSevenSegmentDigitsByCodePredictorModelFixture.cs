using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Predictor.Simple;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// Possible seven segment digits by code predictor model tests fixture
    /// </summary>
    [TestFixture]
    internal class PossibleSevenSegmentDigitsByCodePredictorModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Seven segment digits by code prediction data test case collection provider
        /// </summary>
        private static IEnumerable<TestCaseData> SevenSegmentDigitsPredictionTestCaseCollection
        {
            get
            {
                yield return new TestCaseData((byte) 0b0000_0000, SevenSegmentDigitModel.AllDigits);
                yield return new TestCaseData((byte) 0b1000_0000, Enumerable.Empty<SevenSegmentDigitModel>());
                yield return new TestCaseData((byte) 0b1000_1000, Enumerable.Empty<SevenSegmentDigitModel>());
                yield return new TestCaseData((byte) 0b1001_1000, Enumerable.Empty<SevenSegmentDigitModel>());

                yield return new TestCaseData(
                    (byte) 0b0001_0001,
                    new List<SevenSegmentDigitModel>()
                    {
                        SevenSegmentDigitModel.Digit0,
                        SevenSegmentDigitModel.Digit2,
                        SevenSegmentDigitModel.Digit3,
                        SevenSegmentDigitModel.Digit8,
                        SevenSegmentDigitModel.Digit9
                    }
                );

                yield return new TestCaseData(
                    (byte) 0b0011_0001,
                    new List<SevenSegmentDigitModel>()
                    {
                        SevenSegmentDigitModel.Digit0,
                        SevenSegmentDigitModel.Digit8,
                        SevenSegmentDigitModel.Digit9
                    }
                );

                yield return new TestCaseData(
                    (byte) 0b0011_1001,
                    new List<SevenSegmentDigitModel>()
                    {
                        SevenSegmentDigitModel.Digit8,
                        SevenSegmentDigitModel.Digit9
                    }
                );

                yield return new TestCaseData(
                    (byte) 0b0111_1100,
                    new List<SevenSegmentDigitModel>()
                    {
                        SevenSegmentDigitModel.Digit8
                    }
                );
            }
        }

        #endregion

        /// <summary>
        /// Digit prediction on proper data checking method
        /// </summary>
        /// <param name="binaryCode">Source/input binary code value to make preditcion</param>
        /// <param name="expectedPrediction">Expected digits prediction collection reference value</param>
        [Test]
        [TestCaseSource("SevenSegmentDigitsPredictionTestCaseCollection")]
        public void PossibleSevenSegmentDigitsByCodePredictorModel_WhenPredictOnValidData_ObtainProperPrediction(
            byte binaryCode,
            IEnumerable<SevenSegmentDigitModel> expectedPrediction
        ) {
            var possibleSevenSegmentDigitsByCodePredictorModel = new PossibleSevenSegmentDigitsByCodePredictorModel();

            var result = possibleSevenSegmentDigitsByCodePredictorModel.MakeGuess(binaryCode).ToList();

            Assert.AreEqual(expectedPrediction, result);
        }
    }
}
