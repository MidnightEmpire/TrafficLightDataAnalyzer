using System;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Conversion;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;
using TrafficLightDataAnalyzer.Model.Validation;

namespace TrafficLightDataAnalyzer.Model.Transformation.Transformer.TrafficLight.ClockFace
{
    /// <summary>
    /// <see cref="DigitsValueModel">DigitsValueModel</see> broke up transformation model class.
    /// </summary>
    internal class DigitsValueModelBrokeUpTransformerModel : ITransformer<DigitsValueModel, BinaryCodesValueModel>
    {
        /// <summary>
        /// <see cref="ConversionFactoryModel">ConversionFactoryModel</see> reference field.
        /// </summary>
        private static readonly ConversionFactoryModel _conversionFactory;

        /// <summary>
        /// <see cref="ValidationFactoryModel">ValidationFactoryModel</see> reference field.
        /// </summary>
        private static readonly ValidationFactoryModel _validationFactory;

        /// <summary>
        /// Broke-up <see cref="BinaryCodesValueModel">binary codes</see> masks reference field.
        /// </summary>
        private readonly BinaryCodesValueModel _brokeUpBinaryCodesMasks;

        /// <summary>
        /// Try raise exceptions for <see cref="DigitsValueModelBrokeUpTransformerModel.Transform(DigitsValueModel)">Transform</see> method,
        /// if <paramref name="source" /> parameter is invalid one service method.
        /// </summary>
        /// <param name="source">Source item value.</param>
        /// <exception cref="ArgumentNullException">Throws, if <paramref name="source" /> is null one.</exception>
        /// <exception cref="InvalidArgumentStateException">Throws, if <paramref name="source" /> is invalid one.</exception>
        private void tryRaiseTransformArgumentExceptions(DigitsValueModel source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var argumentValidator = DigitsValueModelBrokeUpTransformerModel._validationFactory.CreateDigitsValueValidator();

            if (!argumentValidator.IsValid(source))
            {
                throw new InvalidArgumentStateException(nameof(source));
            }
        }

        /// <summary>
        /// Item transformation performing method.
        /// </summary>
        /// <param name="source">Source item value.</param>
        /// <returns>Result/transformed item value.</returns>
        /// <exception cref="ArgumentNullException">Throws, if <paramref name="source" /> is null one.</exception>
        /// <exception cref="InvalidArgumentStateException">Throws, if <paramref name="source" /> is invalid one.</exception>
        public BinaryCodesValueModel Transform(DigitsValueModel source)
        {
            this.tryRaiseTransformArgumentExceptions(source);

            var converter = DigitsValueModelBrokeUpTransformerModel._conversionFactory.CreateDigitTo7SegmentCodeConverter();

            var higherDigitBinaryCode = converter.Convert(source.HigherDigitData);
            var lowerDigitBinaryCode = converter.Convert(source.LowerDigitData);

            return new BinaryCodesValueModel(
                (byte) (higherDigitBinaryCode & ~this._brokeUpBinaryCodesMasks.HigherDigitData & ConversionFactoryModel.SevenSegmentBinaryCodePatternMask),
                (byte) (lowerDigitBinaryCode & ~this._brokeUpBinaryCodesMasks.LowerDigitData & ConversionFactoryModel.SevenSegmentBinaryCodePatternMask)
            );
        }

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="brokeUpBinaryCodesMasks">Broke-up <see cref="BinaryCodesValueModel">binary codes</see> masks reference value. Each digit specify broken segments by "1" bit, working one by "0" bit.</param>
        /// <exception cref="ArgumentNullException">Throws, if <paramref name="brokeUpBinaryCodesMasks" /> is null one.</exception>
        public DigitsValueModelBrokeUpTransformerModel(BinaryCodesValueModel brokeUpBinaryCodesMasks)
        {
            if (brokeUpBinaryCodesMasks == null)
            {
                throw new ArgumentNullException(nameof(brokeUpBinaryCodesMasks));
            }

            this._brokeUpBinaryCodesMasks = brokeUpBinaryCodesMasks;
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static DigitsValueModelBrokeUpTransformerModel()
        {
            DigitsValueModelBrokeUpTransformerModel._conversionFactory = new ConversionFactoryModel();
            DigitsValueModelBrokeUpTransformerModel._validationFactory = new ValidationFactoryModel();
        }
    }
}
