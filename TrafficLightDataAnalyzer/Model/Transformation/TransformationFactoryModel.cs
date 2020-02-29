using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;
using TrafficLightDataAnalyzer.Model.Transformation.RangeTransformer;

namespace TrafficLightDataAnalyzer.Model.Transformation
{
    /// <summary>
    /// Transformation factory model class
    /// </summary>
    internal class TransformationFactoryModel
    {
        /// <summary>
        /// Two digit clock face broke up transformation model instance obtaining method
        /// </summary>
        /// <param name="brokeUpBinaryCodesMasks">Broke-up binary codes masks reference value. Each digit specify broken segments by "1" bit, working one by "0" bit</param>
        /// <returns>New instance of two digit clock face broke up transformation model</returns>
        public IRangeTransformer<TwoDigitClockFaceValueModel, TwoDigitClockFaceObservationBinaryCodeValueModel> CreateTwoDigitClockFaceBrokeUpTransformer(
            TwoDigitClockFaceObservationBinaryCodeValueModel brokeUpBinaryCodesMasks
        ) {
            return new TwoDigitClockFaceBrokeUpTransformationModel(brokeUpBinaryCodesMasks);
        }
    }
}
