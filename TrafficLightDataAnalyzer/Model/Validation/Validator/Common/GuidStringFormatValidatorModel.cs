using System;
using TrafficLightDataAnalyzer.Interface;

namespace TrafficLightDataAnalyzer.Model.Validation.Validator.Common
{
    /// <summary>
    /// <see cref="Guid">GUID</see> string format validator model class.
    /// </summary>
    internal class GuidStringFormatValidatorModel : IValidator<string>
    {
        /// <summary>
        /// Object validation method.
        /// </summary>
        /// <param name="objectForCheck">Object which one must be validated.</param>
        /// <returns>True, if object seems to be valid one. Otherwise, returns false.</returns>
        public bool IsValid(string objectForCheck)
        {
            return Guid.TryParse(objectForCheck, out var _);
        }
    }
}
