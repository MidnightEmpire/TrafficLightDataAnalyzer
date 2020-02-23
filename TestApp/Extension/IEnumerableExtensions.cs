using System;
using System.Collections.Generic;

namespace TestApp.Extension
{
    /// <summary>
    /// IEnumerable extensions class
    /// </summary>
    internal static class IEnumerableExtensions
    {
        /// <summary>
        /// ForEach extension for IEnumerable collection method
        /// </summary>
        /// <typeparam name="TItemType">IEnumerable collection item type</typeparam>
        /// <param name="sourceCollection">Source IEnumerable collection reference value</param>
        /// <param name="action">Action, which one must be applied to each IEnumerable collection item value </param>
        public static void ForEach<TItemType>(this IEnumerable<TItemType> sourceCollection, Action<TItemType> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (var item in sourceCollection)
            {
                action.Invoke(item);
            }
        }

        /// <summary>
        /// ForEach extension for IEnumerable collection method
        /// </summary>
        /// <typeparam name="TItemType">IEnumerable collection item type</typeparam>
        /// <param name="sourceCollection">Source IEnumerable collection reference value</param>
        /// <param name="action">Action, which one must be applied to each IEnumerable collection item value </param>
        public static void ForEach<TItemType>(this IEnumerable<TItemType> sourceCollection, Action<int, TItemType> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var itemPosition = 0;

            foreach (var item in sourceCollection)
            {
                action.Invoke(itemPosition, item);

                ++itemPosition;
            }
        }
    }
}
