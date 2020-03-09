using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Observation;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Observation.State.TrafficLight;
using TrafficLightDataAnalyzer.Model.Observation.TrafficLight;

namespace TrafficLightDataAnalyzer.Model.Validation.Validator.TrafficLight
{
    /// <summary>
    /// Traffic light sealed <see cref="ObservationModel">ObservationModel</see>
    /// <see cref="BaseObservationModel{TObservedObjectState}.RegisteredStates">registered states</see> last state validation model class.
    /// </summary>
    internal class SealedObservationStatesLastStateValidatorModel : IValidator<IList<ObservedObjectStateModel>>
    {
        /// <summary>
        /// Object validation method.
        /// </summary>
        /// <param name="objectForCheck">Object which one must be validated.</param>
        /// <returns>True, if object seems to be valid one. Otherwise, returns false.</returns>
        public bool IsValid(IList<ObservedObjectStateModel> objectForCheck)
        {
            if (objectForCheck == null ||
                !objectForCheck.Any()
            ) {
                return false;
            }

            var lastRegisteredState = objectForCheck.Last();

            return lastRegisteredState.Color == ColorModel.Red;
        }
    }
}
