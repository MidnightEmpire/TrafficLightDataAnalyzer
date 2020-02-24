using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TrafficLightDataAnalyzer.Model.Common.EnumerableSet
{
    /// <summary>
    /// Traffic light color model class
    /// </summary>
    internal sealed class TrafficLightColorModel : BaseEnumerableSetModel<TrafficLightColorModel>
    {
        /// <summary>
        /// Undefined traffic light color name constant
        /// </summary>
        private const string UndefinedColorName = null;

        /// <summary>
        /// Red traffic light color name constant
        /// </summary>
        private const string RedColorName = "Red";

        /// <summary>
        /// Green traffic light color name constant
        /// </summary>
        private const string GreenColorName = "Green";

        /// <summary>
        /// All traffic light color models collection reference field
        /// </summary>
        private static List<TrafficLightColorModel> _allColors;

        /// <summary>
        /// Register traffic light color model in all traffic light color models collection method
        /// </summary>
        /// <param name="trafficLightColorModel">Traffic light color modell reference value to register</param>
        private static void registerTrafficLightColor(TrafficLightColorModel trafficLightColorModel)
        {
            TrafficLightColorModel._allColors.Add(trafficLightColorModel);
        }

        /// <summary>
        /// All traffic light color models collection computional property
        /// </summary>
        public static ReadOnlyCollection<TrafficLightColorModel> AllColors => TrafficLightColorModel._allColors.AsReadOnly();

        /// <summary>
        /// Undefined traffic light color model instance static reference property
        /// </summary>
        public static TrafficLightColorModel Undefined { get; }

        /// <summary>
        /// Red traffic light color model instance static reference property
        /// </summary>
        public static TrafficLightColorModel Red { get; }

        /// <summary>
        /// Green traffic light color model instance static reference property
        /// </summary>
        public static TrafficLightColorModel Green { get; }

        /// <summary>
        /// Color name property
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Find traffic light color model by specified name method
        /// </summary>
        /// <param name="name">Traffic light color proper name value</param>
        /// <returns>Traffic light color proper class reference value</returns>
        public static TrafficLightColorModel FindByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var matchedColor = TrafficLightColorModel._allColors.Find((color) => name.Equals(color.Name));

                if (!(matchedColor is null))
                {
                    return matchedColor;
                }
            }

            return TrafficLightColorModel.Undefined;
        }

        /// <summary>
        /// Find traffic light color model by specified name method
        /// </summary>
        /// <param name="name">Traffic light color proper name value</param>
        /// <param name="comparisonType">String comparison type</param>
        /// <returns>Traffic light color proper class reference value</returns>
        public static TrafficLightColorModel FindByName(string name, StringComparison comparisonType)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var matchedColor = TrafficLightColorModel._allColors.Find((color) => name.Equals(color.Name, comparisonType));

                if (!(matchedColor is null))
                {
                    return matchedColor;
                }
            }

            return TrafficLightColorModel.Undefined;
        }

        /// <summary>
        /// Main constructor: must be private, no one allowed to create another colors ny anyone
        /// </summary>
        /// <param name="name">Traffic light color name value</param>
        private TrafficLightColorModel(string name)
        {
            this.Name = name;

            TrafficLightColorModel.registerTrafficLightColor(this);
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static TrafficLightColorModel()
        {
            TrafficLightColorModel._allColors = new List<TrafficLightColorModel>();

            TrafficLightColorModel.Undefined = new TrafficLightColorModel(TrafficLightColorModel.UndefinedColorName);
            TrafficLightColorModel.Red = new TrafficLightColorModel(TrafficLightColorModel.RedColorName);
            TrafficLightColorModel.Green = new TrafficLightColorModel(TrafficLightColorModel.GreenColorName);
        }

        #region Object overrides

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns>A string that represents the current object</returns>
        public override string ToString()
        {
            var color = this.Name ?? "Undefined";

            return $"Color: {color}";
        }

        #endregion

        #region IEquatable<TrafficLightColor>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type
        /// </summary>
        /// <param name="other">An object to compare with this object</param>
        /// <returns>True if current object is equal to the other parameter. Otherwise, returns false</returns>
        public override bool Equals(TrafficLightColorModel other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Name == other.Name;
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

                var nameHashCode = this.Name.GetHashCode();

                hashCode = (hashCode * 397) ^ nameHashCode;

                return hashCode;
            }
        }

        #endregion
    }
}
