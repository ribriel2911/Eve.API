using Business.Abstractions.Entities.Criterias;
using Business.Abstractions.Entities.Views;
using Business.Entities.Criterias;
using Business.Tests.Mocks;
using Business.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cross.Tests.Extensions;

namespace PlayerBusinessTests
{
    [TestClass]
    public class PlayAsyncTest : PlayerBusinessTest<PlayCriteria, IPlayCriteria, Task<IMediaView>>
    {
        [TestInitialize]
        public override void Init() => base.Init();

        #region Protected Methods
        public override Task<IMediaView> GetTargetMethod(IPlayCriteria criteria)
            => Target.PlayAsync(criteria);
        #endregion

        #region Tests Methods
        [TestMethod]
        public override async Task Ok()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true });

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.AreEqual(Samples.First().Name, result.Name);
            Assert.AreEqual("Radio", result.Type);
            Assert.IsTrue(result.Playing);
            Assert.IsNull(result.Duration);
            Assert.IsNull(result.Played);
            Assert.AreEqual(Samples.First().Frequency, result.Frequency);
            Assert.AreEqual(Samples.First().Wave.ToString("g"), result.Wave);

            VlcMock.SetVolumeAsync.Verify(1);
            RadiosMock.GetByIdParameterAsync.Verify(0);
            VlcMock.IsNowPlayingAsync.Verify(2);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(1);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_Aleatory()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true });

            Criteria.Aleatory = true;

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.IsTrue(
                Samples.Any(s => s.Name == result.Name
                              && s.Frequency == result.Frequency
                              && s.Wave.ToString("g") == result.Wave));
            Assert.AreEqual("Radio", result.Type);
            Assert.IsTrue(result.Playing);
            Assert.IsNull(result.Duration);
            Assert.IsNull(result.Played);

            VlcMock.SetVolumeAsync.Verify(1);
            RadiosMock.GetByIdParameterAsync.Verify(0);
            VlcMock.IsNowPlayingAsync.Verify(2);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(1);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_Stoped()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true, false, true });

            await GetTargetMethod();

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.AreEqual(Samples.First().Name, result.Name);
            Assert.AreEqual("Radio", result.Type);
            Assert.IsTrue(result.Playing);
            Assert.IsNull(result.Duration);
            Assert.IsNull(result.Played);
            Assert.AreEqual(Samples.First().Frequency, result.Frequency);
            Assert.AreEqual(Samples.First().Wave.ToString("g"), result.Wave);

            VlcMock.SetVolumeAsync.Verify(2);
            RadiosMock.GetByIdParameterAsync.Verify(0);
            VlcMock.IsNowPlayingAsync.Verify(4);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(2);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_Playing()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true, true });

            await GetTargetMethod();

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.AreEqual(Samples.First().Name, result.Name);
            Assert.AreEqual("Radio", result.Type);
            Assert.IsTrue(result.Playing);
            Assert.IsNull(result.Duration);
            Assert.IsNull(result.Played);
            Assert.AreEqual(Samples.First().Frequency, result.Frequency);
            Assert.AreEqual(Samples.First().Wave.ToString("g"), result.Wave);

            VlcMock.SetVolumeAsync.Verify(2);
            RadiosMock.GetByIdParameterAsync.Verify(0);
            VlcMock.IsNowPlayingAsync.Verify(3);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(1);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_Media()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true });

            Criteria.MediaId = 3;

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.AreEqual(Samples.First(s => s.Id == 3).Name, result.Name);
            Assert.AreEqual("Radio", result.Type);
            Assert.IsTrue(result.Playing);
            Assert.IsNull(result.Duration);
            Assert.IsNull(result.Played);
            Assert.AreEqual(Samples.First(s => s.Id == 3).Frequency, result.Frequency);
            Assert.AreEqual(Samples.First(s => s.Id == 3).Wave.ToString("g"), result.Wave);

            VlcMock.SetVolumeAsync.Verify(1);
            RadiosMock.GetByIdParameterAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(1);
            VlcMock.IsNowPlayingAsync.Verify(2);
            RadiosMock.GetRadiosAsync.Verify(0);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_Dont_Play()
        {
            VlcMock.IsNowPlayingAsync.Setup(false);

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.AreEqual(Samples.First().Name, result.Name);
            Assert.AreEqual("Radio", result.Type);
            Assert.IsFalse(result.Playing);
            Assert.IsNull(result.Duration);
            Assert.IsNull(result.Played);
            Assert.AreEqual(Samples.First().Frequency, result.Frequency);
            Assert.AreEqual(Samples.First().Wave.ToString("g"), result.Wave);

            VlcMock.SetVolumeAsync.Verify(1);
            RadiosMock.GetByIdParameterAsync.Verify(0);
            VlcMock.IsNowPlayingAsync.Verify(12);
            RadiosMock.GetRadiosAsync.Verify(2);
            VlcMock.PlayUriAsync.Verify(1);
            RadiosMock.SetStatusAsync.Verify(1);
        }

        #region Service Errors
        [TestMethod]
        [TestCategory("Service Errors")]
        public override async Task VlcService_SetVolumeAsync_Error()
        {
            await base.VlcService_SetVolumeAsync_Error();

            RadiosMock.GetByIdParameterAsync.Verify(0);
            VlcMock.IsNowPlayingAsync.Verify(0);
            RadiosMock.GetRadiosAsync.Verify(0);
            VlcMock.PlayUriAsync.Verify(0);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        [TestCategory("Service Errors")]
        public override async Task VlcService_IsNowPlayingAsync_Error()
        {
            await base.VlcService_IsNowPlayingAsync_Error();

            VlcMock.SetVolumeAsync.Verify(1);
            RadiosMock.GetByIdParameterAsync.Verify(0);
            RadiosMock.GetRadiosAsync.Verify(0);
            VlcMock.PlayUriAsync.Verify(0);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        [TestCategory("Service Errors")]
        public override async Task RadioService_GetByIdParameterAsync_Error()
        {
            Criteria.MediaId = 3;

            await base.RadioService_GetByIdParameterAsync_Error();

            VlcMock.SetVolumeAsync.Verify(1);
            VlcMock.IsNowPlayingAsync.Verify(0);
            RadiosMock.GetRadiosAsync.Verify(0);
            VlcMock.PlayUriAsync.Verify(0);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        [TestCategory("Service Errors")]
        public override async Task RadioService_GetRadiosAsync_Error()
        {
            await base.RadioService_GetRadiosAsync_Error();

            VlcMock.SetVolumeAsync.Verify(1);
            RadiosMock.GetByIdParameterAsync.Verify(0);
            VlcMock.IsNowPlayingAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(0);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        [TestCategory("Service Errors")]
        public override async Task VlcService_PlayUriAsync_Error()
        {
            await base.VlcService_PlayUriAsync_Error();

            VlcMock.SetVolumeAsync.Verify(1);
            RadiosMock.GetByIdParameterAsync.Verify(0);
            VlcMock.IsNowPlayingAsync.Verify(1);
            RadiosMock.GetRadiosAsync.Verify(1);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        [TestCategory("Service Errors")]
        public override async Task RadioService_SetStatusAsync_Error()
        {
            VlcMock.IsNowPlayingAsync.Setup(false);

            await base.RadioService_SetStatusAsync_Error();

            VlcMock.SetVolumeAsync.Verify(1);
            RadiosMock.GetByIdParameterAsync.Verify(0);
            VlcMock.IsNowPlayingAsync.Verify(12);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(1);
        }
        #endregion
        #endregion
    }
}
