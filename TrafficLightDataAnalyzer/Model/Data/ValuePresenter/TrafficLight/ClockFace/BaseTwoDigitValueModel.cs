using TrafficLightDataAnalyzer.Interface;

namespace TrafficLightDataAnalyzer.Model.Data.ValuePresenter.TrafficLight.ClockFace
{
    /// <summary>
    /// Base two digit value presenter model class.
    /// </summary>
    /// <typeparam name="TItemType">Type of each containing digit item.</typeparam>
    internal abstract class BaseTwoDigitValueModel<TItemType> : BaseTwoItemValueModel<TItemType>
    {
        /// <summary>
        /// Higher digit data alias computed property.
        /// </summary>
        public TItemType HigherDigitData => this[0];

        /// <summary>
        /// Lower digit data alias computed property.
        /// </summary>
        public TItemType LowerDigitData => this[1];

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="higherDigitData">Higher digit data value.</param>
        /// <param name="lowerDigitData">Lower digit data value.</param>
        protected BaseTwoDigitValueModel(TItemType higherDigitData, TItemType lowerDigitData)
            : base(higherDigitData, lowerDigitData)
        {
        }
    }
}