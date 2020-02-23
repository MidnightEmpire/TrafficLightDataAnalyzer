using System;
using TestApp.Model.Common.EnumerableSet;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var allDigits = SevenSegmentDigitModel.AllDigits;

            foreach (var digit in allDigits)
            {
                Console.WriteLine(digit);
            }
        }
    }
}
