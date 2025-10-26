using Resources.Abstractions.Entities.Parameters;

namespace Business.Entities.Parameters
{
    /// <inheritdoc cref="IGetByNameParameter"/>
    public class GetByNameParameter : IGetByNameParameter
    {
        #region Properties
        /// <inheritdoc cref="IGetByNameParameter.Name"/>
        public string Name { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public GetByNameParameter() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"><inheritdoc cref="IGetByNameParameter.Name" path="/summary"/></param>
        public GetByNameParameter(string name)
        {
            this.Name = name;
        }
        #endregion
    }
}
