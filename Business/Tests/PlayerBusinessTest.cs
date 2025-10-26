using Business.Entities;
using Business.Tests.Mocks;
using Business.Tests.Samples;
using Cross.Entities.Enums;
using Cross.Tests;
using Resources.Abstractions.Entities.Samples;

namespace Business.Tests
{
    public abstract class PlayerBusinessTest<TTask> : BaseBusinessTest<PlayerBusiness, TTask>
        where TTask : Task
    {
        #region Fields
        protected VlcMock VlcMock;
        protected RadiosMock RadiosMock;

        protected IEnumerable<IRadioSample> Samples =
            new List<IRadioSample>
            {
                new RadioSample
                {
                    Id = 1,
                    Frequency = 14.2m,
                    Name = "AM Radio",
                    Url = "www.amRadio.com",
                    Wave = Wave.AM
                },
                new RadioSample
                {
                    Id = 2,
                    Frequency = 99.9m,
                    Name = "La segunda",
                    Url = "www.LaSegunda.com",
                    Wave = Wave.FM
                },
                new RadioSample
                {
                    Id = 3,
                    Frequency = 105.5m,
                    Name = "Los 40",
                    Url = "www.los40.com",
                    Wave = Wave.FM
                }
            };
        #endregion

        #region Protected Methods
        public override void Init()
        {
            VlcMock = new VlcMock();
            RadiosMock = new RadiosMock();

            Target = new PlayerBusiness(
                MapperTest.GetMapper(new BusinessProfile()),
                VlcMock.Object,
                RadiosMock.Object);

            RadiosMock.GetRadiosAsync.Setup(Samples);
            RadiosMock.GetByIdParameterAsync.Setup(c => Samples.First(s => s.Id == c.Id));
        }
        #endregion

        #region Service Tests
        public virtual Task VlcService_IsNowPlayingAsync_Error()
            => this.ServiceErrorTest(VlcMock.IsNowPlayingAsync);

        public virtual Task VlcService_PauseAsync_Error()
            => this.ServiceErrorTest(VlcMock.PauseAsync);

        public virtual Task VlcService_PlayUriAsync_Error()
            => this.ServiceErrorTest(VlcMock.PlayUriAsync);

        public virtual Task VlcService_SetVolumeAsync_Error()
            => this.ServiceErrorTest(VlcMock.SetVolumeAsync);

        public virtual Task VlcService_StopAsync_Error()
            => this.ServiceErrorTest(VlcMock.StopAsync);

        public virtual Task RadioService_GetRadiosAsync_Error() 
            => this.ServiceErrorTest(RadiosMock.GetRadiosAsync);

        public virtual Task RadioService_GetByIdParameterAsync_Error()
            => this.ServiceErrorTest(RadiosMock.GetByIdParameterAsync);

        public virtual Task RadioService_SetStatusAsync_Error() 
            => this.ServiceErrorTest(RadiosMock.SetStatusAsync);
        #endregion
    }

    public abstract class PlayerBusinessTest<TCriteria, ICriteria, TTask> :
        PlayerBusinessTest<TTask>, IBaseBusinessWithCriteriaTest<TCriteria, ICriteria, TTask>
        where TCriteria : class, ICriteria, new()
        where TTask : Task
    {
        public TCriteria Criteria { get; set; }

        public override void Init()
        {
            Criteria = new TCriteria();

            base.Init();
        }

        public abstract TTask GetTargetMethod(ICriteria criteria);
        public override TTask GetTargetMethod() => GetTargetMethod(Criteria);
    }
}
