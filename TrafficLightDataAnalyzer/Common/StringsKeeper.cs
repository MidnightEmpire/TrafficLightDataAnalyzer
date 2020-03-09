using System;
using TrafficLightDataAnalyzer.Model.Observation.State.TrafficLight;
using TrafficLightDataAnalyzer.Model.Observation.TrafficLight;

namespace TrafficLightDataAnalyzer.Common
{
    /// <summary>
    /// Common/global string values keeping class.
    /// </summary>
    internal static class StringsKeeper
    {
        /// <summary>
        /// Exception messages values keeping class.
        /// </summary>
        internal static class ExceptionMessage
        {
            /// <summary>
            /// Invalid <see cref="Guid">GUID</see> string exception message computed property.
            /// </summary>
            public static string InvalidGuidFormat => "String has invalid GUID format";

            /// <summary>
            /// No solutions found exception message computed property.
            /// </summary>
            public static string NoSolution => "No solutions found";

            /// <summary>
            /// <see cref="ObservationModel">ObservationModel</see> is not found (missing) one exception message computed property.
            /// </summary>
            public static string ObservationNotFound => "The sequence isn't found";

            /// <summary>
            /// <see cref="ObservationModel">ObservationModel</see> is empty one exception message computed property.
            /// </summary>
            public static string ObservationIsEmpty => "There isn't enough data";

            /// <summary>
            /// <see cref="ObservationModel">ObservationModel</see> is already sealed one exception message computed property.
            /// </summary>
            public static string ObservationIsAlreadySealed => "The red observation should be the last";

            /// <summary>
            /// <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see> obtains invalid traffic light color exception message computed property.
            /// </summary>
            public static string InvalidColorName => "Traffic light registered state has invalid color name";

            /// <summary>
            /// <see cref="ObservedObjectStateModel">ObservedObjectStateModel</see> obtains invalid 7-segment binary code string exception message computed property.
            /// </summary>
            public static string Invalid7SegmentDigitCode => "Traffic light registered state has invalid 7-segment digit code";
        }
    }
}
