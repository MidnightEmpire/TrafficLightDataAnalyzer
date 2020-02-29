using System.Collections.Generic;
using TrafficLightDataAnalyzer.Common;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Model.Observation;
using TrafficLightDataAnalyzer.Model.Validation;

namespace TrafficLightDataAnalyzer.Model.ObservationSequence.Validator
{
    /// <summary>
    /// Traffic light observation sequence methods arguments validator model class
    /// </summary>
    internal class ObservationSequenceValidatorModel
    {
        /// <summary>
        /// Validation factory reference field
        /// </summary>
        private readonly ValidationFactoryModel _validationFactory;

        /// <summary>
        /// Traffic light sealed observation sequence GUID validation method
        /// </summary>
        /// <param name="sequenceGuid">Sequence GUID string reference value</param>
        public void ValidateObservationSequenceGuid(string sequenceGuid)
        {
            var guidFormatValidator = this._validationFactory.CreateGuidFormatValidator();

            if (!guidFormatValidator.IsValid(sequenceGuid))
            {
                throw new WrongObservationDataException(StringsKeeper.ExceptionMessage.InvalidGuidFormat);
            }
        }

        /// <summary>
        /// Traffic light sealed observation sequence adding new observation ability validation method
        /// </summary>
        /// <param name="isSealed">Observation sequence is sealed by traffic light red color observation flag value</param>
        public void ValidateObservationSequenceAddingObservationAbility(bool isSealed)
        {
            if (isSealed)
            {
                throw new WrongObservationDataException(StringsKeeper.ExceptionMessage.ObservationIsAlreadySealed);
            }
        }

        /// <summary>
        /// Traffic light sealed observation sequence validation method
        /// </summary>
        /// <param name="isSealed">Observation sequence is sealed by traffic light red color observation flag value</param>
        /// <param name="observations">Sequence of observations collection reference value</param>
        public void ValidateObservationSequence(bool isSealed, List<ObservationModel> observations)
        {
            if (isSealed)
            {
                var observationSequenceEndsByRedColorValidator = this._validationFactory.CreateSealedObservationSequenceEndsByRedColorValidator();

                if (!observationSequenceEndsByRedColorValidator.IsValid(observations))
                {
                    throw new WrongObservationDataException(StringsKeeper.ExceptionMessage.ObservationIsAlreadySealed);
                }

                var observationSequenceHasEnoughDataValidator = this._validationFactory.CreateSealedObservationSequenceHasEnoughDataValidator();

                if (!observationSequenceHasEnoughDataValidator.IsValid(observations))
                {
                    throw new WrongObservationDataException(StringsKeeper.ExceptionMessage.EmptyObservationsSequence);
                }
            }
        }

        /// <summary>
        /// Main constructor
        /// </summary>
        public ObservationSequenceValidatorModel()
        {
            this._validationFactory = new ValidationFactoryModel();
        }
    }
}
