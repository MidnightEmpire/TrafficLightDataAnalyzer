using System;
using TrafficLightDataAnalyzer.Extension;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Observation;

namespace TrafficLightDataAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
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
