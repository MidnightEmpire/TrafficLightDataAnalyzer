using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Observation;

namespace TrafficLightDataAnalyzer.Model.Validation.Validator
{
    /// <summary>
    /// Traffic light sealed observation sequence has red color at the end validation model class
    /// </summary>
    internal class SealedObservationSequenceEndsByRedColorValidationModel : IValidator<List<ObservationModel>>
    {
        /// <summary>
        /// Object validation method
        /// </summary>
        /// <param name="objectForCheck">Object which one will be validated</param>
        /// <returns>True, if object seems to be valid one. Otherwise, return false</returns>
        public bool IsValid(List<ObservationModel> objectForCheck)
        {
            if (objectForCheck == null ||
                !objectForCheck.Any()
            ) {
                return false;
            }

            var firstObservation = objectForCheck.Last();

            return firstObservation.Color == TrafficLightColorModel.Red;
        }
    }
}
