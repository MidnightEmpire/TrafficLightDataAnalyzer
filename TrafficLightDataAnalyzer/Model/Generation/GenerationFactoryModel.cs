using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;
using TrafficLightDataAnalyzer.Model.Generation.Generator.Range.TrafficLight.ClockFace;

namespace TrafficLightDataAnalyzer.Model.Generation
{
    /// <summary>
    /// Generation factory model class.
    /// </summary>
    internal class GenerationFactoryModel
    {
        /// <summary>
        /// <see cref="SequentialDigitsValueModelGeneratorModel">SequentialDigitsValueModelGeneratorModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="SequentialDigitsValueModelGeneratorModel">SequentialDigitsValueModelGeneratorModel</see>.</returns>
        public IRangeGenerator<DigitsValueModel> CreateSequentialDigitsValueModelGenerator()
        {
            return new SequentialDigitsValueModelGeneratorModel();
        }
    }
}
