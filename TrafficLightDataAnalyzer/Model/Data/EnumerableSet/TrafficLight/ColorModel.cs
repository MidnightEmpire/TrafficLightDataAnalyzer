using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight
{
    /// <summary>
    /// Traffic light color model class.
    /// </summary>
    internal sealed class ColorModel : BaseEnumerableSetModel<ColorModel>
    {
        /// <summary>
        /// Undefined color name constant.
        /// </summary>
        private const string UndefinedColorName = null;

        /// <summary>
        /// Red color name constant.
        /// </summary>
        private const string RedColorName = "Red";

        /// <summary>
        /// Green color name constant.
        /// </summary>
        private const string GreenColorName = "Green";

        /// <summary>
        /// All color models collection reference field.
        /// </summary>
        private static List<ColorModel> _allColors;

        /// <summary>
        /// <see cref="ColorModel.AllColors">AllColors</see> property collection lazy loader reference field.
        /// </summary>
        private static Lazy<ReadOnlyCollection<ColorModel>> _allColorsPropertyLazyLoader;

        /// <summary>
        /// Register <paramref name="colorModelToRegister" /> color model instance in <see cref="ColorModel._allColors">all colors</see> models collection method.
        /// </summary>
        /// <param name="colorModelToRegister">Color model reference value to register.</param>
        private static void registerColor(ColorModel colorModelToRegister)
        {
            ColorModel._allColors.Add(colorModelToRegister);
        }

        /// <summary>
        /// All color models collection computed property.<br />
        /// Note: <see cref="ColorModel.Undefined">Undefined</see> color model instance will be excluded from this collection.
        /// </summary>
        public static ReadOnlyCollection<ColorModel> AllColors => ColorModel._allColorsPropertyLazyLoader.Value;

        /// <summary>
        /// Undefined <see cref="ColorModel">ColorModel</see> instance static reference property.
        /// </summary>
        public static ColorModel Undefined { get; }

        /// <summary>
        /// Red <see cref="ColorModel">ColorModel</see> instance static reference property.
        /// </summary>
        public static ColorModel Red { get; }

        /// <summary>
        /// Green <see cref="ColorModel">ColorModel</see> instance static reference property.
        /// </summary>
        public static ColorModel Green { get; }

        /// <summary>
        /// Color name property.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Find <see cref="ColorModel">ColorModel</see> instance by specified color <paramref name="name" /> method.
        /// </summary>
        /// <param name="name">Proper color name value</param>
        /// <returns>Matched/founded <see cref="ColorModel">ColorModel</see> instance reference value.</returns>
        public static ColorModel FindByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var matchedColorModel = ColorModel._allColors.Find((color) => name.Equals(color.Name));

                if (!(matchedColorModel is null))
                {
                    return matchedColorModel;
                }
            }

            return ColorModel.Undefined;
        }

        /// <summary>
        /// Find <see cref="ColorModel">ColorModel</see> instance by specified color <paramref name="name" /> method.
        /// </summary>
        /// <param name="name">Proper color name value.</param>
        /// <param name="comparisonType">String comparison type value.</param>
        /// <returns>Matched/founded <see cref="ColorModel">ColorModel</see> instance reference value.</returns>
        public static ColorModel FindByName(string name, StringComparison comparisonType)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var matchedColor = ColorModel._allColors.Find((color) => name.Equals(color.Name, comparisonType));

                if (matchedColor != null)
                {
                    return matchedColor;
                }
            }

            return ColorModel.Undefined;
        }

        /// <summary>
        /// Main constructor: must be private, not allowed to create another <see cref="ColorModel">ColorModel</see> instances by anyone.
        /// </summary>
        /// <param name="name">Traffic light color name value.</param>
        private ColorModel(string name)
        {
            this.Name = name;

            ColorModel.registerColor(this);
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static ColorModel()
        {
            ColorModel._allColors = new List<ColorModel>();

            ColorModel._allColorsPropertyLazyLoader = new Lazy<ReadOnlyCollection<ColorModel>>(() =>
            {
                var result = ColorModel._allColors
                    .Where((color) => color != ColorModel.Undefined)
                    .ToList();

                return result.AsReadOnly();
            });

            ColorModel.Undefined = new ColorModel(ColorModel.UndefinedColorName);
            ColorModel.Red = new ColorModel(ColorModel.RedColorName);
            ColorModel.Green = new ColorModel(ColorModel.GreenColorName);
        }

        /// <summary>
        /// <see cref="ColorModel">ColorModel</see> value to string conversion method.
        /// </summary>
        /// <param name="colorModel"><see cref="ColorModel">ColorModel</see> value to convert.</param>
        /// <returns>Converted <see cref="ColorModel">ColorModel</see>.</returns>
        public static string ToString(ColorModel colorModel)
        {
            if (colorModel is null)
            {
                return "null";
            }

            if (colorModel == ColorModel.Undefined)
            {
                return "Undefined";
            }

            return colorModel.Name;
        }

        #region Object overrides

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var color = ColorModel.ToString(this);

            return $"Color: {color}";
        }

        #endregion

        #region IEquatable<ColorModel>

        /// <summary>
        /// Indicates whether the current object is equal to <paramref name="otherObject" /> object of the same type.
        /// </summary>
        /// <param name="otherObject">An object to compare with this object.</param>
        /// <returns>True, if current object is equal to the <paramref name="otherObject" /> object. Otherwise, returns false.</returns>
        public override bool Equals(ColorModel otherObject)
        {
            if (otherObject is null)
            {
                return false;
            }

            return this.Name == otherObject.Name;
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

                var nameHashCode = this.Name.GetHashCode();

                hashCode = (hashCode * 397) ^ nameHashCode;

                return hashCode;
            }
        }

        #endregion
    }
}
