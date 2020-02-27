using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Data;

namespace TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter
{
    /// <summary>
    /// Two digit clock face value model class
    /// </summary>
    internal class TwoDigitClockFaceValueModel : BaseTwoDigitClockValuePresenterModel<SevenSegmentDigitModel>
    {
        #region Object overrides

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns>A string that represents the current object</returns>
        public override string ToString()
        {
            return $"Clock face value: {this.HigherDigitData.Value}{this.LowerDigitData.Value}";
        }

        #endregion

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="higherDigitData">Higher digit data reference value</param>
        /// <param name="lowerDigitData">Lower digit data reference value</param>
        public TwoDigitClockFaceValueModel(SevenSegmentDigitModel higherDigit, SevenSegmentDigitModel lowerDigit)
            : base(higherDigit, lowerDigit)
        {
        }
    }
}
