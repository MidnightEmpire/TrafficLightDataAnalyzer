using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Common.EnumerableSet;
using TrafficLightDataAnalyzer.Model.Navigation.AssociativeNavigator;

namespace TrafficLightDataAnalyzer.Model.Navigation
{
    /// <summary>
    /// Navigation factory model class
    /// </summary>
    internal class NavigationFactoryModel
    {
        /// <summary>
        /// Seven segment digit closed loop navigator model instance obtaining method
        /// </summary>
        /// <returns>New instance of seven segment digit closed loop navigator model</returns>
        public IAssociativeNavigator<SevenSegmentDigitModel> CreateSequentialCountdownDigitRangeGenerator()
        {
            return new SevenSegmentDigitClosedLoopNavigatorModel();
        }
    }
}
