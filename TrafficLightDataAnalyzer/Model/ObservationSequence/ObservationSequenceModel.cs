using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Observation;
using TrafficLightDataAnalyzer.Model.ObservationSequence.Validator;

namespace TrafficLightDataAnalyzer.Model.ObservationSequence
{
    /// <summary>
    /// Observation sequence model class
    /// Yes, it has validator in constructor and method. SRP principle may be broken a bit, but...
    /// </summary>
    internal class ObservationSequenceModel
    {
        /// <summary>
        /// Corresponding observation sequence validator model reference field
        /// </summary>
        private static readonly ObservationSequenceValidatorModel _observationSequenceValidator;

        /// <summary>
        /// Collection of all attached observations field
        /// </summary>
        public List<ObservationModel> _observations;

        /// <summary>
        /// Unique observation sequence GUID value property
        /// </summary>
        public string Guid { get; }

        /// <summary>
        /// Observation sequence is sealed by traffic light red color observation flag property
        /// </summary>
        public bool IsSealed{ get; private set; }

        /// <summary>
        /// Read-only collection of all attached observations computional property
        /// </summary>
        public ReadOnlyCollection<ObservationModel> Observations => this._observations.AsReadOnly();

        /// <summary>
        /// New observation registering/attaching method
        /// </summary>
        /// <param name="newObservation">New observation reference value</param>
        public void RegisterNewObservation(ObservationModel newObservation)
        {
            ObservationSequenceModel._observationSequenceValidator.ValidateObservationSequenceAddingObservationAbility(this.IsSealed);

            this._observations.Add(newObservation);

            this.IsSealed = newObservation.Color == TrafficLightColorModel.Red;

            ObservationSequenceModel._observationSequenceValidator.ValidateObservationSequence(this.IsSealed, this._observations);
        }

        /// <summary>
        /// Main constructor: only accept external data - no any additional analysis will be made
        /// </summary>
        /// <param name="guid">Unique observation sequence GUID reference value</param>
        /// <param name="isSealed">Observation sequence is sealed by traffic light red color observation flag value</param>
        /// <param name="observations">Sequence of observations collection reference value</param>
        public ObservationSequenceModel(string guid, bool isSealed, List<ObservationModel> observations)
        {
            this.Guid = guid;
            this.IsSealed = isSealed;

            this._observations = observations ?? new List<ObservationModel>();

            ObservationSequenceModel._observationSequenceValidator.ValidateObservationSequenceGuid(this.Guid);
            ObservationSequenceModel._observationSequenceValidator.ValidateObservationSequence(this.IsSealed, this._observations);
        }

        /// <summary>
        /// Additional constructor: observation red color search and conversion to list will be performed
        /// </summary>
        /// <param name="guid">Unique observation sequence GUID reference value</param>
        /// <param name="observations">Sequence of observations collection reference value</param>
        public ObservationSequenceModel(string guid, params ObservationModel[] observations)
            : this(
                  guid,
                  observations.Any((observation) => observation.Color == TrafficLightColorModel.Red),
                  observations?.ToList()
              )
        {
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static ObservationSequenceModel()
        {
            ObservationSequenceModel._observationSequenceValidator = new ObservationSequenceValidatorModel();
        }
    }
}
