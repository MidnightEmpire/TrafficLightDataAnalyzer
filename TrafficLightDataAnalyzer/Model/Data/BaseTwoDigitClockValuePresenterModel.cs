namespace TrafficLightDataAnalyzer.Model.Data
{
    /// <summary>
    /// Base two digit clock value presenter model class
    /// </summary>
    /// <typeparam name="TItemType">Contained items type</typeparam>
    internal abstract class BaseTwoDigitClockValuePresenterModel<TItemType> : BaseValuePresenter<TItemType>
    {
        /// <summary>
        /// Higher digit data computional property
        /// </summary>
        public TItemType HigherDigitData => this.Values[0];

        /// <summary>
        /// Lower digit data property
        /// </summary>
        public TItemType LowerDigitData => this.Values[1];

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="higherDigitData">Higher digit data reference value</param>
        /// <param name="lowerDigitData">Lower digit data reference value</param>
        protected BaseTwoDigitClockValuePresenterModel(TItemType higherDigitData, TItemType lowerDigitData)
            : base(higherDigitData, lowerDigitData)
        {
        }
    }
}