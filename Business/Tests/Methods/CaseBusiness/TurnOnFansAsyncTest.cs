using Business.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaseBusinessTests
{
    [TestClass]
    public class TurnOnFansAsyncTest : CaseBusinessTest
    {
        #region Initialize
        [TestInitialize]
        public override void Init() => TestInitializer();
        #endregion

        #region Protected Methods
        public override Task<bool> GetTargetMethod()
            => Target.TurnOnFansAsync();
        #endregion

        #region Tests Methods
        [TestMethod]
        public override async Task Ok() => await Test_Ok();

        [TestMethod]
        public override async Task ArduinoInstructions_Error()
            => await Test_ArduinoInstructions_Error();

        [TestMethod]
        public override async Task Arduino_Fail()
            => await Test_Arduino_Fail();

        [TestMethod]
        public override async Task Arduino_Error()
            => await Test_Arduino_Error();
        #endregion
    }
}
