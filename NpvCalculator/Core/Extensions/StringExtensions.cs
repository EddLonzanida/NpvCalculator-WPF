using System;

namespace NpvCalculator.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Case insensitive comparison.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEqualTo(this string source, string value)
        {
            return string.Equals(source.ToLower(), value.ToLower(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Removes the trimValue before comparing. Case insensitive comparison.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <param name="trimValue"></param>
        /// <returns></returns>
        public static bool IsEqualTo(this string source, string value, string trimValue)
        {
            return source.Replace(trimValue, string.Empty).IsEqualTo(value.Replace(trimValue, string.Empty));
        }
    }
}
