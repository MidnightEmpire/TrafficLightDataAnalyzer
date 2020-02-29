namespace TrafficLightDataAnalyzer.Common
{
    /// <summary>
    /// Common strings values keeping class
    /// </summary>
    internal static class StringsKeeper
    {
        /// <summary>
        /// Exception messages values keeping class
        /// </summary>
        internal static class ExceptionMessage
        {
            /// <summary>
            /// No solution found exception message compution property
            /// </summary>
            public static string NoSolution => "No solutions found";

            /// <summary>
            /// Observation sequence is missing/incorrect one exception message compution property
            /// </summary>
            public static string MissingObservationSequence => "The sequence isn't found";

            /// <summary>
            /// Observation sequence is empty one exception message compution property
            /// </summary>
            public static string EmptyObservationsSequence => "There isn't enough data";

            /// <summary>
            /// Observation sequence is already sealed one exception message compution property
            /// </summary>
            public static string ObservationIsAlreadySealed => "The red observation should be the last";

            /// <summary>
            /// Observation has invalid traffic light color format exception message compution property
            /// </summary>
            public static string InvalidTrafficLightColor => "Observation has invalid traffic light color format";

            /// <summary>
            /// Observation has invalid seven segment binary code string format exception message compution property
            /// </summary>
            public static string InvalidDigitCode => "Observation has invalid digit code format";

            /// <summary>
            /// Observation has invalid seven segment binary codes strings amount exception message compution property
            /// </summary>
            public static string InvalidDigitCodesAmount => "Observation has invalid digit codes amount";
        }
    }
}
