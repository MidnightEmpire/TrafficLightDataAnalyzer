using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;

namespace TrafficLightDataAnalyzer.Model.Conversion.Converter.TrafficLight.ClockFace
{
    /// <summary>
    /// <see cref="DigitModel">DigitModel</see> to 7-segment binary code converter model class.
    /// </summary>
    internal class DigitTo7SegmentCodeConverterModel : ISimpleConverter<DigitModel, byte>
    {
        /// <summary>
        /// Undefined 7-segment binary code representation constant.
        /// </summary>
        private const byte UndefinedBinaryCode = 0b0000_0000;

        /// <summary>
        /// <see cref="DigitModel.Digit0">DigitModel.Digit0</see> 7-segment binary code representation constant.
        /// </summary>
        private const byte Digit0BinaryCode = 0b0111_0111;

        /// <summary>
        /// <see cref="DigitModel.Digit1">DigitModel.Digit1</see> 7-segment binary code representation constant.
        /// </summary>
        private const byte Digit1BinaryCode = 0b0001_0010;

        /// <summary>
        /// <see cref="DigitModel.Digit2">DigitModel.Digit2</see> 7-segment binary code representation constant.
        /// </summary>
        private const byte Digit2BinaryCode = 0b0101_1101;

        /// <summary>
        /// <see cref="DigitModel.Digit3">DigitModel.Digit3</see> 7-segment binary code representation constant.
        /// </summary>
        private const byte Digit3BinaryCode = 0b0101_1011;

        /// <summary>
        /// <see cref="DigitModel.Digit4">DigitModel.Digit4</see> 7-segment binary code representation constant.
        /// </summary>
        private const byte Digit4BinaryCode = 0b0011_1010;

        /// <summary>
        /// <see cref="DigitModel.Digit5">DigitModel.Digit5</see> 7-segment binary code representation constant.
        /// </summary>
        private const byte Digit5BinaryCode = 0b0110_1011;

        /// <summary>
        /// <see cref="DigitModel.Digit6">DigitModel.Digit6</see> 7-segment binary code representation constant.
        /// </summary>
        private const byte Digit6BinaryCode = 0b0110_1111;

        /// <summary>
        /// <see cref="DigitModel.Digit7">DigitModel.Digit7</see> 7-segment binary code representation constant.
        /// </summary>
        private const byte Digit7BinaryCode = 0b0101_0010;

        /// <summary>
        /// <see cref="DigitModel.Digit8">DigitModel.Digit8</see> 7-segment binary code representation constant.
        /// </summary>
        private const byte Digit8BinaryCode = 0b0111_1111;

        /// <summary>
        /// <see cref="DigitModel.Digit9">DigitModel.Digit9</see> 7-segment binary code representation constant.
        /// </summary>
        private const byte Digit9BinaryCode = 0b0111_1011;

        /// <summary>
        /// <see cref="DigitModel">DigitModel</see> values to 7-segment binary codes mapping dictionary reference field.
        /// </summary>
        private static Dictionary<DigitModel, byte> _mapper;

        /// <summary>
        /// Value conversion method.
        /// </summary>
        /// <param name="source">Source value to convert.</param>
        /// <returns>Result/converted value.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="source" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if source is undefined or not found in all digits <see cref="DigitTo7SegmentCodeConverterModel._mapper">mapper</see>.</exception>
        public byte Convert(DigitModel source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source == DigitModel.Undefined ||
                !DigitTo7SegmentCodeConverterModel._mapper.ContainsKey(source)
            ) {
                throw new ArgumentOutOfRangeException(nameof(source));
            }

            return DigitTo7SegmentCodeConverterModel._mapper[source];
        }

        /// <summary>
        /// Value reverse-conversion method.
        /// </summary>
        /// <param name="source">Source value to reverse-convert.</param>
        /// <returns>Result/reverse-converted value.</returns>
        public DigitModel ConvertBack(byte source)
        {
            var resultDigit = DigitTo7SegmentCodeConverterModel._mapper
                .FirstOrDefault((item) => item.Value == source)
                .Key;

            return resultDigit ?? DigitModel.Undefined;
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static DigitTo7SegmentCodeConverterModel()
        {
            var map = new Func<DigitModel, byte>((digit) =>
            {
                switch (digit.Value)
                {
                    case 0: return Digit0BinaryCode;
                    case 1: return Digit1BinaryCode;
                    case 2: return Digit2BinaryCode;
                    case 3: return Digit3BinaryCode;
                    case 4: return Digit4BinaryCode;
                    case 5: return Digit5BinaryCode;
                    case 6: return Digit6BinaryCode;
                    case 7: return Digit7BinaryCode;
                    case 8: return Digit8BinaryCode;
                    case 9: return Digit9BinaryCode;
                    default: return UndefinedBinaryCode;
                }
            });

            DigitTo7SegmentCodeConverterModel._mapper = DigitModel
                .AllDigits
                .ToDictionary(
                    (item) => item,
                    (item) => map(item)
                );
        }
    }
}
