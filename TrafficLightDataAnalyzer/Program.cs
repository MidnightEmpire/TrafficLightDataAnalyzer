using System;
using TrafficLightDataAnalyzer.Extension;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Generation;
using TrafficLightDataAnalyzer.Model.Observation;
using TrafficLightDataAnalyzer.Model.Transformation;

namespace TrafficLightDataAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var generationFactory = new GenerationFactoryModel();
            var transformationFactory = new TransformationFactoryModel();

            var generator = generationFactory.CreateSequentialCountdownDigitRangeGenerator();

            var rangeBroker = transformationFactory.CreateTwoDigitClockFaceBrokeUpTransformer(
                new TwoDigitClockFaceObservationBinaryCodeValueModel(0b0111_1111, 0b0111_1111)
            );

            var range = rangeBroker.Transform(
                generator.MakeRange(
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit9, SevenSegmentDigitModel.Digit5),
                    new TwoDigitClockFaceValueModel(SevenSegmentDigitModel.Digit0, SevenSegmentDigitModel.Digit5)
                )
            );

            range.ForEach((rangeItem) =>
            {
                Console.WriteLine("=>" + rangeItem);
            });

            SevenSegmentDigitModel.AllDigits.ForEach((digit) =>
            {
                Console.WriteLine(digit);
            });

            TrafficLightColorModel.AllColors.ForEach((color) =>
            {
                Console.WriteLine(color);
            });

            var observation = new ObservationModel("green", "0000000", "0001111");

            Console.WriteLine(observation);
        }
    }
}
