namespace TrafficLightDataAnalyzer.Model.Data.ValuePresenter
{
    /// <summary>
    /// Base two item value presenter model class.
    /// </summary>
    /// <typeparam name="TItemType">Type of each containing item.</typeparam>
    internal abstract class BaseTwoItemValueModel<TItemType> : BaseValueModel<TItemType>
    {
        /// <summary>
        /// Items amount constant.
        /// </summary>
        private const int ItemsAmount = 2;

        /// <summary>
        /// Items amount computed property.
        /// </summary>
        public override int Amount => BaseTwoItemValueModel<TItemType>.ItemsAmount;

        /// <summary>
        /// Deconstruction of the parent <see cref="BaseValueModel{TItemType}">BaseValueNodel</see> type values method.
        /// </summary>
        /// <param name="firstValue">First item value.</param>
        /// <param name="secondValue">Second item reference value.</param>
        public void Deconstruct(out TItemType firstValue, out TItemType secondValue)
        {
            firstValue = this.Values[0];
            secondValue = this.Values[1];
        }

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="firstValue">First item value.</param>
        /// <param name="secondValue">Second item reference value.</param>
        protected BaseTwoItemValueModel(TItemType firstValue, TItemType secondValue)
            : base(firstValue, secondValue)
        {
        }
    }
}