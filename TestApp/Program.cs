using System;
using TestApp.Extension;
using TestApp.Model.Common.EnumerableSet;

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
        }
    }
}
