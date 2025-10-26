using Business.Tests.Mocks;
using Business.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cross.Tests.Extensions;

namespace PlayerBusinessTests
{
    [TestClass]
    public class StopAsyncTest : PlayerBusinessTest<Task>
    {
        #region Initialize
        [TestInitialize]
        public override void Init() => base.Init();
        #endregion

        #region Protected Methods
        public override Task GetTargetMethod() => Target.StopAsync();
        #endregion


        #region Tests Methods
        [TestMethod]
        public override async Task Ok()
        {
            await GetTargetMethod();

            VlcMock.StopAsync.Verify(1);
        }

        #region Service Errors
        [TestMethod]
        public override async Task VlcService_StopAsync_Error()
            => await base.VlcService_StopAsync_Error();
        #endregion
        #endregion
    }
}
