using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;
using TrafficLightDataAnalyzer.Model.Generation.RangeGenerator;

namespace TrafficLightDataAnalyzer.Model.Generation
{
    /// <summary>
    /// Generation factory model class
    /// </summary>
    internal class GenerationFactoryModel
    {
        /// <summary>
        /// Sequential countdown digit range generator model instance obtaining method
        /// </summary>
        /// <returns>New instance of sequential countdown digit range generator model</returns>
        public IRangeGenerator<TwoDigitClockFaceValueModel> CreateSequentialCountdownDigitRangeGenerator()
        {
            return new SequentialCountdownDigitRangeGeneratorModel();
        }
    }
}
