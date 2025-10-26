using Resources.Abstractions.Entities.Parameters;

namespace Business.Entities.Parameters
{
    /// <inheritdoc cref="IExecuteParameter"/>
    public class ExecuteParameter : IExecuteParameter
    {
        #region Properties
        /// <inheritdoc cref="IExecuteParameter.Code"/>
        public string Code { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public ExecuteParameter() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"><inheritdoc cref="IExecuteParameter.Code" path="/summary"/></param>
        public ExecuteParameter(string code)
        {
            this.Code = code;
        }
        #endregion
    }
}
