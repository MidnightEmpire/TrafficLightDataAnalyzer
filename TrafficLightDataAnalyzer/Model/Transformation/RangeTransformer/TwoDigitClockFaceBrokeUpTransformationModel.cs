using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;

namespace TrafficLightDataAnalyzer.Model.Transformation.RangeTransformer
{
    /// <summary>
    /// Two digit clock face broke up transformation model class
    /// </summary>
    internal class TwoDigitClockFaceBrokeUpTransformationModel : IRangeTransformer<TwoDigitClockFaceValueModel, TwoDigitClockFaceObservationBinaryCodeValueModel>
    {
        /// <summary>
        /// Broke-up binary codes masks reference field
        /// </summary>
        private readonly TwoDigitClockFaceObservationBinaryCodeValueModel _brokeUpBinaryCodesMasks;

        /// <summary>
        /// Items range transformation method
        /// </summary>
        /// <param name="source">Source range items collection reference value</param>
        /// <returns>Result/transformed range items collection reference value</returns>
        public IEnumerable<TwoDigitClockFaceObservationBinaryCodeValueModel> Transform(IEnumerable<TwoDigitClockFaceValueModel> source)
        {
            if (source == null)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }

            return source.Select((sourceItem) => new TwoDigitClockFaceObservationBinaryCodeValueModel(
                (byte) (sourceItem.HigherDigitData.BinaryCode & ~this._brokeUpBinaryCodesMasks.HigherDigitData & SevenSegmentDigitModel.BinaryCodePatternMask),
                (byte) (sourceItem.LowerDigitData.BinaryCode & ~this._brokeUpBinaryCodesMasks.LowerDigitData & SevenSegmentDigitModel.BinaryCodePatternMask)
            ));
        }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="brokeUpBinaryCodesMasks">Broke-up binary codes masks reference value. Each digit specify broken segments by "1" bit, working one by "0" bit</param>
        public TwoDigitClockFaceBrokeUpTransformationModel(TwoDigitClockFaceObservationBinaryCodeValueModel brokeUpBinaryCodesMasks)
        {
            if (brokeUpBinaryCodesMasks == null)
            {
                throw new ArgumentOutOfRangeException(nameof(brokeUpBinaryCodesMasks));
            }

            this._brokeUpBinaryCodesMasks = brokeUpBinaryCodesMasks;
        }
    }
}
