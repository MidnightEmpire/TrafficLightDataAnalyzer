using System;
using TestApp.Extension;
using TestApp.Model.Common.EnumerableSet;
using TestApp.Model.Observation;

namespace TestApp
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
