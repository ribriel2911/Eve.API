using Business.Abstractions.Entities.Criterias;
using Business.Entities.Criterias;
using Business.Tests.Mocks;
using Business.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cross.Tests.Extensions;

namespace PlayerBusinessTests
{
    [TestClass]
    public class SetVolumeAsyncTest : PlayerBusinessTest<VolumeCriteria, IVolumeCriteria, Task>
    {
        [TestInitialize]
        public override void Init() => base.Init();

        #region Protected Methods
        public override Task GetTargetMethod(IVolumeCriteria criteria)
            => Target.SetVolumeAsync(criteria);
        #endregion

        #region Tests Methods
        [TestMethod]
        public override async Task Ok()
        {
            await GetTargetMethod();

            VlcMock.SetVolumeAsync.Verify(1);
        }

        #region Service Errors
        [TestMethod]
        public override async Task VlcService_SetVolumeAsync_Error()
            => await base.VlcService_SetVolumeAsync_Error();
        #endregion
        #endregion
    }
}
