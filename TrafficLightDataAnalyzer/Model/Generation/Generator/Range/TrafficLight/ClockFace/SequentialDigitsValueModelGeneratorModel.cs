using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Exception;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Conversion;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace.Value;
using TrafficLightDataAnalyzer.Model.Navigation;
using TrafficLightDataAnalyzer.Model.Validation;

namespace TrafficLightDataAnalyzer.Model.Generation.Generator.Range.TrafficLight.ClockFace
{
    /// <summary>
    /// Sequential <see cref="DigitsValueModel">DigitsValueModel</see> range generator model class.
    /// </summary>
    internal class SequentialDigitsValueModelGeneratorModel : IRangeGenerator<DigitsValueModel>
    {
        /// <summary>
        /// <see cref="ConversionFactoryModel">ConversionFactoryModel</see> reference field.
        /// </summary>
        private static readonly ConversionFactoryModel _conversionFactory;

        /// <summary>
        /// <see cref="NavigationFactoryModel">NavigationFactoryModel</see> reference field.
        /// </summary>
        private static readonly NavigationFactoryModel _navigationFactory;

        /// <summary>
        /// <see cref="ValidationFactoryModel">ValidationFactoryModel</see> reference field.
        /// </summary>
        private static readonly ValidationFactoryModel _validationFactory;

        /// <summary>
        /// Try raise exceptions for <see cref="SequentialDigitsValueModelGeneratorModel.MakeRange(DigitsValueModel, DigitsValueModel)">MakeRange</see> method,
        /// if <paramref name="argument" /> parameter is invalid one service method.
        /// </summary>
        /// <param name="argument">Argument value.</param>
        /// <param name="argumentName">Argument name value.</param>
        /// <exception cref="ArgumentNullException">Throws, if <paramref name="argument" /> is null one.</exception>
        /// <exception cref="InvalidArgumentStateException">Throws, if <paramref name="argument" /> is invalid one.</exception>
        private void tryRaiseMakeRangeArgumentExceptions(DigitsValueModel argument, string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }

            var argumentValidator = SequentialDigitsValueModelGeneratorModel._validationFactory.CreateDigitsValueValidator();

            if (!argumentValidator.IsValid(argument))
            {
                throw new InvalidArgumentStateException(argumentName);
            }
        }

        /// <summary>
        /// Obtain generation data based on <paramref name="first" /> and <paramref name="second" /> values service method.
        /// </summary>
        /// <param name="first">First <see cref="DigitsValueModel">DigitValueModel</see> instance value. Must be valid one!</param>
        /// <param name="second">Second <see cref="DigitsValueModel">DigitValueModel</see> instance value. Must be valid one!</param>
        /// <returns>Generation-required data tuple.</returns>
        private Tuple<Func<DigitModel, DigitModel>, DigitModel> obtainGenerationData(DigitsValueModel first, DigitsValueModel second)
        {
            var converter = SequentialDigitsValueModelGeneratorModel._conversionFactory.CreateIntegerToDigitsValueModelConverter();

            var firstIntegerValue = converter.ConvertBack(first);
            var secondIntegerValue = converter.ConvertBack(second);

            var navigator = SequentialDigitsValueModelGeneratorModel._navigationFactory.CreateDigitNavigator();

            return firstIntegerValue > secondIntegerValue ?
                new Tuple<Func<DigitModel, DigitModel>, DigitModel>(navigator.Previous, DigitModel.Digit9) :
                new Tuple<Func<DigitModel, DigitModel>, DigitModel>(navigator.Next, DigitModel.Digit0);
        }

        /// <summary>
        /// Items range making method.
        /// </summary>
        /// <param name="from">Start range item value. Will be included into result range.</param>
        /// <param name="to">End range item value. Will be included into result range.</param>
        /// <returns>Result <see cref="IEnumerable{T}">enumerable</see> range reference value.</returns>
        /// <exception cref="ArgumentNullException">Throws, if <paramref name="from" /> or <paramref name="to" /> argument is null one.</exception>
        /// <exception cref="InvalidArgumentStateException">Throws, if <paramref name="from" /> or <paramref name="to" /> argument is invalid one.</exception>
        public IEnumerable<DigitsValueModel> MakeRange(DigitsValueModel from, DigitsValueModel to)
        {
            this.tryRaiseMakeRangeArgumentExceptions(from, nameof(from));
            this.tryRaiseMakeRangeArgumentExceptions(to, nameof(to));

            var currentValue = from;

            (var nextDigitTo, var higherRangeChangeBorder) = this.obtainGenerationData(from, to);

            yield return currentValue;

            while (!Enumerable.SequenceEqual(currentValue, to))
            {
                var nextLowerDigit = nextDigitTo(currentValue.LowerDigitData);
                var nextHigherDigit = nextLowerDigit == higherRangeChangeBorder ? nextDigitTo(currentValue.HigherDigitData) : currentValue.HigherDigitData;

                currentValue = (nextHigherDigit, nextLowerDigit);

                yield return currentValue;
            }
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static SequentialDigitsValueModelGeneratorModel()
        {
            SequentialDigitsValueModelGeneratorModel._conversionFactory = new ConversionFactoryModel();
            SequentialDigitsValueModelGeneratorModel._navigationFactory = new NavigationFactoryModel();
            SequentialDigitsValueModelGeneratorModel._validationFactory = new ValidationFactoryModel();
        }
    }
}
