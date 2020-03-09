using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Prediction;
using TrafficLightDataAnalyzer.Model.Prediction.Predictor.Simple.TrafficLight;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="PossibleDigitsByBinaryCodePredictorModel" /> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class PossibleDigitsByBinaryCodePredictorModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Valid prediction pair data test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> ValidPredictionDataPairTestCaseCollection
        {
            get
            {
                yield return new TestCaseData((byte) 0b0000_0000, DigitModel.AllDigits);
                yield return new TestCaseData((byte) 0b1000_0000, Enumerable.Empty<DigitModel>());
                yield return new TestCaseData((byte) 0b1000_1000, Enumerable.Empty<DigitModel>());
                yield return new TestCaseData((byte) 0b1001_1000, Enumerable.Empty<DigitModel>());

                yield return new TestCaseData(
                    (byte) 0b0001_0001,

                    new List<DigitModel>()
                    {
                        DigitModel.Digit0,
                        DigitModel.Digit2,
                        DigitModel.Digit3,
                        DigitModel.Digit8,
                        DigitModel.Digit9
                    }
                );

                yield return new TestCaseData(
                    (byte) 0b0011_0001,

                    new List<DigitModel>()
                    {
                        DigitModel.Digit0,
                        DigitModel.Digit8,
                        DigitModel.Digit9
                    }
                );

                yield return new TestCaseData(
                    (byte) 0b0011_1001,

                    new List<DigitModel>()
                    {
                        DigitModel.Digit8,
                        DigitModel.Digit9
                    }
                );

                yield return new TestCaseData(
                    (byte) 0b0111_1100,

                    new List<DigitModel>()
                    {
                        DigitModel.Digit8
                    }
                );
            }
        }

        #endregion

        /// <summary>
        /// Proper instance of <see cref="IPredictor{TInputData, TPrediction}">IPredictor</see> creation service method.
        /// </summary>
        /// <returns>Proper instance of <see cref="IPredictor{TInputData, TPrediction}">IPredictor</see>.</returns>
        private IPredictor<byte, IEnumerable<DigitModel>> createPredictor()
        {
            var predictionFactory = new PredictionFactoryModel();

            return predictionFactory.CreatePossibleDigitsByBinaryCodePredictor();
        }

        /// <summary>
        /// <see cref="DigitModel">DigitModel</see> values prediction by <paramref name="binaryCode" /> value checking method.
        /// </summary>
        /// <param name="binaryCode">Source/input binary code value to make preditcion.</param>
        /// <param name="expectedPrediction">Expected <see cref="IEnumerable{T}">IEnumerable</see> of <see cref="DigitModel">DigitModel</see> prediction value.</param>
        [Test]
        [TestCaseSource(nameof(PossibleDigitsByBinaryCodePredictorModelFixture.ValidPredictionDataPairTestCaseCollection))]
        public void MakeGuess_ValidBinaryCode_ReturnsProperPrediction(byte binaryCode, IEnumerable<DigitModel> expectedPrediction)
        {
            var predictor = this.createPredictor();

            var result = predictor.MakeGuess(binaryCode).ToList();

            Assert.AreEqual(expectedPrediction, result);
        }
    }
}
