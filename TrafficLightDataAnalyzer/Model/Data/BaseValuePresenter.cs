using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Model.Data;

namespace TrafficLightDataAnalyzer.Model.Data
{
    /// <summary>
    /// Base value presenting class
    /// Yes, it's simple array wrapper, but...
    /// </summary>
    /// <typeparam name="TItemType">Contained items type</typeparam>
    internal abstract class BaseValuePresenter<TItemType> : BaseDataModel, IEnumerable<TItemType>
    {
        /// <summary>
        /// Values-containing array property
        /// </summary>
        protected TItemType[] Values;

        /// <summary>
        /// Items amount computional property
        /// </summary>
        public int Amount => this.Values.Length;

        /// <summary>
        /// Indexer "property"
        /// </summary>
        /// <param name="index">Index of required item value</param>
        /// <returns>Item founded by it's index value</returns>
        public TItemType this[int index]
        {
            get
            {
                return this.Values[index];
            }
        }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="items">Items reference value</param>
        protected BaseValuePresenter(params TItemType[] items)
        {
            this.Values = items;
        }

        #region IEnumerable<TItemType>

        /// <summary>
        /// Returns a generic System.Collections.IEnumerator for the inner System.Array
        /// </summary>
        /// <returns>A generic System.Collections.IEnumerator for the inner System.Array</returns>
        public IEnumerator<TItemType> GetEnumerator()
        {
            return this.Values.Cast<TItemType>().GetEnumerator();
        }

        /// <summary>
        /// Returns an System.Collections.IEnumerator for the inner System.Array
        /// </summary>
        /// <returns>An System.Collections.IEnumerator for the inner System.Array</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Values.GetEnumerator();
        }

        #endregion
    }
}
