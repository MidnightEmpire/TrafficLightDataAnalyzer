using System;
using TrafficLightDataAnalyzer.Interface;

namespace TrafficLightDataAnalyzer.Model.Validation.Validator
{
    /// <summary>
    /// GUID format validation model class
    /// </summary>
    internal class GuidFormatValidationModel : IValidator<string>
    {
        /// <summary>
        /// Object validation method
        /// </summary>
        /// <param name="objectForCheck">Object which one will be validated</param>
        /// <returns>True, if object seems to be valid one. Otherwise, return false</returns>
        public bool IsValid(string objectForCheck)
        {
            return Guid.TryParse(objectForCheck, out var uselessOutput);
        }
    }
}
