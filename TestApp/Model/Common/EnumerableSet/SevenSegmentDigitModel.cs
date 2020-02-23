using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestApp.Model.Common.EnumerableSet
{
    /// <summary>
    /// 7-segment digit representation model class
    /// </summary>
    internal sealed class SevenSegmentDigitModel : BaseEnumerableSetModel<SevenSegmentDigitModel>
    {
        /// <summary>
        /// Zero digit 7-segment binary code representation constant
        /// </summary>
        private const byte Digit0BinaryCode = 0b0111_0111;

        /// <summary>
        /// One digit 7-segment binary code representation constant
        /// </summary>
        private const byte Digit1BinaryCode = 0b0001_0010;

        /// <summary>
        /// Two digit 7-segment binary code representation constant
        /// </summary>
        private const byte Digit2BinaryCode = 0b0101_1101;

        /// <summary>
        /// Three digit 7-segment binary code representation constant
        /// </summary>
        private const byte Digit3BinaryCode = 0b0101_1011;

        /// <summary>
        /// Four digit 7-segment binary code representation constant
        /// </summary>
        private const byte Digit4BinaryCode = 0b0011_1010;

        /// <summary>
        /// Five digit 7-segment binary code representation constant
        /// </summary>
        private const byte Digit5BinaryCode = 0b0110_1011;

        /// <summary>
        /// Six digit 7-segment binary code representation constant
        /// </summary>
        private const byte Digit6BinaryCode = 0b0110_1111;

        /// <summary>
        /// Seven digit 7-segment binary code representation constant
        /// </summary>
        private const byte Digit7BinaryCode = 0b0101_0010;

        /// <summary>
        /// Eight digit 7-segment binary code representation constant
        /// </summary>
        private const byte Digit8BinaryCode = 0b0111_1111;

        /// <summary>
        /// Nine digit 7-segment binary code representation constant
        /// </summary>
        private const byte Digit9BinaryCode = 0b1111_1011;

        /// <summary>
        /// 7-segment binary code representation pattern mask constant
        /// </summary>
        public const byte BinaryCodePatternMask = 0b0111_1111;

        /// <summary>
        /// All digit value 7-segment representation models collection reference field
        /// </summary>
        private static List<SevenSegmentDigitModel> _allDigits;

        /// <summary>
        /// Register digit value 7-segment representation model in all digit value 7-segment representation models collection method
        /// </summary>
        /// <param name="sevenSegmentDigitModel">Digit value 7-segment representation model reference value to register</param>
        private static void registerSevenSegmentDigit(SevenSegmentDigitModel sevenSegmentDigitModel)
        {
            SevenSegmentDigitModel._allDigits.Add(sevenSegmentDigitModel);
        }

        /// <summary>
        /// All digit value 7-segment representation models collection computional property
        /// </summary>
        public static ReadOnlyCollection<SevenSegmentDigitModel> AllDigits => SevenSegmentDigitModel._allDigits.AsReadOnly();

        /// <summary>
        /// Zero digit value 7-segment representation model instance static reference property
        /// </summary>
        public static SevenSegmentDigitModel Digit0 { get; }

        /// <summary>
        /// One digit value 7-segment representation model instance static reference property
        /// </summary>
        public static SevenSegmentDigitModel Digit1 { get; }

        /// <summary>
        /// Two digit value 7-segment representation model instance static reference property
        /// </summary>
        public static SevenSegmentDigitModel Digit2 { get; }

        /// <summary>
        /// Three digit value 7-segment representation model instance static reference property
        /// </summary>
        public static SevenSegmentDigitModel Digit3 { get; }

        /// <summary>
        /// Four digit value 7-segment representation model instance static reference property
        /// </summary>
        public static SevenSegmentDigitModel Digit4 { get; }

        /// <summary>
        /// Five digit value 7-segment representation model instance static reference property
        /// </summary>
        public static SevenSegmentDigitModel Digit5 { get; }

        /// <summary>
        /// Six digit value 7-segment representation model instance static reference property
        /// </summary>
        public static SevenSegmentDigitModel Digit6 { get; }

        /// <summary>
        /// Seven digit value 7-segment representation model instance static reference property
        /// </summary>
        public static SevenSegmentDigitModel Digit7 { get; }

        /// <summary>
        /// Eight digit value 7-segment representation property
        /// </summary>
        public static SevenSegmentDigitModel Digit8 { get; }

        /// <summary>
        /// Nine digit value 7-segment representation model instance static reference property
        /// </summary>
        public static SevenSegmentDigitModel Digit9 { get; }

        /// <summary>
        /// Enabled segments binary code representation value property
        /// </summary>
        public byte BinaryCode { get; }

        /// <summary>
        /// Usual digit value property
        /// </summary>
        public byte Value { get; }

        /// <summary>
        /// Main constructor: must be private, no one allowed to create another digits ny anyone
        /// </summary>
        /// <param name="binaryCode">Enabled segments binary code representation value</param>
        /// <param name="value">Usual digit value</param>
        private SevenSegmentDigitModel(byte binaryCode, byte value)
        {
            this.BinaryCode = binaryCode;
            this.Value = value;

            SevenSegmentDigitModel.registerSevenSegmentDigit(this);
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static SevenSegmentDigitModel()
        {
            SevenSegmentDigitModel._allDigits = new List<SevenSegmentDigitModel>();

            SevenSegmentDigitModel.Digit0 = new SevenSegmentDigitModel(SevenSegmentDigitModel.Digit0BinaryCode, 0);
            SevenSegmentDigitModel.Digit1 = new SevenSegmentDigitModel(SevenSegmentDigitModel.Digit1BinaryCode, 1);
            SevenSegmentDigitModel.Digit2 = new SevenSegmentDigitModel(SevenSegmentDigitModel.Digit2BinaryCode, 2);
            SevenSegmentDigitModel.Digit3 = new SevenSegmentDigitModel(SevenSegmentDigitModel.Digit3BinaryCode, 3);
            SevenSegmentDigitModel.Digit4 = new SevenSegmentDigitModel(SevenSegmentDigitModel.Digit4BinaryCode, 4);
            SevenSegmentDigitModel.Digit5 = new SevenSegmentDigitModel(SevenSegmentDigitModel.Digit5BinaryCode, 5);
            SevenSegmentDigitModel.Digit6 = new SevenSegmentDigitModel(SevenSegmentDigitModel.Digit6BinaryCode, 6);
            SevenSegmentDigitModel.Digit7 = new SevenSegmentDigitModel(SevenSegmentDigitModel.Digit7BinaryCode, 7);
            SevenSegmentDigitModel.Digit8 = new SevenSegmentDigitModel(SevenSegmentDigitModel.Digit8BinaryCode, 8);
            SevenSegmentDigitModel.Digit9 = new SevenSegmentDigitModel(SevenSegmentDigitModel.Digit9BinaryCode, 9);
        }

        #region Object overrides

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns>A string that represents the current object</returns>
        public override string ToString()
        {
            var binaryCodeString = Convert.ToString(this.BinaryCode, 2);

            binaryCodeString = binaryCodeString.PadLeft(8, '0');

            return $"Digit: {this.Value}, Code: 0b{binaryCodeString}";
        }

        #endregion

        #region IEquatable<SevenSegmentDigit>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type
        /// </summary>
        /// <param name="other">An object to compare with this object</param>
        /// <returns>True if current object is equal to the other parameter. Otherwise, returns false</returns>
        public override bool Equals(SevenSegmentDigitModel other)
        {
            if (other == null)
            {
                return false;
            }

            return this.BinaryCode == other.BinaryCode &&
                   this.Value == other.Value;
        }

        /// <summary>
        /// Serves as a hash function for a particular type
        /// </summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 13;

                var binaryCodeHashCode = this.BinaryCode.GetHashCode();

                hashCode = (hashCode * 397) ^ binaryCodeHashCode;

                var valueHashCode = this.Value.GetHashCode();

                hashCode = (hashCode * 397) ^ valueHashCode;

                return hashCode;
            }
        }

        #endregion
    }
}
