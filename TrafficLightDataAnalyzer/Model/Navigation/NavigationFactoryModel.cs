using TrafficLightDataAnalyzer.Interface;
using TrafficLightDataAnalyzer.Model.Data.EnumerableSet.TrafficLight;
using TrafficLightDataAnalyzer.Model.Navigation.Navigator.TrafficLight;

namespace TrafficLightDataAnalyzer.Model.Navigation
{
    /// <summary>
    /// Navigation factory model class.
    /// </summary>
    internal class NavigationFactoryModel
    {
        /// <summary>
        /// <see cref="DigitNavigatorModel">DigitNavigatorModel</see> instance obtaining method.
        /// </summary>
        /// <returns>New instance of <see cref="DigitNavigatorModel">DigitNavigatorModel</see>.</returns>
        public INavigator<DigitModel> CreateDigitNavigator()
        {
            return new DigitNavigatorModel();
        }
    }
}
