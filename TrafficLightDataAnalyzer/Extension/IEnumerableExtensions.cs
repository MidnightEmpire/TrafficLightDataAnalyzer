using System;
using System.Collections.Generic;

namespace TrafficLightDataAnalyzer.Extension
{
    /// <summary>
    /// <see cref="IEnumerable{T}">IEnumerable</see> extensions class.
    /// </summary>
    internal static class IEnumerableExtensions
    {
        /// <summary>
        /// ForEach extension for <see cref="IEnumerable{T}">IEnumerable</see> method.
        /// </summary>
        /// <typeparam name="TItemType"><paramref name="sourceCollection" /> item type.</typeparam>
        /// <param name="sourceCollection">Source <see cref="IEnumerable{T}">IEnumerable</see> collection reference value.</param>
        /// <param name="action">Action, which one will be applied to each <paramref name="sourceCollection" /> item value.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="action" /> is null.</exception>
        public static void ForEach<TItemType>(this IEnumerable<TItemType> sourceCollection, Action<TItemType> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (var item in sourceCollection)
            {
                action.Invoke(item);
            }
        }

        /// <summary>
        /// ForEach extension for <see cref="IEnumerable{T}">IEnumerable</see> with items index available method.
        /// </summary>
        /// <typeparam name="TItemType"><paramref name="sourceCollection" /> item type.</typeparam>
        /// <param name="sourceCollection">Source <see cref="IEnumerable{T}">IEnumerable</see> collection reference value.</param>
        /// <param name="action">Action, which one will be applied to each <paramref name="sourceCollection" /> item value.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="action" /> is null.</exception>
        public static void ForEach<TItemType>(this IEnumerable<TItemType> sourceCollection, Action<int, TItemType> action)
        {
            if (action is null)
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
