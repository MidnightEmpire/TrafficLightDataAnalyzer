using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TrafficLightDataAnalyzer.Model.Data.ValuePresenter
{
    /// <summary>
    /// Base items values set presenter model class.<br />
    /// Yes, the final decision was NOT to use <see cref="Tuple">Tuple</see> type as basic type for this purposes: this approach seemed to be the most flexible one.
    /// </summary>
    /// <typeparam name="TItemType">Type of each containing item.</typeparam>
    internal abstract class BaseValueModel<TItemType> : BaseDataModel, IEnumerable<TItemType>
    {
        /// <summary>
        /// Values-containing array field.
        /// </summary>
        protected TItemType[] Values;

        /// <summary>
        /// Items amount computed property.
        /// </summary>
        public virtual int Amount => this.Values.Length;

        /// <summary>
        /// Indexer "property".
        /// </summary>
        /// <param name="index">Index of required item value.</param>
        /// <returns>Item founded by it's index value.</returns>
        public TItemType this[int index]
        {
            get
            {
                return this.Values[index];
            }
        }

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="items">Items reference value.</param>
        protected BaseValueModel(params TItemType[] items)
        {
            this.Values = items;
        }

        #region IEnumerable<TItemType>

        /// <summary>
        /// Returns a generic <see cref="IEnumerator{T}">IEnumerator</see> for the inner <see cref="System.Array">Array</see>.
        /// </summary>
        /// <returns>A generic <see cref="IEnumerator{T}">IEnumerator</see> for the inner <see cref="System.Array">Array</see>.</returns>
        public IEnumerator<TItemType> GetEnumerator()
        {
            return this.Values.Cast<TItemType>().GetEnumerator();
        }

        /// <summary>
        /// Returns a <see cref="IEnumerator">IEnumerator</see> for the inner <see cref="System.Array">Array</see>.
        /// </summary>
        /// <returns>A <see cref="IEnumerator">IEnumerator</see> for the inner <see cref="System.Array">Array</see>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Values.GetEnumerator();
        }

        #endregion
    }
}
