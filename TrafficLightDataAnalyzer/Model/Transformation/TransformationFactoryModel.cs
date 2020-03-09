using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;
using TrafficLightDataAnalyzer.Model.Transformation.Transformer.TrafficLight.ClockFace;

namespace TrafficLightDataAnalyzer.Model.Transformation
{
    /// <summary>
    /// Transformation factory model class.
    /// </summary>
    internal class TransformationFactoryModel
    {
        /// <summary>
        /// <see cref="DigitsValueModelBrokeUpTransformerModel">DigitsValueModelBrokeUpTransformerModel</see> instance obtaining method.
        /// </summary>
        /// <param name="brokeUpBinaryCodesMasks">Broke-up <see cref="BinaryCodesValueModel">binary codes</see> masks reference value. Each digit specify broken segments by "1" bit, working one by "0" bit.</param>
        /// <returns>New instance of <see cref="DigitsValueModelBrokeUpTransformerModel">ColorNameValidatorModel</see>.</returns>
        public ITransformer<DigitsValueModel, BinaryCodesValueModel> CreateDigitsValueModelBrokeUpTransformer(BinaryCodesValueModel brokeUpBinaryCodesMasks)
        {
            return new DigitsValueModelBrokeUpTransformerModel(brokeUpBinaryCodesMasks);
        }
    }
}
