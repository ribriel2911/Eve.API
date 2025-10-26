using System.Configuration;
using AutoMapper;
using Cross.Logic;
using Resources.Entities.ConfigSections;

namespace Resources
{
    public class BaseConfigurableItemResourceAccess<TConfigSection> : BaseEntityManager
        where TConfigSection : ConfigurationSection
    {
        #region Constructors
        /// <inheritdoc cref=BaseEntityManager(IMapper)"/>
        public BaseConfigurableItemResourceAccess(IMapper mapper) : base(mapper) { }
        #endregion

        protected async Task<TResult> GetBySectionAsync<TResult>(Func<TConfigSection, TResult> func)
        {
            var result = await Task.Run(() =>
            {
                var config = ConfigurationSections.GetSection<TConfigSection>();
                return func(config);
            });

            return result;
        }
    }
}
