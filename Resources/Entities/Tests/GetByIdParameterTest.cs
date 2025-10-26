using Cross.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources.Entities.Parameters;

namespace Resources.Entities.Tests
{
    /// <summary>
    /// Test unitarios de 
    /// <inheritdoc cref="GetByIdParameter"/>
    /// </summary>
    [TestClass]
    public class GetByIdParameterTest : GetByIdBaseParameterTest<GetByIdParameter>
    {
        #region Protected Methods
        [TestInitialize]
        public override void Init() => this.Test_Initializer();
        #endregion

        #region Tests
        [TestMethod]
        [TestCategory("Caso Optimo")]
        public override void Ok() => this.TestOk();

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public override void Id_Low() => base.Id_Low();

        [TestMethod]
        [TestCategory("Caso Optimo")]
        public override void Id_Min() => base.Id_Min();
        #endregion
    }

    /// <summary>
    /// Test unitarios base de 
    /// <typeparamref name="TGetByIdValidatable"/>
    /// </summary>
    /// <typeparam name="TGetByIdValidatable"><inheritdoc cref="GetByIdValidatable" path="/summary"/></typeparam>
    public abstract class GetByIdBaseParameterTest<TGetByIdValidatable> : EntityTestBase<TGetByIdValidatable>
        where TGetByIdValidatable : GetByIdValidatable, new()
    {
        #region Protected Methods
        /// <summary>
        /// <inheritdoc cref="EntityTestBase{TEntity}.GetTarget"/>
        /// <see cref="GetByIdValidatable"/>
        /// </summary>
        /// <returns><inheritdoc cref="GetByIdValidatable" path="/summary"/></returns>
        protected override TGetByIdValidatable GetTarget()
        {
            var target = base.GetTarget();

            target.Id = 10;

            return target;
        }
        #endregion

        #region Tests
        public virtual void Id_Low() => this.TestInvalid(p => p.Id, 0);

        public virtual void Id_Min() => this.TestOk(p => p.Id, 1);
        #endregion
    }
}
