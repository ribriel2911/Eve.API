using Resources.Abstractions.Entities.Samples;
using System.Configuration;

namespace Resources.Entities.ConfigSections
{
    /// <summary>
    /// Clase encargada de contener la configuracion de instrucciones arduino
    /// <para><seealso cref="ConfigurationSection"/></para>
    /// <para><seealso cref="ConfigCollection"/></para>
    /// <para><seealso cref="IArduinoInstructionView"/></para>
    /// </summary>
    [ConfigurationSectionAtribute(Name = "ArduinoInstructionsConfiguration")]
    public class ArduinoConfigSection : ConfigurationSection
    {
        [ConfigurationProperty(nameof(Instructions))]
        public ArduinoConfigCollection Instructions => base[nameof(Instructions)] as ArduinoConfigCollection;
    }

    /// <summary>
    /// <inheritdoc cref="GenericConfigElementCollection{TElement}"/> de <inheritdoc cref="IArduinoInstructionView"/>
    /// <para><seealso cref="GenericConfigElementCollection{TElement}"/></para>
    /// <para><seealso cref="ConfigurationElementCollection"/></para>
    /// <para><seealso cref="IEnumerable{ArduinoInstructionConfigElement}"/></para>
    /// <para><seealso cref="ConfigElement"/></para>
    /// <para><seealso cref="IArduinoInstructionView"/></para>
    /// </summary>
    [ConfigurationCollection(typeof(ArduinoConfigElement), AddItemName = "Instruction", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ArduinoConfigCollection : GenericConfigElementCollection<ArduinoConfigElement>
    {
        /// <inheritdoc/>
        protected override object GetElementKey(ArduinoConfigElement element)
        {
            return new { element.Name };
        }
    }

    /// <summary>
    /// Clase encargada de contener un elemento configurable de 
    /// <inheritdoc cref="IArduinoInstructionView"/>
    /// <para><seealso cref="ConfigurationElement"/></para>
    /// <para><seealso cref="IArduinoInstructionView"/></para>
    /// </summary>
    public class ArduinoConfigElement : ConfigurationElement, IArduinoInstructionSample
    {
        [ConfigurationProperty(nameof(Code))]
        public string Code => base[nameof(Code)] as string;

        [ConfigurationProperty(nameof(Name))]
        public string Name => base[nameof(Name)] as string;
    }
}
