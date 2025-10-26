using Cross.Abstractions;
using Resources.Abstractions.Entities.Parameters;

namespace Resources.Entities.Parameters
{
    ///<inheritdoc cref="ISetStatusParameter"/>
    public class SetStatusValidatable : GetByIdValidatable, ISetStatusParameter
    {
        #region Properties
        /// <inheritdoc cref="ISetStatusParameter.Status"/>
        public bool Status { get; set; }
        #endregion
    }

    ///<inheritdoc cref="ISetStatusParameter"/>
    public class SetStatusParameter : SetStatusValidatable, IMapFrom<ISetStatusParameter> { }
}
