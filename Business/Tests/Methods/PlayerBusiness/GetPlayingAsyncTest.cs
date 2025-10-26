using Business.Abstractions.Entities.Views;
using Business.Entities.Criterias;
using Business.Tests;
using Cross.Entities.Enums;
using Cross.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources.Abstractions.Entities.Samples;

namespace PlayerBusinessTests
{
    [TestClass]
    public class GetPlayingAsyncTest : PlayerBusinessTest<Task<IPlayerStateView>>
    {
        #region Initialize
        [TestInitialize]
        public override void Init() => base.Init();
        #endregion

        #region Protected Methods
        public override Task<IPlayerStateView> GetTargetMethod()
            => Target.GetPlaying();
        #endregion

        #region Tests Methods
        [TestMethod]
        public override async Task Ok()
        {
            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            AssertMedia(result.Media);

            Assert.IsFalse(result.Aleatory);
            Assert.AreEqual((int)RepeatMode.NoRepeat, result.RepeatMode);
            Assert.AreEqual(50, result.Volume);

            VlcMock.IsNowPlayingAsync.Verify(1);
        }

        [TestMethod]
        public async Task Ok_Played()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true, true });

            var criteria = new PlayCriteria();

            await this.Target.PlayAsync(criteria);

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            AssertMedia(result.Media, Samples.First(), true);
            AssertPlayed(criteria, result);
        }

        [TestMethod]
        public async Task Ok_Played_Aleatory()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true, true });

            var criteria = new PlayCriteria();
            criteria.Aleatory = true;

            await this.Target.PlayAsync(criteria);

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            AssertAleatoryMedia(result.Media, true);
            AssertPlayed(criteria, result);
        }

        [TestMethod]
        public async Task Ok_Played_RepeatAll()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true, true });

            var criteria = new PlayCriteria();
            criteria.RepeatMode = (int)RepeatMode.RepeatAll;

            await this.Target.PlayAsync(criteria);

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            AssertMedia(result.Media, Samples.First(), true);
            AssertPlayed(criteria, result);
        }

        [TestMethod]
        public async Task Ok_Played_RepeatOne()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true, true });

            var criteria = new PlayCriteria();
            criteria.RepeatMode = (int)RepeatMode.RepeatOne;

            await this.Target.PlayAsync(criteria);

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            AssertMedia(result.Media, Samples.First(), true);
            AssertPlayed(criteria, result);
        }

        [TestMethod]
        public async Task Ok_Played_Volume()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true, true });

            var criteria = new PlayCriteria();
            criteria.Volume = 75;

            await this.Target.PlayAsync(criteria);

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            AssertMedia(result.Media, Samples.First(), true);
            AssertPlayed(criteria, result);
        }

        [TestMethod]
        public async Task Ok_Played_Media()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true, true });

            var criteria = new PlayCriteria();
            criteria.MediaId = Samples.Last().Id;

            await this.Target.PlayAsync(criteria);

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            AssertMedia(result.Media, Samples.Last(), true);
            AssertPlayed(criteria, result);
        }

        [TestMethod]
        public async Task Ok_Stoped()
        {
            VlcMock.IsNowPlayingAsync.SetupSequence(new[] { false, true, false });

            var criteria = new PlayCriteria();

            await this.Target.PlayAsync(criteria);

            var result = await GetTargetMethod();

            Assert.IsNotNull(result);
            AssertMedia(result.Media, Samples.First());
            AssertPlayed(criteria, result);
        }

        #region Service Errors
        [TestMethod]
        public override async Task VlcService_IsNowPlayingAsync_Error()
            => await base.VlcService_IsNowPlayingAsync_Error();
        #endregion
        #endregion

        #region Asserts
        private void AssertPlayed(PlayCriteria criteria, IPlayerStateView result)
        {
            Assert.AreEqual(criteria.Aleatory, result.Aleatory);
            Assert.AreEqual((int)criteria.RepeatMode, result.RepeatMode);
            Assert.AreEqual(criteria.Volume, result.Volume);
        }

        private void AssertMedia(
            IMediaView media,
            IRadioSample sample = null,
            bool playing = false)
        {
            Assert.IsNotNull(media);
            Assert.AreEqual(playing, media.Playing);
            Assert.IsNull(media.Duration);
            Assert.IsNull(media.Played);

            if (sample != null)
            {
                Assert.AreEqual("Radio", media.Type);
                Assert.AreEqual(sample.Name, media.Name);
                Assert.AreEqual(sample.Frequency, media.Frequency);
                Assert.AreEqual(sample.Wave.ToString("g"), media.Wave);
            }
            else
            {
                Assert.IsNull(media.Name);
                Assert.IsNull(media.Type);
                Assert.IsNull(media.Frequency);
                Assert.IsNull(media.Wave);
            }
        }

        private void AssertAleatoryMedia(
            IMediaView media,
            bool playing = false)
        {
            Assert.IsNotNull(media);
            Assert.AreEqual(playing, media.Playing);
            Assert.IsNull(media.Duration);
            Assert.IsNull(media.Played);

            Assert.AreEqual("Radio", media.Type);
            Assert.IsTrue(
                Samples.Any(s => s.Name == media.Name
                              && s.Frequency == media.Frequency
                              && s.Wave.ToString("g") == media.Wave));
        }
        #endregion
    }
}
