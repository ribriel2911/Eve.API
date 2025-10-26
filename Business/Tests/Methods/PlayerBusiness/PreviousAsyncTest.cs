using Business.Abstractions.Entities.Criterias;
using Business.Abstractions.Entities.Views;
using Business.Entities.Criterias;
using Business.Tests.Mocks;
using Business.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cross.Tests.Extensions;
using Cross.Entities.Enums;
using Resources.Abstractions.Entities.Samples;

namespace PlayerBusinessTests
{
    [TestClass]
    public class PreviousAsyncTest : PlayerBusinessTest<ChangeCriteria, IChangeCriteria, Task<IMediaView>>
    {
        [TestInitialize]
        public override void Init() => base.Init();

        #region Protected Methods
        public override Task<IMediaView> GetTargetMethod(IChangeCriteria criteria)
            => Target.PreviousAsync(criteria);
        #endregion

        #region Tests Methods
        [TestMethod]
        public override async Task Ok()
        {
            VlcMock.IsNowPlayingAsync.Setup(true);

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
            VlcMock.IsNowPlayingAsync.Verify(1);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(1);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_First_Aleatory()
        {
            VlcMock.IsNowPlayingAsync.Setup(true);

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
            VlcMock.IsNowPlayingAsync.Verify(1);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(1);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_PreviousOfFirst()
        {
            VlcMock.IsNowPlayingAsync.Setup(true);

            var first = await GetTargetMethod();

            Assert.IsNotNull(first);
            Assert.AreEqual(Samples.First().Name, first.Name);
            Assert.AreEqual("Radio", first.Type);
            Assert.IsTrue(first.Playing);
            Assert.IsNull(first.Duration);
            Assert.IsNull(first.Played);
            Assert.AreEqual(Samples.First().Frequency, first.Frequency);
            Assert.AreEqual(Samples.First().Wave.ToString("g"), first.Wave);

            var second = await GetTargetMethod();

            Assert.IsNotNull(second);
            Assert.AreEqual(Samples.Last().Name, second.Name);
            Assert.AreEqual("Radio", second.Type);
            Assert.IsTrue(second.Playing);
            Assert.IsNull(second.Duration);
            Assert.IsNull(second.Played);
            Assert.AreEqual(Samples.Last().Frequency, second.Frequency);
            Assert.AreEqual(Samples.Last().Wave.ToString("g"), second.Wave);

            VlcMock.SetVolumeAsync.Verify(2);
            VlcMock.IsNowPlayingAsync.Verify(2);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(2);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_RepeatOne()
        {
            VlcMock.IsNowPlayingAsync.Setup(true);
            Criteria.RepeatMode = (int)RepeatMode.RepeatOne;

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.AreEqual(Samples.First().Name, result.Name);
            Assert.AreEqual("Radio", result.Type);
            Assert.IsTrue(result.Playing);
            Assert.IsNull(result.Duration);
            Assert.IsNull(result.Played);
            Assert.AreEqual(Samples.First().Frequency, result.Frequency);
            Assert.AreEqual(Samples.First().Wave.ToString("g"), result.Wave);

            result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.AreEqual(Samples.First().Name, result.Name);
            Assert.AreEqual("Radio", result.Type);
            Assert.IsTrue(result.Playing);
            Assert.IsNull(result.Duration);
            Assert.IsNull(result.Played);
            Assert.AreEqual(Samples.First().Frequency, result.Frequency);
            Assert.AreEqual(Samples.First().Wave.ToString("g"), result.Wave);

            VlcMock.SetVolumeAsync.Verify(2);
            VlcMock.IsNowPlayingAsync.Verify(2);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(2);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_RepeatAll()
        {
            VlcMock.IsNowPlayingAsync.Setup(true);

            Criteria.RepeatMode = (int)RepeatMode.RepeatAll;

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.AreEqual(Samples.First().Name, result.Name);
            Assert.AreEqual("Radio", result.Type);
            Assert.IsTrue(result.Playing);
            Assert.IsNull(result.Duration);
            Assert.IsNull(result.Played);
            Assert.AreEqual(Samples.First().Frequency, result.Frequency);
            Assert.AreEqual(Samples.First().Wave.ToString("g"), result.Wave);

            int i = Samples.Count() - 1;

            while (i >= 0)
            {
                result = await GetTargetMethod();

                Assert.IsNotNull(result);
                Assert.AreEqual(Samples.ElementAt(i).Name, result.Name);
                Assert.AreEqual("Radio", result.Type);
                Assert.IsTrue(result.Playing);
                Assert.IsNull(result.Duration);
                Assert.IsNull(result.Played);
                Assert.AreEqual(Samples.ElementAt(i).Frequency, result.Frequency);
                Assert.AreEqual(Samples.ElementAt(i).Wave.ToString("g"), result.Wave);

                i--;
            }

            VlcMock.SetVolumeAsync.Verify(Samples.Count() + 1);
            VlcMock.IsNowPlayingAsync.Verify(Samples.Count() + 1);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(Samples.Count() + 1);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_PreviousOfFirst_Aleatory()
        {
            VlcMock.IsNowPlayingAsync.Setup(true);

            Criteria.Aleatory = true;

            var first = await GetTargetMethod();

            Assert.IsNotNull(first);
            Assert.IsTrue(
                Samples.Any(s => s.Name == first.Name
                              && s.Frequency == first.Frequency
                              && s.Wave.ToString("g") == first.Wave));
            Assert.AreEqual("Radio", first.Type);
            Assert.IsTrue(first.Playing);
            Assert.IsNull(first.Duration);
            Assert.IsNull(first.Played);

            var second = await GetTargetMethod();

            Assert.IsNotNull(second);
            Assert.IsTrue(
                Samples.Any(s => s.Name == second.Name
                              && s.Frequency == second.Frequency
                              && s.Wave.ToString("g") == second.Wave));
            Assert.AreNotEqual(first.Name, second.Name);
            Assert.AreNotEqual(first.Frequency, second.Frequency);
            Assert.AreEqual("Radio", second.Type);
            Assert.IsTrue(second.Playing);
            Assert.IsNull(second.Duration);
            Assert.IsNull(second.Played);

            VlcMock.SetVolumeAsync.Verify(2);
            VlcMock.IsNowPlayingAsync.Verify(2);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(2);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_RepeatAll_Aleatory()
        {
            VlcMock.IsNowPlayingAsync.Setup(true);

            Criteria.RepeatMode = (int)RepeatMode.RepeatAll;
            Criteria.Aleatory = true;

            int i = 0;
            var samples = Samples;
            IRadioSample firstSample = null;

            while (i < Samples.Count())
            {
                var next = await GetTargetMethod();

                Assert.IsNotNull(next);
                Assert.IsTrue(
                    samples.Any(s => s.Name == next.Name
                                  && s.Frequency == next.Frequency
                                  && s.Wave.ToString("g") == next.Wave));
                Assert.AreEqual("Radio", next.Type);
                Assert.IsTrue(next.Playing);
                Assert.IsNull(next.Duration);
                Assert.IsNull(next.Played);

                if (i == 0)
                    firstSample = samples.First(
                                    s => s.Frequency == next.Frequency
                                        && s.Wave.ToString("g") == next.Wave);

                i++;
                samples = samples.Where(
                            s => !(s.Frequency == next.Frequency
                                && s.Wave.ToString("g") == next.Wave)).ToList();
            }

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            Assert.AreEqual(firstSample.Name, result.Name);
            Assert.AreEqual("Radio", result.Type);
            Assert.IsTrue(result.Playing);
            Assert.IsNull(result.Duration);
            Assert.IsNull(result.Played);
            Assert.AreEqual(firstSample.Frequency, result.Frequency);
            Assert.AreEqual(firstSample.Wave.ToString("g"), result.Wave);

            VlcMock.SetVolumeAsync.Verify(i + 1);
            VlcMock.IsNowPlayingAsync.Verify(i + 1);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(i + 1);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        public async Task Ok_DontPlayed()
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
            VlcMock.IsNowPlayingAsync.Verify(11);
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
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(1);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        [TestCategory("Service Errors")]
        public override async Task RadioService_GetRadiosAsync_Error()
        {
            await base.RadioService_GetRadiosAsync_Error();

            VlcMock.SetVolumeAsync.Verify(1);
            VlcMock.IsNowPlayingAsync.Verify(0);
            VlcMock.PlayUriAsync.Verify(0);
            RadiosMock.SetStatusAsync.Verify(0);
        }

        [TestMethod]
        [TestCategory("Service Errors")]
        public override async Task VlcService_PlayUriAsync_Error()
        {
            await base.VlcService_PlayUriAsync_Error();

            VlcMock.SetVolumeAsync.Verify(1);
            VlcMock.IsNowPlayingAsync.Verify(0);
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
            VlcMock.IsNowPlayingAsync.Verify(11);
            RadiosMock.GetRadiosAsync.Verify(1);
            VlcMock.PlayUriAsync.Verify(1);
        }
        #endregion
        #endregion    
    }
}
