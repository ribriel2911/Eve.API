using System.Text.RegularExpressions;

namespace Cross.Extensions
{
    /// <summary>
    /// Extensiones para cadenas string numericas
    /// </summary>
    public static class NumberExtensions
    {
        /// <summary>
        /// Determina si la cadena es numerica
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        public static bool IsNumeric(this string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                return false;

            try
            {
                return Regex.IsMatch(value, @"^[0-9]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch(RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
