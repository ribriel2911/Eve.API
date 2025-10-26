using System.Configuration;

namespace Resources.Entities.ConfigSections
{
    /// <summary>
    /// Clase encargada de contener una coleccion de elementos configurables
    /// </summary>
    /// <typeparam name="TElement"><inheritdoc cref="ConfigurationElement" path="/summary"/></typeparam>
    public abstract class GenericConfigElementCollection<TElement> : ConfigurationElementCollection, IEnumerable<TElement>
        where TElement : ConfigurationElement, new()
    {
        /// <inheritdoc/>
        protected override ConfigurationElement CreateNewElement()
        {
            return new TElement();
        }

        /// <inheritdoc/>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return this.GetElementKey((TElement)element);
        }

        /// <summary>
        /// Recupera la key del objeto
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected abstract object GetElementKey(TElement element);

        /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
        public new IEnumerator<TElement> GetEnumerator()
        {
            var count = base.Count;

            for (var i = 0; i < count; i++)
            {
                yield return base.BaseGet(i) as TElement;
            }
        }
    }
}
