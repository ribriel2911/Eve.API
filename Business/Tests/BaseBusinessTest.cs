using Cross.Exceptions;
using Cross.Tests;
using Cross.Tests.Mocks;
using Cross.Tests.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cross.Tests.Extensions;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Business.Tests
{
    public interface IBaseBusinessWithCriteriaTest<TCriteria, ICriteria, TTask>
        where TCriteria : class, ICriteria
        where TTask : Task
    {
        public TCriteria Criteria { get; }

        public TTask GetTargetMethod(ICriteria criteria);
    }

    public abstract class BaseBusinessTest<TBusiness, TTask> : UnitTestBase<TBusiness>
        where TBusiness : BaseBusiness
        where TTask : Task
    {
        public abstract Task Ok();

        public abstract TTask GetTargetMethod();

        protected async Task ServiceErrorTest<TSetup>(TSetup setup)
            where TSetup : ISetupError, IVerify
        {
            setup.SetupError();

            var ex = await AssertThrowsAsync<BusinessException>(GetTargetMethod);

            Assert.IsNotNull(ex);

            setup.Verify(1);
        }
        
        protected async Task ServiceErrorTest<TInterface, TInput>(AsyncSimpleMock<TInterface, TInput> setup)
            where TInterface : class
        {
            setup.SetupError();

            var ex = await AssertThrowsAsync<BusinessException>(GetTargetMethod);

            Assert.IsNotNull(ex);
            setup.Verify(1);
        }

        protected async Task ServiceErrorTest<TInterface, TInput, TOutput>(AsyncSimpleMock<TInterface, TInput, TOutput> setup)
            where TInterface : class
        {
            setup.SetupError();

            var ex = await AssertThrowsAsync<BusinessException>(GetTargetMethod);

            Assert.IsNotNull(ex);

            setup.Verify(1);
        }
    }

    public abstract class BaseBusinessTest<TBusiness, TCriteria, ICriteria, TTask> :
        BaseBusinessTest<TBusiness, TTask>, IBaseBusinessWithCriteriaTest<TCriteria, ICriteria, TTask>
        where TCriteria : class, ICriteria, new()
        where TBusiness : BaseBusiness
        where TTask : Task
    {
        public TCriteria Criteria { get; set; }

        public override void Init() => Criteria = new TCriteria();

        public abstract TTask GetTargetMethod(ICriteria criteria);
        public override TTask GetTargetMethod() => this.GetTargetMethod(Criteria);
    }
}
