using System.Collections.Generic;
using System.Collections.ObjectModel;
using TrafficLightDataAnalyzer.Model.Observation.State;

namespace TrafficLightDataAnalyzer.Model.Observation
{
    /// <summary>
    /// Base observation model class.
    /// </summary>
    /// <typeparam name="TObservableObjectState">Observed object state type.</typeparam>
    internal class BaseObservationModel<TObservedObjectState> where TObservedObjectState : BaseObservedObjectStateModel
    {
        /// <summary>
        /// <see cref="List{T}">List</see> of all observed object registered states field.
        /// </summary>
        private List<TObservedObjectState> _registeredStates;

        /// <summary>
        /// <see cref="ReadOnlyCollection{T}">ReadOnlyCollection</see> of all observed object registered states computed property.
        /// </summary>
        public ReadOnlyCollection<TObservedObjectState> RegisteredStates => this._registeredStates.AsReadOnly();

        /// <summary>
        /// New observed object state registering/attaching method.
        /// </summary>
        /// <param name="newState">Observed object state value to register.</param>
        public virtual void RegisterNewState(TObservedObjectState newState)
        {
            this._registeredStates.Add(newState);
        }

        /// <summary>
        /// <see cref="BaseObservationModel{TObservedObjectState}">BaseObservationModel</see> initialization method.<br />
        /// MUST be called in constructors of child classes.
        /// </summary>
        /// <param name="registeredStates"><see cref="List{T}">List</see> of all observed object registered states value.</param>
        protected virtual void Init(List<TObservedObjectState> registeredStates)
        {
            this._registeredStates = registeredStates ?? new List<TObservedObjectState>();
        }

        /// <summary>
        /// Main constructor.
        /// </summary>
        protected BaseObservationModel()
        {
        }
    }
}
