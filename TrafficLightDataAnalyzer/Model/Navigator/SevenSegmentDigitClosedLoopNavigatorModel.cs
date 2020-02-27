using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;

namespace TrafficLightDataAnalyzer.Model.Navigator
{
    /// <summary>
    /// Seven segment digit closed loop navigator model
    /// </summary>
    internal class SevenSegmentDigitClosedLoopNavigatorModel : IAssociativeNavigator<SevenSegmentDigitModel>
    {
        /// <summary>
        /// Ordered digits array reference field
        /// </summary>
        private readonly static SevenSegmentDigitModel[] _orderedDigits;

        /// <summary>
        /// Digits array index position dictionary reference field
        /// </summary>
        private readonly static Dictionary<SevenSegmentDigitModel, int> _digitPositions;

        /// <summary>
        /// Navigate to previous item method
        /// </summary>
        /// <param name="currentItem">Current item reference value</param>
        /// <returns>Previous item reference value</returns>
        public SevenSegmentDigitModel Previous(SevenSegmentDigitModel currentItem)
        {
            return this.PreviousBefore(currentItem, 1);
        }

        /// <summary>
        /// Navigate to next item method
        /// </summary>
        /// <param name="currentItem">Current item reference value</param>
        /// <returns>Next item reference value</returns>
        public SevenSegmentDigitModel Next(SevenSegmentDigitModel currentItem)
        {
            return this.NextAfter(currentItem, 1);
        }

        /// <summary>
        /// Navigate to previous N-th item method
        /// </summary>
        /// <param name="currentItem">Current item reference value</param>
        /// <param name="count">N-th relative position of previous item value</param>
        /// <returns>Previous item reference value</returns>
        public SevenSegmentDigitModel PreviousBefore(SevenSegmentDigitModel currentItem, int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (currentItem == null ||
                !SevenSegmentDigitClosedLoopNavigatorModel._digitPositions.ContainsKey(currentItem)
            ) {
                throw new ArgumentOutOfRangeException(nameof(currentItem));
            }

            var currentItemOrderedPosition = SevenSegmentDigitClosedLoopNavigatorModel._digitPositions[currentItem];

            var orderedDigitsAmount = SevenSegmentDigitClosedLoopNavigatorModel._orderedDigits.Length;

            var targetPosition = currentItemOrderedPosition - (count % orderedDigitsAmount);

            if (targetPosition < 0)
            {
                targetPosition = orderedDigitsAmount + targetPosition;
            }

            return SevenSegmentDigitClosedLoopNavigatorModel._orderedDigits[targetPosition];
        }

        /// <summary>
        /// Navigate to next N-th item method
        /// </summary>
        /// <param name="currentItem">Current item reference value</param>
        /// <param name="count">N-th relative position of next item value</param>
        /// <returns>Next item reference value</returns>
        public SevenSegmentDigitModel NextAfter(SevenSegmentDigitModel currentItem, int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (currentItem == null || 
                !SevenSegmentDigitClosedLoopNavigatorModel._digitPositions.ContainsKey(currentItem)
            ) {
                throw new ArgumentOutOfRangeException(nameof(currentItem));
            }

            var currentItemOrderedPosition = SevenSegmentDigitClosedLoopNavigatorModel._digitPositions[currentItem];

            var orderedDigitsAmount = SevenSegmentDigitClosedLoopNavigatorModel._orderedDigits.Length;

            var targetPosition = currentItemOrderedPosition + (count % orderedDigitsAmount);

            if (targetPosition > orderedDigitsAmount - 1)
            {
                targetPosition = targetPosition - orderedDigitsAmount;
            }

            return SevenSegmentDigitClosedLoopNavigatorModel._orderedDigits[targetPosition];
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static SevenSegmentDigitClosedLoopNavigatorModel()
        {
            var orderedDigits = SevenSegmentDigitModel
                .AllDigits
                .OrderBy((digit) => digit.Value)
                .ToArray();

            SevenSegmentDigitClosedLoopNavigatorModel._orderedDigits = orderedDigits;
            SevenSegmentDigitClosedLoopNavigatorModel._digitPositions = orderedDigits
                .Select((digit, index) =>
                    new
                    {
                        Digit = digit,
                        Index = index
                    }
                )
                .ToDictionary(
                    (item) => item.Digit,
                    (item) => item.Index
                );
        }
    }
}
