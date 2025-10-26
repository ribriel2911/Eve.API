using System.Configuration;

namespace Resources.Entities.ConfigSections
{
    public static class ConfigurationSections
    {
        #region Public Methods
        /// <summary>
        /// Obtiene la configuracion especificada
        /// </summary>
        /// <typeparam name="TConfigSection"><see cref="ConfigurationSection"/></typeparam>
        /// <returns><see cref="ConfigurationSection"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public static TConfigSection GetSection<TConfigSection>() where TConfigSection : ConfigurationSection
        {
            var configName = GetName(typeof(TConfigSection));

            var config = ConfigurationManager.GetSection(configName) as TConfigSection;

            if (config == null)
                throw new ArgumentException($"No se encontro una seccion con nombre '{configName}'");

            return config;
        }
        #endregion

        #region Private Methods
        private static string GetName(Type type)
        {
            var attr = type.GetCustomAttributes(typeof(ConfigurationSectionAtribute), false);

            if(attr.Any())
                return ((ConfigurationSectionAtribute)attr.First()).Name ?? type.Name;

            return type.Name;
        }
        #endregion
    }
}
