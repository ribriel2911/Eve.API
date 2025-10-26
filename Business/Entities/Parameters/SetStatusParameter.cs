using Resources.Abstractions.Entities.Parameters;

namespace Business.Entities.Parameters
{
    /// <inheritdoc cref="ISetStatusParameter"/>
    public class SetStatusParameter : GetByIdParameter, ISetStatusParameter
    {
        /// <inheritdoc cref="ISetStatusParameter.Status"/>
        public bool Status { get; set; }
    }
}
