using System;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Observation;

namespace TrafficLightDataAnalyzer.Test.Environment
{
    /// <summary>
    /// Observation model creation class
    /// </summary>
    internal class ObservationModelCreator
    {
        /// <summary>
        /// Convert binary code to observation model compatible input string format value
        /// </summary>
        /// <param name="binaryCode">Source binary code value</param>
        /// <returns>Observation model compatible input string format reference value</returns>
        private static string convertBinaryCodeToString(byte binaryCode)
        {
            var maskedBinaryCode = (byte) (binaryCode & SevenSegmentDigitModel.BinaryCodePatternMask);

            var result = Convert.ToString(maskedBinaryCode, 2);

            result = result.PadLeft(7, '0');

            return result;
        }

        /// <summary>
        /// Observation model creation method
        /// </summary>
        /// <param name="color">Observation model color reference value</param>
        /// <param name="binaryCodes">Registered digits binary codes reference value</param>
        /// <returns>Properly created observation model reference value</returns>
        public ObservationModel CreateObservationModel(
            TrafficLightColorModel color,
            TwoDigitClockFaceObservationBinaryCodeValueModel binaryCodes
        ) {
            if (color == null)
            {
                throw new ArgumentOutOfRangeException(nameof(color));
            }

            if (binaryCodes == null)
            {
                throw new ArgumentOutOfRangeException(nameof(binaryCodes));
            }

            return new ObservationModel(
                color.Name,
                ObservationModelCreator.convertBinaryCodeToString(binaryCodes.HigherDigitData),
                ObservationModelCreator.convertBinaryCodeToString(binaryCodes.LowerDigitData)
            );
        }
    }
}
