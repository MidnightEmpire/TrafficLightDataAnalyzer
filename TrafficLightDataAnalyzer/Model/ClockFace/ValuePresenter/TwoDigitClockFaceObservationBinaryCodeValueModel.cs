using System;
using System.Linq;
using TrafficLightDataAnalyzer.Model.Data;

namespace TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter
{
    /// <summary>
    /// Two digit clock face observation binary code value model class
    /// </summary>
    internal class TwoDigitClockFaceObservationBinaryCodeValueModel : BaseTwoDigitClockValuePresenterModel<byte>
    {
        #region Object overrides

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns>A string that represents the current object</returns>
        public override string ToString()
        {
            var binaryCodesStrings = this.Values
                .Select((binaryCode) => Convert.ToString(binaryCode, 2))
                .Select((binaryCodeString) => $"0b{binaryCodeString.PadLeft(8, '0')}")
                .ToArray();

            var binaryCodeString = string.Join(", ", binaryCodesStrings);

            return $"Codes: [{binaryCodeString}]";
        }

        #endregion

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="higherDigitData">Higher digit data reference value</param>
        /// <param name="lowerDigitData">Lower digit data reference value</param>
        public TwoDigitClockFaceObservationBinaryCodeValueModel(byte higherDigit, byte lowerDigit)
            : base(higherDigit, lowerDigit)
        {
        }
    }
}
