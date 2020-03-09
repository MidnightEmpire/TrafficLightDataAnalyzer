using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Common;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Observation.State.TrafficLight;
using TrafficLightDataAnalyzer.Model.Validation;

namespace TrafficLightDataAnalyzer.Model.Observation.TrafficLight
{
    /// <summary>
    /// Traffic light observation model class.
    /// </summary>
    internal class ObservationModel : BaseObservationModel<ObservedObjectStateModel>
    {
        /// <summary>
        /// <see cref="ValidationFactoryModel">ValidationFactoryModel</see> reference field.
        /// </summary>
        private static readonly ValidationFactoryModel _validationFactory;

        /// <summary>
        /// <see cref="ObservationModel">ObservationModel</see> is sealed by once-obtained <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see>
        /// with <see cref="ColorModel.Red">red</see> traffic light color property.
        /// </summary>
        public bool IsSealed { get; private set; }

        /// <summary>
        /// Try raise <see cref="BaseObservationModel.RegisteredStates">RegisteredStates</see> exceptions service method.
        /// </summary>
        /// <param name="isSealed"><see cref="ObservationModel">ObservationModel</see> is sealed one state value.</param>
        /// <param name="registeredStates"><see cref="IList{T}">IList</see> of all <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see> values.</param>
        /// <exception cref="WrongObservationDataException">Throws, if <paramref name="registeredStates" /> state seems to be invalid one.</exception>
        private void tryRaiseRegisteredStatesExceptions(bool isSealed, IList<ObservedObjectStateModel> registeredStates)
        {
            if (isSealed)
            {
                var validator = ObservationModel._validationFactory.CreateSealedObservationStatesLastStateValidator();

                if (!validator.IsValid(registeredStates))
                {
                    throw new WrongObservationDataException(StringsKeeper.ExceptionMessage.ObservationIsAlreadySealed);
                }

                validator = ObservationModel._validationFactory.CreateSealedObservationStatesFirstStateValidator();

                if (!validator.IsValid(registeredStates))
                {
                    throw new WrongObservationDataException(StringsKeeper.ExceptionMessage.ObservationIsEmpty);
                }
            }
        }

        /// <summary>
        /// New observed object state registering/attaching method.
        /// </summary>
        /// <param name="newState">Observed object state value to register.</param>
        public override void RegisterNewState(ObservedObjectStateModel newState)
        {
            if (this.IsSealed)
            {
                throw new WrongObservationDataException(StringsKeeper.ExceptionMessage.ObservationIsAlreadySealed);
            }

            base.RegisterNewState(newState);

            this.IsSealed = newState.Color == ColorModel.Red;

            this.tryRaiseRegisteredStatesExceptions(this.IsSealed, this.RegisteredStates);
        }

        /// <summary>
        /// Main constructor: additional <see cref="ObservationModel.IsSealed">IsSealed</see> analysis will be made.
        /// </summary>
        /// <param name="registeredStates"><see cref="List{T}">List</see> of all <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see> values.</param>
        public ObservationModel(List<ObservedObjectStateModel> registeredStates)
        {
            var isSealed = registeredStates?.Any((state) => state.Color == ColorModel.Red) ?? false;

            this.tryRaiseRegisteredStatesExceptions(isSealed, registeredStates);

            this.Init(registeredStates);

            this.IsSealed = isSealed;
        }

        /// <summary>
        /// Additional constructor: additional <see cref="ObservationModel.IsSealed">IsSealed</see> analysis and array conversion to list will be performed.
        /// </summary>
        /// <param name="registeredStates">Parametric <see cref="Array">array</see> of all <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see> values.</param>
        public ObservationModel(params ObservedObjectStateModel[] registeredStates)
            : this(registeredStates?.ToList())
        {
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static ObservationModel()
        {
            ObservationModel._validationFactory = new ValidationFactoryModel();
        }
    }
}
