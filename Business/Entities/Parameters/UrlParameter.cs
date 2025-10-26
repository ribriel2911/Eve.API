using Resources.Abstractions.Entities.Parameters;

namespace Business.Entities.Parameters
{
    /// <inheritdoc cref="IUrlParameter"/>
    public class UrlParameter : IUrlParameter
    {
        #region Properties
        /// <inheritdoc cref="IBaseEntity.Flow"/>
        public string Flow { get; set; }

        /// <inheritdoc cref="IUrlParameter.Url"/>
        public string Url { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public UrlParameter() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url"><inheritdoc cref="IUrlParameter.Url" path="/summary"/></param>
        public UrlParameter(string url) 
        { 
            this.Url = url;
        }
        #endregion
    }
}
