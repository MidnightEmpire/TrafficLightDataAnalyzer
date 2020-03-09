using System;

namespace TrafficLightDataAnalyzer.Model.Data.EnumerableSet
{
    /// <summary>
    /// Base enumerable set model class.
    /// </summary>
    /// <typeparam name="TChildSet">Real enumerable set implementation child type.</typeparam>
    internal abstract class BaseEnumerableSetModel<TChildSet> : BaseDataModel, IEquatable<TChildSet>
        where TChildSet : BaseEnumerableSetModel<TChildSet>
    {
        /// <summary>
        /// Main constructor: not allowed to create another instances by anyone, which one is not <typeparamref name="TChildSet" /> type.
        /// </summary>
        protected BaseEnumerableSetModel()
        {
        }

        #region IEquatable<TChildSet>

        /// <summary>
        /// Determines whether the <paramref name="otherObject" /> is equal to the current object.
        /// </summary>
        /// <param name="otherObject">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object. Otherwise, returns false.</returns>
        public override bool Equals(object otherObject)
        {
            if (object.ReferenceEquals(null, otherObject))
            {
                return false;
            }

            if (object.ReferenceEquals(this, otherObject))
            {
                return true;
            }

            if (otherObject.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals(otherObject as TChildSet);
        }

        /// <summary>
        /// Indicates whether the current object is equal to <paramref name="otherObject" /> of the <typeparamref name="TChildSet" /> type.
        /// </summary>
        /// <param name="otherObject">An object to compare with this object.</param>
        /// <returns>True if current object is equal to the other parameter. Otherwise, returns false.</returns>
        public abstract bool Equals(TChildSet otherObject);

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Equality operator overload method.
        /// </summary>
        /// <param name="first">First operand reference value.</param>
        /// <param name="second">Second operand reference value.</param>
        /// <returns>True, if both operands are equal. Otherwise, returns false.</returns>
        public static bool operator ==(BaseEnumerableSetModel<TChildSet> first, BaseEnumerableSetModel<TChildSet> second)
        {
            if (object.ReferenceEquals(first, null))
            {
                return object.ReferenceEquals(second, null);
            }

            first = first as TChildSet;
            second = second as TChildSet;

            if (first is null ||
                second is null
            ) {
                return false;
            }

            return first.Equals(second);
        }

        /// <summary>
        /// Inequality operator overload method.
        /// </summary>
        /// <param name="first">First operand reference value.</param>
        /// <param name="second">Second operand reference value.</param>
        /// <returns>True, if both operands are inequal. Otherwise, returns false.</returns>
        public static bool operator !=(BaseEnumerableSetModel<TChildSet> first, BaseEnumerableSetModel<TChildSet> second)
        {
            if (object.ReferenceEquals(first, null))
            {
                return !object.ReferenceEquals(second, null) && second is TChildSet;
            }

            if (object.ReferenceEquals(second, null))
            {
                return !object.ReferenceEquals(first, null) && first is TChildSet;
            }

            first = first as TChildSet;
            second = second as TChildSet;

            if (first is null ||
                second is null
            ) {
                return true;
            }

            return !first.Equals(second);
        }

        #endregion
    }
}
