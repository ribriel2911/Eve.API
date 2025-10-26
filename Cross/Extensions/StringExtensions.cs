namespace Cross.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Realiza un Substring considerando que:
        /// <para>Si el <paramref name="startIndex"/> es mayor al ultimo indice del string retorna <see cref="string.Empty"/></para>
        /// <para>Si el <paramref name="startIndex"/> sumado al <paramref name="length"/> superan a la longitud total del string 
        /// retorna la cadena restante a partir del <paramref name="startIndex"/></para>
        /// </summary>
        /// <param name="startIndex">Indice de corte inicial</param>
        /// <param name="length">Largo del string</param>
        /// <returns><inheritdoc cref="string.Substring(int, int)" path="/summary"/></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string SecureSubstring(this string value, int startIndex, int length)
        {
            if(string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            if(startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Debe ser mayor o igual a cero");
            }

            if(length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Debe ser mayor a cero");
            }

            if(startIndex > value.Length - 1)
            {
                return string.Empty;
            }
            else if(startIndex + length > value.Length)
            {
                return value.Substring(startIndex);
            }
            else
            {
                return value.Substring(startIndex, length);
            }
        }

        /// <summary>
        /// Convierte un string a una enumeracion
        /// </summary>
        /// <typeparam name="TEnum">Tipo de enumeracion</typeparam>
        /// <param name="defaultValue">Valor por defecto</param>
        /// <returns><typeparamref name="TEnum"/></returns>
        public static TEnum ToEnum<TEnum>(this string value, TEnum defaultValue)
            where TEnum : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            TEnum result;

            return Enum.TryParse(value, true, out result) ? result : defaultValue;
        }
    }
}
