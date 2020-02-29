using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Generation;
using TrafficLightDataAnalyzer.Model.Observation;
using TrafficLightDataAnalyzer.Model.Transformation;

namespace TrafficLightDataAnalyzer.Test.Environment
{
    /// <summary>
    /// Observation sequence generator class
    /// </summary>
    internal class ObservationSequenceGenerator
    {
        /// <summary>
        /// Ovservation list reference field
        /// </summary>
        private List<ObservationModel> _observations;

        /// <summary>
        /// Observation model creator reference field
        /// </summary>
        private ObservationModelCreator _observationCreator;

        /// <summary>
        /// Range generator reference field
        /// </summary>
        private IRangeGenerator<TwoDigitClockFaceValueModel> _rangeGenerator;

        /// <summary>
        /// Observations read-only collection property
        /// </summary>
        public ReadOnlyCollection<ObservationModel> Observations => this._observations.AsReadOnly();

        /// <summary>
        /// Observation adding method: all digit codes will be 0b0000_0000
        /// </summary>
        /// <param name="color">Range color reference value</param>
        public void AddObservation(TrafficLightColorModel color)
        {
            this.AddObservation(
                color,
                new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0000_0000, 0b0000_0000)
            );
        }

        /// <summary>
        /// Observation adding method
        /// </summary>
        /// <param name="color">Range color reference value</param>
        /// <param name="binaryCodes">Observation binary codes reference value</param>
        public void AddObservation(TrafficLightColorModel color, TwoDigitClockFaceObservationBinaryCodeValueModel binaryCodes)
        {
            var observationToAdd = this._observationCreator.CreateObservationModel(color, binaryCodes);

            this._observations.Add(observationToAdd);
        }

        /// <summary>
        /// Observation list range adding method
        /// </summary>
        /// <param name="color">Range color reference value</param>
        /// <param name="from">Start range value. Will be included into result range</param>
        /// <param name="to">End range value. Will be included into result range</param>
        public void AddSequentialObservationRange(
            TrafficLightColorModel color,
            TwoDigitClockFaceValueModel from,
            TwoDigitClockFaceValueModel to
        ) {
            var transformationFactory = new TransformationFactoryModel();

            var transformation = transformationFactory.CreateTwoDigitClockFaceIdentityConvertorTransformer();

            this.AddSequentialObservationRange(
                color,
                from,
                to,
                transformation
            );
        }

        /// <summary>
        /// Observation list range adding method
        /// </summary>
        /// <param name="color">Range color reference value</param>
        /// <param name="from">Start range value. Will be included into result range</param>
        /// <param name="to">End range value. Will be included into result range</param>
        /// <param name="rangeTransformer">Range transformer reference field</param>
        public void AddSequentialObservationRange(
            TrafficLightColorModel color,
            TwoDigitClockFaceValueModel from,
            TwoDigitClockFaceValueModel to,
            IRangeTransformer<TwoDigitClockFaceValueModel, TwoDigitClockFaceObservationBinaryCodeValueModel> rangeTransformer
        ) {
            var digitRangeToAdd = this._rangeGenerator.MakeRange(from, to);

            var transformedDigitRange = rangeTransformer.Transform(digitRangeToAdd);

            var observationsToAdd = transformedDigitRange.Select(
                (transformedDigit) => this._observationCreator.CreateObservationModel(color, transformedDigit)
            );

            this._observations.AddRange(observationsToAdd);
        }

        /// <summary>
        /// Main constructor
        /// </summary>
        public ObservationSequenceGenerator()
        {
            this._observations = new List<ObservationModel>();

            this._observationCreator = new ObservationModelCreator();

            var generationFactory = new GenerationFactoryModel();

            this._rangeGenerator = generationFactory.CreateSequentialCountdownDigitRangeGenerator();
        }
    }
}
