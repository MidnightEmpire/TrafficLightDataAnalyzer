using System;
using TrafficLightDataAnalyzer.Interface;

namespace TrafficLightDataAnalyzer.Model.Conversion.Converter
{
    /// <summary>
    /// Byte binary presentation to it's "binary" string converter model class.<br />
    /// For example, 2 will be presented as 00000010 string value.
    /// </summary>
    internal class ByteToBinaryStringConverterModel : ISimpleConverter<byte, string>
    {
        /// <summary>
        /// Value conversion method.
        /// </summary>
        /// <param name="source">Source value to convert.</param>
        /// <returns>Result/converted value.</returns>
        public string Convert(byte source)
        {
            var result = System.Convert.ToString(source, 2);

            return result.PadLeft(8, '0');
        }

        /// <summary>
        /// Value reverse-conversion method.
        /// </summary>
        /// <param name="source">Source value to reverse-convert.</param>
        /// <returns>Result/reverse-converted value.</returns>
        public byte ConvertBack(string source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return System.Convert.ToByte(source, 2);
        }
    }
}
