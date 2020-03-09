using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;

namespace TrafficLightDataAnalyzer.Model.Validation.Validator.TrafficLight
{
    /// <summary>
    /// Traffic light <see cref="DigitsValueModel">DigitsValueModel</see> validator model class.
    /// </summary>
    internal class DigitsValueValidatorModel : IValidator<DigitsValueModel>
    {
        /// <summary>
        /// Object validation method.
        /// </summary>
        /// <param name="objectForCheck">Object which one must be validated.</param>
        /// <returns>True, if object seems to be valid one. Otherwise, returns false.</returns>
        public bool IsValid(DigitsValueModel objectForCheck)
        {
            return !(objectForCheck.HigherDigitData is null) &&
                   !(objectForCheck.LowerDigitData is null) &&
                   objectForCheck.HigherDigitData != DigitModel.Undefined &&
                   objectForCheck.LowerDigitData != DigitModel.Undefined;
        }
    }
}
