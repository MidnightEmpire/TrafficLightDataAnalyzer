using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;

namespace TrafficLightDataAnalyzer.Model.Transformation.RangeTransformer
{
    /// <summary>
    /// Two digit clock face identity convertor transformation model class
    /// </summary>
    internal class TwoDigitClockFaceIdentityConvertorTransformationModel : IRangeTransformer<TwoDigitClockFaceValueModel, TwoDigitClockFaceObservationBinaryCodeValueModel>
    {
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
                sourceItem.HigherDigitData.BinaryCode,
                sourceItem.LowerDigitData.BinaryCode
            ));
        }
    }
}
