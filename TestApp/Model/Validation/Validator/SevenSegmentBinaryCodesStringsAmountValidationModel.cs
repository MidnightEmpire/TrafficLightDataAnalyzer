using System.Linq;
using TestApp.Interface;

namespace TestApp.Model.Validation.Validator
{
    /// <summary>
    /// Traffic light observation seven segment binary codes strings amount validation model class
    /// </summary>
    internal class SevenSegmentBinaryCodesStringsAmountValidationModel : IValidator<string[]>
    {
        /// <summary>
        /// Traffic light observation digits amount constant
        /// </summary>
        public const byte DigitsAmount = 2;

        /// <summary>
        /// Object validation method
        /// </summary>
        /// <param name="objectForCheck">Object which one will be validated</param>
        /// <returns>True, if object seems to be valid one. Otherwise, return false</returns>
        public bool IsValid(string[] objectForCheck)
        {
            return objectForCheck.Length == SevenSegmentBinaryCodesStringsAmountValidationModel.DigitsAmount;
        }
    }
}
