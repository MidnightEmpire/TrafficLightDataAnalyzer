using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight
{
    /// <summary>
    /// Traffic light digit model class.
    /// </summary>
    internal sealed class DigitModel : BaseEnumerableSetModel<DigitModel>
    {
        /// <summary>
        /// Undefined digit value constant.
        /// </summary>
        private const sbyte UndefinedValue = -1;

        /// <summary>
        /// Zero digit value constant.
        /// </summary>
        private const sbyte Digit0Value = 0;

        /// <summary>
        /// One digit value constant.
        /// </summary>
        private const sbyte Digit1Value = 1;

        /// <summary>
        /// Two digit value constant.
        /// </summary>
        private const sbyte Digit2Value = 2;

        /// <summary>
        /// Three digit value constant.
        /// </summary>
        private const sbyte Digit3Value = 3;

        /// <summary>
        /// Four digit value constant.
        /// </summary>
        private const sbyte Digit4Value = 4;

        /// <summary>
        /// Five digit value constant.
        /// </summary>
        private const sbyte Digit5Value = 5;

        /// <summary>
        /// Six digit value constant.
        /// </summary>
        private const sbyte Digit6Value = 6;

        /// <summary>
        /// Seven digit value constant.
        /// </summary>
        private const sbyte Digit7Value = 7;

        /// <summary>
        /// Eight digit value constant.
        /// </summary>
        private const sbyte Digit8Value = 8;

        /// <summary>
        /// Nine digit value constant.
        /// </summary>
        private const sbyte Digit9Value = 9;

        /// <summary>
        /// All digit models dictionary reference field.
        /// </summary>
        private static Dictionary<sbyte, DigitModel> _allDigits;

        /// <summary>
        /// <see cref="DigitModel.AllDigits">AllDigits</see> property collection lazy loader reference field.
        /// </summary>
        private static Lazy<ReadOnlyCollection<DigitModel>> _allDigitPropertyLazyLoader;

        /// <summary>
        /// Register <paramref name="digitModelToRegister" /> digit model instance in <see cref="DigitModel._allDigits">all digits</see> models collection method.
        /// </summary>
        /// <param name="digitModelToRegister">Digit model reference value to register.</param>
        /// <exception cref="ArgumentException">Throws if <paramref name="digitModelToRegister" /> already exists in the <see cref="DigitModel._allDigits">all digit models collection.</see></exception>
        private static void registerDigit(DigitModel digitModelToRegister)
        {
            var isNonUnique = DigitModel._allDigits.Values.Any(
                (digit) => digit.Value == digitModelToRegister.Value
            );

            if (isNonUnique) {
                throw new ArgumentException(nameof(digitModelToRegister));
            }

            DigitModel._allDigits.Add(digitModelToRegister.Value, digitModelToRegister);
        }

        /// <summary>
        /// All digit models collection computed property.<br />
        /// Note: <see cref="DigitModel.Undefined">Undefined</see> digit model instance will be excluded from this collection.
        /// </summary>
        public static ReadOnlyCollection<DigitModel> AllDigits => DigitModel._allDigitPropertyLazyLoader.Value;

        /// <summary>
        /// Undefined <see cref="DigitModel">DigitModel</see> instance static reference property.
        /// </summary>
        public static DigitModel Undefined { get; }

        /// <summary>
        /// Zero <see cref="DigitModel">DigitModel</see> instance static reference property.
        /// </summary>
        public static DigitModel Digit0 { get; }

        /// <summary>
        /// One <see cref="DigitModel">DigitModel</see> instance static reference property.
        /// </summary>
        public static DigitModel Digit1 { get; }

        /// <summary>
        /// Two <see cref="DigitModel">DigitModel</see> instance static reference property.
        /// </summary>
        public static DigitModel Digit2 { get; }

        /// <summary>
        /// Three <see cref="DigitModel">DigitModel</see> instance static reference property.
        /// </summary>
        public static DigitModel Digit3 { get; }

        /// <summary>
        /// Four <see cref="DigitModel">DigitModel</see> instance static reference property.
        /// </summary>
        public static DigitModel Digit4 { get; }

        /// <summary>
        /// Five <see cref="DigitModel">DigitModel</see> instance static reference property.
        /// </summary>
        public static DigitModel Digit5 { get; }

        /// <summary>
        /// Six <see cref="DigitModel">DigitModel</see> instance static reference property.
        /// </summary>
        public static DigitModel Digit6 { get; }

        /// <summary>
        /// Seven <see cref="DigitModel">DigitModel</see> instance static reference property.
        /// </summary>
        public static DigitModel Digit7 { get; }

        /// <summary>
        /// Eight <see cref="DigitModel">DigitModel</see> instance static reference property.
        /// </summary>
        public static DigitModel Digit8 { get; }

        /// <summary>
        /// Nine <see cref="DigitModel">DigitModel</see> instance static reference property.
        /// </summary>
        public static DigitModel Digit9 { get; }

        /// <summary>
        /// Unique digit value property.
        /// </summary>
        public sbyte Value { get; }

        /// <summary>
        /// Find <see cref="DigitModel">DigitModel</see> instance by specified digit <paramref name="value" /> method.
        /// </summary>
        /// <param name="value">Proper digit value value</param>
        /// <returns>Matched/founded <see cref="DigitModel">DigitModel</see> instance reference value.</returns>
        public static DigitModel FindByValue(sbyte value)
        {
            if (!DigitModel._allDigits.ContainsKey(value))
            {
                return DigitModel.Undefined;
            }

            return DigitModel._allDigits[value];
        }

        /// <summary>
        /// Main constructor: must be private, not allowed to create another <see cref="DigitModel">DigitModel</see> instances by anyone.
        /// </summary>
        /// <param name="value">Usual digit value.</param>
        private DigitModel(sbyte value)
        {
            this.Value = value;

            DigitModel.registerDigit(this);
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static DigitModel()
        {
            DigitModel._allDigits = new Dictionary<sbyte, DigitModel>();

            DigitModel._allDigitPropertyLazyLoader = new Lazy<ReadOnlyCollection<DigitModel>>(() =>
            {
                var result = DigitModel._allDigits
                    .Values
                    .Where((digit) => digit != DigitModel.Undefined)
                    .ToList();

                return result.AsReadOnly();
            });

            DigitModel.Undefined = new DigitModel(DigitModel.UndefinedValue);

            DigitModel.Digit0 = new DigitModel(DigitModel.Digit0Value);
            DigitModel.Digit1 = new DigitModel(DigitModel.Digit1Value);
            DigitModel.Digit2 = new DigitModel(DigitModel.Digit2Value);
            DigitModel.Digit3 = new DigitModel(DigitModel.Digit3Value);
            DigitModel.Digit4 = new DigitModel(DigitModel.Digit4Value);
            DigitModel.Digit5 = new DigitModel(DigitModel.Digit5Value);
            DigitModel.Digit6 = new DigitModel(DigitModel.Digit6Value);
            DigitModel.Digit7 = new DigitModel(DigitModel.Digit7Value);
            DigitModel.Digit8 = new DigitModel(DigitModel.Digit8Value);
            DigitModel.Digit9 = new DigitModel(DigitModel.Digit9Value);
        }

        /// <summary>
        /// <see cref="DigitModel">DigitModel</see> value to string conversion method.
        /// </summary>
        /// <param name="digitModel"><see cref="DigitModel">DigitModel</see> value to convert.</param>
        /// <returns>Converted <see cref="DigitModel">DigitModel</see>.</returns>
        public static string ToString(DigitModel digitModel)
        {
            if (digitModel is null)
            {
                return "null";
            }

            if (digitModel == DigitModel.Undefined)
            {
                return "Undefined";
            }

            return digitModel.Value.ToString();
        }

        #region Object overrides

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var value = DigitModel.ToString(this);

            return $"Digit: {value}";
        }

        #endregion

        #region IEquatable<SevenSegmentDigit>

        /// <summary>
        /// Indicates whether the current object is equal to <paramref name="otherObject" /> of the same type.
        /// </summary>
        /// <param name="otherObject">An object to compare with this object.</param>
        /// <returns>True, if current object is equal to the <paramref name="otherObject" /> object. Otherwise, returns false.</returns>
        public override bool Equals(DigitModel otherObject)
        {
            if (otherObject is null)
            {
                return false;
            }

            return this.Value == otherObject.Value;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 13;

                var valueHashCode = this.Value.GetHashCode();

                hashCode = (hashCode * 397) ^ valueHashCode;

                return hashCode;
            }
        }

        #endregion
    }
}
