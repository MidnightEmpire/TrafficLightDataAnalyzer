using System;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;

namespace TrafficLightDataAnalyzer.Model.Validation.Validator.TrafficLight
{
    /// <summary>
    /// Traffic light color name validator model class.
    /// </summary>
    internal class ColorNameValidatorModel : IValidator<string>
    {
        /// <summary>
        /// Object validation method.
        /// </summary>
        /// <param name="objectForCheck">Object which one must be validated.</param>
        /// <returns>True, if object seems to be valid one. Otherwise, returns false.</returns>
        public bool IsValid(string objectForCheck)
        {
            var color = ColorModel.FindByName(objectForCheck, StringComparison.OrdinalIgnoreCase);

            return color != ColorModel.Undefined;
        }
    }
}
