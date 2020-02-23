namespace TestApp.Common
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
            /// Observation sequence is already finished one exception message compution property
            /// </summary>
            public static string ObservationIsAlreadyFinished => "The red observation should be the last";
        }
    }
}
