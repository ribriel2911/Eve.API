using Resources.Abstractions.Entities.Samples;

namespace Business.Tests.Samples
{
    public class InstructionSample : IArduinoInstructionSample
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
