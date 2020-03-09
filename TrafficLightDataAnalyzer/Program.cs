using System;
using TrafficLightDataAnalyzer.Extension;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;
using TrafficLightDataAnalyzer.Model.Generation;
using TrafficLightDataAnalyzer.Model.Navigation;
using TrafficLightDataAnalyzer.Model.Observation.State.TrafficLight;

namespace TrafficLightDataAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DigitModel.Undefined);

            DigitModel.AllDigits.ForEach((digit) =>
            {
                Console.WriteLine(digit);
            });

            Console.WriteLine(ColorModel.Undefined);

            ColorModel.AllColors.ForEach((color) =>
            {
                Console.WriteLine(color);
            });

            var navigationFactory = new NavigationFactoryModel();

            var navigator = navigationFactory.CreateDigitNavigator();

            var nextDigit = DigitModel.Digit1;

            for (int i = 15; --i > 0; )
            {
                Console.WriteLine(nextDigit);

                nextDigit = navigator.PreviousBefore(nextDigit, 1);
            }

            BinaryCodesValueModel binaryCodes = (0b0001_0010, 0b0001_0011);

            DigitsValueModel clockValues1 = (DigitModel.Digit1, DigitModel.Digit3);
            DigitsValueModel clockValues2 = 99;

            Console.WriteLine(clockValues1);
            Console.WriteLine(clockValues2);
            Console.WriteLine(binaryCodes);

            var generationFactory = new GenerationFactoryModel();
            var generator = generationFactory.CreateSequentialDigitsValueModelGenerator();

            var range1 = generator.MakeRange(33, 11);
            var range2 = generator.MakeRange(33, 99);
            var range3 = generator.MakeRange(0, 0);

            range1.ForEach((item) =>
            {
                Console.WriteLine(item);
            });

            range2.ForEach((item) =>
            {
                Console.WriteLine(item);
            });

            range3.ForEach((item) =>
            {
                Console.WriteLine(item);
            });

            var observationModel = new ObservedObjectStateModel(ColorModel.Red.Name, ("0001111", "1111010"));

            Console.WriteLine(observationModel);
        }
    }
}
