namespace Resources.Entities.ConfigSections
{
    /// <summary>
    /// Permite identificar una seccion de configuracion
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal sealed class ConfigurationSectionAtribute : Attribute
    {
        /// <summary>
        /// Nombre de la seccion
        /// </summary>
        public string Name { get; set; }
    }
}
