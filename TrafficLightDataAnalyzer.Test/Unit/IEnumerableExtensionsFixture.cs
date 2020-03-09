using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Common;
using TrafficLightDataAnalyzer.Extension;

namespace TrafficLightDataAnalyzer.Test.Unit
{
    /// <summary>
    /// <see cref="IEnumerableExtensions">IEnumerableExtensions</see> tests fixture class.
    /// </summary>
    [TestFixture]
    internal class IEnumerableExtensionsFixture
    {
        /// <summary>
        /// <see cref="IEnumerableExtensions">IEnumerableExtensions</see>
        /// <see cref="IEnumerableExtensions.ForEach{TItemType}(IEnumerable{TItemType}, Action{TItemType})">ForEach</see> method
        /// throws <see cref="ArgumentNullException">ArgumentNullException</see> if action wasn't specified checking method.
        /// </summary>
        [Test]
        public void ForEach_ActionIsNull_ThrowsArgumentNullException()
        {
            var source = Enumerable.Empty<object>();
            var action = NullInstance.Of<Action<object>>();

            Assert.Catch<ArgumentNullException>(() => source.ForEach(action));
        }

        /// <summary>
        /// <see cref="IEnumerableExtensions">IEnumerableExtensions</see>
        /// <see cref="IEnumerableExtensions.ForEach{TItemType}(IEnumerable{TItemType}, Action{TItemType})">ForEach</see> method
        /// with proper action process each enumerable item checking method.
        /// </summary>
        [Test]
        public void ForEach_ActionSpecified_AppliesActionToEachItem()
        {
            var processed = new List<object>();

            var source = new List<object>()
            { 
                true,
                2,
                "three"
            }
            .AsEnumerable();

            source.ForEach((item) => processed.Add(item));

            Assert.AreEqual(source, processed);
        }

        /// <summary>
        /// <see cref="IEnumerableExtensions">IEnumerableExtensions</see>
        /// <see cref="IEnumerableExtensions.ForEach{TItemType}(IEnumerable{TItemType}, Action{int, TItemType})">ForEach</see> method
        /// throws <see cref="ArgumentNullException">ArgumentNullException</see> if action wasn't specified checking method.
        /// </summary>
        [Test]
        public void IndexedForEach_ActionIsNull_ThrowsArgumentNullException()
        {
            var source = Enumerable.Empty<object>();
            var action = NullInstance.Of<Action<int, object>>();

            Assert.Catch<ArgumentNullException>(() => source.ForEach(action));
        }

        /// <summary>
        /// <see cref="IEnumerableExtensions">IEnumerableExtensions</see>
        /// <see cref="IEnumerableExtensions.ForEach{TItemType}(IEnumerable{TItemType}, Action{int, TItemType})">ForEach</see> method
        /// with proper action process each enumerable item checking method.
        /// </summary>
        [Test]
        public void IndexedForEach_ActionSpecified_AppliesActionToEachItem()
        {
            var processed = new List<KeyValuePair<int, object>>();

            var source = new List<object>()
            {
                true,
                2,
                "three"
            }
            .AsEnumerable();

            var expected = new List<KeyValuePair<int, object>>()
            {
                new KeyValuePair<int, object>(0, true),
                new KeyValuePair<int, object>(1, 2),
                new KeyValuePair<int, object>(2, "three"),
            };

            source.ForEach((index, item) => processed.Add(new KeyValuePair<int, object>(index, item)));

            Assert.AreEqual(expected, processed);
        }
    }
}
