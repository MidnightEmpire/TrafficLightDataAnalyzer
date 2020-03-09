using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;

namespace TrafficLightDataAnalyzer.Model.Validation.Validator.TrafficLight
{
    /// <summary>
    /// Traffic light digit value validator model class.
    /// </summary>
    internal class DigitValueValidatorModel : IValidator<sbyte>
    {
        /// <summary>
        /// Object validation method.
        /// </summary>
        /// <param name="objectForCheck">Object which one must be validated.</param>
        /// <returns>True, if object seems to be valid one. Otherwise, returns false.</returns>
        public bool IsValid(sbyte objectForCheck)
        {
            var color = DigitModel.FindByValue(objectForCheck);

            return color != DigitModel.Undefined;
        }
    }
}
