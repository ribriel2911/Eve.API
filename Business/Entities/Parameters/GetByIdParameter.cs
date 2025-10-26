using Resources.Abstractions.Entities.Parameters;

namespace Business.Entities.Parameters
{
    public class GetByIdParameter : IGetByIdParameter
    {
        #region Properties
        /// <inheritdoc cref="IGetByIdParameter.Id"/>
        public int Id { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public GetByIdParameter() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"><inheritdoc cref="IGetByIdParameter.Id" path="/summary"/></param>
        public GetByIdParameter(int id)
        {
            this.Id = id;
        }
        #endregion
    }
}
