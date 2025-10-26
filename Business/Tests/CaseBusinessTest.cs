using Business.Entities;
using Business.Tests.Mocks;
using Cross.Tests;
using Cross.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.Tests
{
    public abstract class CaseBusinessTest : BaseBusinessTest<CaseBusiness, Task<bool>>
    {
        #region Fields
        protected ArduinoInstructionsMock arduinoInstructionsMock;
        protected ArduinoMock arduinoMock;
        #endregion

        #region Initialize
        protected void TestInitializer()
        {
            arduinoInstructionsMock = new ArduinoInstructionsMock();
            arduinoMock = new ArduinoMock();

            Target = new CaseBusiness(
                MapperTest.GetMapper(new BusinessProfile()),
                arduinoMock.Object,
                arduinoInstructionsMock.Object);

            arduinoInstructionsMock.GetInstructionByNameAsync.Setup(
                ArduinoInstructionsMock.GetView("1", "instruction"));
            arduinoMock.ExecuteAsync.Setup(true);
        }
        #endregion

        #region Public Methods
        public abstract Task ArduinoInstructions_Error();
        public abstract Task Arduino_Fail();
        public abstract Task Arduino_Error();
        #endregion

        #region Protected Methods
        protected async Task Test_Ok()
        {
            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            arduinoInstructionsMock.GetInstructionByNameAsync.Verify(1);
            arduinoMock.ExecuteAsync.Verify(1);
        }
        protected async Task Test_ArduinoInstructions_Error()
        {
            await this.ServiceErrorTest(arduinoInstructionsMock.GetInstructionByNameAsync);

            arduinoInstructionsMock.GetInstructionByNameAsync.Verify(1);
            arduinoMock.ExecuteAsync.Verify(0);
        }
        protected async Task Test_Arduino_Fail()
        {
            arduinoMock.ExecuteAsync.Setup(false);

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.IsFalse(result);

            arduinoInstructionsMock.GetInstructionByNameAsync.Verify(1);
            arduinoMock.ExecuteAsync.Verify(1);
        }
        protected async Task Test_Arduino_Error()
        {
            await this.ServiceErrorTest(arduinoMock.ExecuteAsync);

            arduinoInstructionsMock.GetInstructionByNameAsync.Verify(1);
            arduinoMock.ExecuteAsync.Verify(1);
        }
        #endregion
    }
}
