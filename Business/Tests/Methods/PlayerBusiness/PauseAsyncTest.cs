using Business.Tests.Mocks;
using Business.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cross.Tests.Extensions;

namespace PlayerBusinessTests
{
    [TestClass]
    public class PauseAsyncTest : PlayerBusinessTest<Task>
    {
        #region Initialize
        [TestInitialize]
        public override void Init() => base.Init();
        #endregion

        #region Protected Methods
        public override Task GetTargetMethod() => Target.PauseAsync();
        #endregion


        #region Tests Methods
        [TestMethod]
        public override async Task Ok()
        {
            await GetTargetMethod();

            VlcMock.PauseAsync.Verify(1);
        }
        #region Service Errors
        [TestMethod]
        public override async Task VlcService_PauseAsync_Error()
            => await base.VlcService_PauseAsync_Error();
        #endregion
        #endregion
    }
}
