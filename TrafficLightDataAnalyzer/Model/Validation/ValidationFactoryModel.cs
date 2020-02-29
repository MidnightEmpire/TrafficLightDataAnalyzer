using System.Collections.Generic;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Observation;
using TrafficLightDataAnalyzer.Model.Validation.Validator;

namespace TrafficLightDataAnalyzer.Model.Validation
{
    /// <summary>
    /// Validation factory model class
    /// </summary>
    internal class ValidationFactoryModel
    {
        /// <summary>
        /// Traffic light color name validation model instance obtaining method
        /// </summary>
        /// <returns>New instance of traffic light color name validation model</returns>
        public IValidator<string> CreateTrafficLightColorNameValidator()
        {
            return new TrafficLightColorNameValidationModel();
        }

        /// <summary>
        /// Traffic light observation seven segment binary code string validation model instance obtaining method
        /// </summary>
        /// <returns>New instance of traffic light observation seven segment binary code string validation model</returns>
        public IValidator<string> CreateSevenSegmentBinaryCodeStringValidator()
        {
            return new SevenSegmentBinaryCodeStringValidationModel();
        }

        /// <summary>
        /// Traffic light observation seven segment binary codes strings amount validation model instance obtaining method
        /// </summary>
        /// <returns>New instance of traffic light observation seven segment binary codes strings amount validation model</returns>
        public IValidator<string[]> CreateSevenSegmentBinaryCodesStringsAmountValidator()
        {
            return new SevenSegmentBinaryCodesStringsAmountValidationModel();
        }

        /// <summary>
        /// Traffic light sealed observation sequence has red color at the end validation model instance obtaining method
        /// </summary>
        /// <returns>New instance of traffic light sealed observation sequence has red color at the end validation model</returns>
        public IValidator<List<ObservationModel>> CreateSealedObservationSequenceEndsByRedColorValidator()
        {
            return new SealedObservationSequenceEndsByRedColorValidationModel();
        }

        /// <summary>
        /// Traffic light sealed observation sequence has enough data validation model  instance obtaining method
        /// </summary>
        /// <returns>New instance of traffic light sealed observation sequence has enough data validation model </returns>
        public IValidator<List<ObservationModel>> CreateSealedObservationSequenceHasEnoughDataValidator()
        {
            return new SealedObservationSequenceHasEnoughDataValidationModel();
        }
    }
}
