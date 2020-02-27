using System;
using System.Collections.Generic;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.ClockFace.ValuePresenter;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Navigator;

namespace TrafficLightDataAnalyzer.Model.RangeGenerator
{
    /// <summary>
    /// Sequential countdown digit range generator model class
    /// </summary>
    internal class SequentialCountdownDigitRangeGeneratorModel : IRangeGenerator<TwoDigitClockFaceValueModel>
    {
        /// <summary>
        /// Items range making method
        /// </summary>
        /// <param name="from">Start range value. Will be included into result range</param>
        /// <param name="to">End range value. Will be included into result range</param>
        /// <returns>Required range collection reference value</returns>
        public IEnumerable<TwoDigitClockFaceValueModel> MakeRange(TwoDigitClockFaceValueModel from, TwoDigitClockFaceValueModel to)
        {
            if (from == null || to == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            var firstArgumentIsBigger =
                from.HigherDigitData.Value > to.HigherDigitData.Value || (
                    from.HigherDigitData.Value == to.HigherDigitData.Value &&
                    from.LowerDigitData.Value > to.HigherDigitData.Value
                );

            var currentValue = firstArgumentIsBigger ? from : to;
            var targetValue = firstArgumentIsBigger ? to : from;

            var digitNavigator = new SevenSegmentDigitClosedLoopNavigatorModel();

            yield return currentValue;

            while (currentValue.HigherDigitData != targetValue.HigherDigitData ||
                  currentValue.LowerDigitData != targetValue.LowerDigitData
            ) {
                var nextLowerDigit = digitNavigator.Previous(currentValue.LowerDigitData);
                var nextHigherDigit = nextLowerDigit == SevenSegmentDigitModel.Digit9 ? digitNavigator.Previous(currentValue.HigherDigitData) : currentValue.HigherDigitData;

                currentValue = new TwoDigitClockFaceValueModel(nextHigherDigit, nextLowerDigit);

                yield return currentValue;
            }
        }
    }
}
