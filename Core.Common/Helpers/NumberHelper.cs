using System;

namespace Core.Common.Helpers
{
    public static class NumberHelper
    {
        private static readonly decimal ROUND_NUMBER_DIGIT = 50000;

        /// <summary>
        ///     Rounds to significant digits.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static decimal RoundToSignificantDigits(decimal number)
        {
            var multiple = Math.Round(number / ROUND_NUMBER_DIGIT);
            var newNumber = multiple * ROUND_NUMBER_DIGIT;
            if (newNumber < number) newNumber = newNumber + ROUND_NUMBER_DIGIT;

            return newNumber;
        }
    }
}