namespace Resources.Abstractions.Entities.Parameters
{
    /// <summary>
    /// Parametro de ejecucion de instrucciones para el arduino
    /// </summary>
    public interface IExecuteParameter
    { 
        /// <summary>
        /// Codigo a ejecutar por el arduino
        /// </summary>
        string Code { get; }
    }
}
