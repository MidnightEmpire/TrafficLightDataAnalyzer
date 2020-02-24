using System;
using TestApp.Interface;
using TestApp.Model.Common.EnumerableSet;

namespace TestApp.Model.Validation.Validator
{
    /// <summary>
    /// Traffic light color name validation model class
    /// </summary>
    internal class TrafficLightColorNameValidationModel : IValidator<string>
    {
        /// <summary>
        /// Object validation method
        /// </summary>
        /// <param name="objectForCheck">Object which one will be validated</param>
        /// <returns>True, if object seems to be valid one. Otherwise, return false</returns>
        public bool IsValid(string objectForCheck)
        {
            var trafficLightColor = TrafficLightColorModel.FindByName(objectForCheck, StringComparison.OrdinalIgnoreCase);

            return trafficLightColor != TrafficLightColorModel.Undefined;
        }
    }
}
