namespace Resources.Abstractions.Entities.Samples
{
    /// <summary>
    /// Instruccion arduino
    /// </summary>
    public interface IArduinoInstructionSample
    {
        /// <summary>
        /// Codigo de instruccion
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Nombre de instruccion
        /// </summary>
        string Name { get; }
    }
}
