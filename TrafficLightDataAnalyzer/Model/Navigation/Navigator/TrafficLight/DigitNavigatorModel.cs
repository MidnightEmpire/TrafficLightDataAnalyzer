using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;

namespace TrafficLightDataAnalyzer.Model.Navigation.Navigator.TrafficLight
{
    /// <summary>
    /// Traffic light <see cref="DigitModel">DigitModel</see> sequential closed loop navigator model class.
    /// </summary>
    internal class DigitNavigatorModel : INavigator<DigitModel>
    {
        /// <summary>
        /// Ordered <see cref="DigitModel">DigitModel</see> array reference field.
        /// </summary>
        private readonly static DigitModel[] _orderedDigits;

        /// <summary>
        /// <see cref="DigitModel">DigitModel</see> index in the <see cref="DigitNavigatorModel._digitPositions">ordered digits</see> array dictionary reference field.
        /// </summary>
        private readonly static Dictionary<DigitModel, int> _digitPositions;

        /// <summary>
        /// Navigate to previous item method.
        /// </summary>
        /// <param name="currentItem">Current item reference value.</param>
        /// <returns>Previous item reference value.</returns>
        public DigitModel Previous(DigitModel currentItem)
        {
            return this.PreviousBefore(currentItem, 1);
        }

        /// <summary>
        /// Navigate to next item method.
        /// </summary>
        /// <param name="currentItem">Current item reference value.</param>
        /// <returns>Next item reference value.</returns>
        public DigitModel Next(DigitModel currentItem)
        {
            return this.NextAfter(currentItem, 1);
        }

        /// <summary>
        /// Arguments checking/validation service method
        /// </summary>
        /// <param name="currentItem">Current item reference value.</param>
        /// <param name="count">N-th previous/next relative position to <paramref name="currentItem" /> item value.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="currentItem" /> reference value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if <paramref name="currentItem" /> is null or undefined one, or <paramref name="count" /> is less than 1.</exception>
        private static void checkArguments(DigitModel currentItem, int count)
        {
            if (currentItem is null)
            {
                throw new ArgumentNullException(nameof(currentItem));
            }

            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (!DigitNavigatorModel._digitPositions.ContainsKey(currentItem))
            {
                throw new ArgumentOutOfRangeException(nameof(currentItem));
            }
        }

        /// <summary>
        /// Navigate to previous N-th item method.
        /// </summary>
        /// <param name="currentItem">Current item reference value.</param>
        /// <param name="count">N-th previous relative position to <paramref name="currentItem" /> item value.</param>
        /// <returns>Previous item reference value.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="currentItem" /> reference value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if <paramref name="currentItem" /> is null or undefined one, or <paramref name="count" /> is less than 1.</exception>
        public DigitModel PreviousBefore(DigitModel currentItem, int count)
        {
            DigitNavigatorModel.checkArguments(currentItem, count);

            var currentItemOrderedPosition = DigitNavigatorModel._digitPositions[currentItem];

            var orderedDigitsAmount = DigitNavigatorModel._orderedDigits.Length;

            var targetPosition = currentItemOrderedPosition - count % orderedDigitsAmount;

            if (targetPosition < 0)
            {
                targetPosition = orderedDigitsAmount + targetPosition;
            }

            return DigitNavigatorModel._orderedDigits[targetPosition];
        }

        /// <summary>
        /// Navigate to next N-th item method.
        /// </summary>
        /// <param name="currentItem">Current item reference value.</param>
        /// <param name="count">N-th next relative position to <paramref name="currentItem" /> item value.</param>
        /// <returns>Next item reference value.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="currentItem" /> reference value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if <paramref name="currentItem" /> is null or undefined one, or <paramref name="count" /> is less than 1.</exception>
        public DigitModel NextAfter(DigitModel currentItem, int count)
        {
            DigitNavigatorModel.checkArguments(currentItem, count);

            var currentItemOrderedPosition = DigitNavigatorModel._digitPositions[currentItem];

            var orderedDigitsAmount = DigitNavigatorModel._orderedDigits.Length;

            var targetPosition = currentItemOrderedPosition + count % orderedDigitsAmount;

            if (targetPosition > orderedDigitsAmount - 1)
            {
                targetPosition = targetPosition - orderedDigitsAmount;
            }

            return DigitNavigatorModel._orderedDigits[targetPosition];
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static DigitNavigatorModel()
        {
            var orderedDigits = DigitModel
                .AllDigits
                .OrderBy((digit) => digit.Value)
                .ToArray();

            DigitNavigatorModel._orderedDigits = orderedDigits;

            DigitNavigatorModel._digitPositions = orderedDigits
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
