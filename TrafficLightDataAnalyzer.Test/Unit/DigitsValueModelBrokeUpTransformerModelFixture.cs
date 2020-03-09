using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;
using TrafficLightDataAnalyzer.Model.Transformation;
using TrafficLightDataAnalyzer.Model.Transformation.Transformer.TrafficLight.ClockFace;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="DigitsValueModelBrokeUpTransformerModel">DigitsValueModelBrokeUpTransformerModel</see> tests fixture.
    /// </summary>
    [TestFixture]
    internal class DigitsValueModelBrokeUpTransformerModelFixture
    {
        #region TestCaseSource

        /// <summary>
        /// Valid transformation source data triple test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> ValidTransformationSourceDataTripleTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(
                    new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit1),
                    new BinaryCodesValueModel(0b1111_1111, 0b1111_1111),
                    new BinaryCodesValueModel(0b0000_0000, 0b0000_0000)
                );

                yield return new TestCaseData(
                    new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit7),
                    new BinaryCodesValueModel(0b1111_1111, 0b1111_1111),
                    new BinaryCodesValueModel(0b0000_0000, 0b0000_0000)
                );

                yield return new TestCaseData(
                    new DigitsValueModel(DigitModel.Digit0, DigitModel.Digit0),
                    new BinaryCodesValueModel(0b1111_1111, 0b1111_1111),
                    new BinaryCodesValueModel(0b0000_0000, 0b0000_0000)
                );

                yield return new TestCaseData(
                    new DigitsValueModel(DigitModel.Digit4, DigitModel.Digit1),
                    new BinaryCodesValueModel(0b1001_0011, 0b1001_1100),
                    new BinaryCodesValueModel(0b0010_1000, 0b0000_0010)
                );

                yield return new TestCaseData(
                    new DigitsValueModel(DigitModel.Digit3, DigitModel.Digit8),
                    new BinaryCodesValueModel(0b1001_0011, 0b1001_1100),
                    new BinaryCodesValueModel(0b0100_1000, 0b0110_0011)
                );

                yield return new TestCaseData(
                    new DigitsValueModel(DigitModel.Digit2, DigitModel.Digit1),
                    new BinaryCodesValueModel(0b1001_0011, 0b1001_1100),
                    new BinaryCodesValueModel(0b0100_1100, 0b0000_0010)
                );
            }
        }

        /// <summary>
        /// Invalid transformation source data pair test case collection provider.
        /// </summary>
        private static IEnumerable<TestCaseData> InvalidTransformationSourceDataPairTestCaseCollection
        {
            get
            {
                yield return new TestCaseData(
                    new DigitsValueModel(null, null),
                    new BinaryCodesValueModel(0b1111_1111, 0b1111_1111)
                );

                yield return new TestCaseData(
                    new DigitsValueModel(DigitModel.Undefined, null),
                    new BinaryCodesValueModel(0b1111_1111, 0b1111_1111)
                );

                yield return new TestCaseData(
                    new DigitsValueModel(null, DigitModel.Undefined),
                    new BinaryCodesValueModel(0b1111_1111, 0b1111_1111)
                );

                yield return new TestCaseData(
                    new DigitsValueModel(DigitModel.Undefined, DigitModel.Undefined),
                    new BinaryCodesValueModel(0b1111_1111, 0b1111_1111)
                );
            }
        }

        #endregion

        /// <summary>
        /// Proper instance of <see cref="ITransformer{TSourceItem, TTargetItem}">ITransformer</see> creation service method.
        /// </summary>
        /// <param name="brokeUpBinaryCodesMasks">Broke-up <see cref="BinaryCodesValueModel">binary codes</see> masks reference value.</param>
        /// <returns>Proper instance of <see cref="ITransformer{TSourceItem, TTargetItem}">ITransformer</see>.</returns>
        private ITransformer<DigitsValueModel, BinaryCodesValueModel> createTransformer(BinaryCodesValueModel brokeUpBinaryCodesMasks)
        {
            var transformationFactory = new TransformationFactoryModel();

            return transformationFactory.CreateDigitsValueModelBrokeUpTransformer(brokeUpBinaryCodesMasks);
        }

        /// <summary>
        /// Range transformation with null binary code masks argument pass constructor checking method.
        /// </summary>
        [Test]
        public void Constructor_BinaryCodeMasksIsNull_ThrowsArgumentNullException()
        {
            Assert.Catch<ArgumentNullException>(() => this.createTransformer(null));
        }

        /// <summary>
        /// Range transformation with null binary code masks source value pass checking method.
        /// </summary>
        [Test]
        public void Transform_SourceValueIsNull_ThrowsArgumentNullException()
        {
            var transformer = this.createTransformer((0b0000_0000, 0b0000_0000));

            Assert.Catch<ArgumentNullException>(() => transformer.Transform(null).ToList());
        }

        /// <summary>
        /// Range transformation with invalid <paramref name="source" /> data pass checking method.
        /// </summary>
        /// <param name="source">Source value to transform.</param>
        /// <param name="binaryCodeMasks">Binary code transformation masks value.</param>
        [Test]
        [TestCaseSource(nameof(DigitsValueModelBrokeUpTransformerModelFixture.InvalidTransformationSourceDataPairTestCaseCollection))]
        public void Transform_InvalidSourceData_ThrowsInvalidArgumentStateException(
            DigitsValueModel source,
            BinaryCodesValueModel binaryCodeMasks
        ) {
            var transformer = this.createTransformer(binaryCodeMasks);

            Assert.Catch<InvalidArgumentStateException>(() => transformer.Transform(source).ToList());
        }

        /// <summary>
        /// Range transformation with proper <paramref name="source" /> and <paramref name="binaryCodeMasks" /> data checking method.
        /// </summary>
        /// <param name="source">Source value to transform.</param>
        /// <param name="binaryCodeMasks">Binary code transformation masks value.</param>
        /// <param name="expectedRange">Expected transformation result value.</param>
        [Test]
        [TestCaseSource(nameof(DigitsValueModelBrokeUpTransformerModelFixture.ValidTransformationSourceDataTripleTestCaseCollection))]
        public void Transform_ValidSourceData_ReturnsExpectedValue(
            DigitsValueModel source,
            BinaryCodesValueModel binaryCodeMasks,
            BinaryCodesValueModel expectedRange
        ) {
            var transformer = this.createTransformer(binaryCodeMasks);

            var result = transformer.Transform(source).ToList();

            Assert.AreEqual(expectedRange, result);
        }
    }
}
