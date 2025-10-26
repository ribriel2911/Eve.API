using Cross.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources.Entities.Parameters;

namespace Resources.Entities.Tests
{
    /// <summary>
    /// Test unitarios de 
    /// <inheritdoc cref="GetByNameParameter" path="/summary"/>
    /// </summary>
    [TestClass]
    public class GetByNameParameterTest : GetByNameBaseParameterTest<GetByNameParameter>
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
        public override void Name_Null() => base.Name_Null();

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public override void Name_Empty() => base.Name_Empty();

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public override void Name_WhiteSpace() => base.Name_WhiteSpace();
        #endregion
    }

    /// <summary>
    /// Test unitarios base de 
    /// <typeparamref name="TGetByNameValidatable"/>
    /// </summary>
    /// <typeparam name="TGetByNameValidatable"><inheritdoc cref="GetByNameValidatable" path="/summary"/></typeparam>
    public abstract class GetByNameBaseParameterTest<TGetByNameValidatable> : EntityTestBase<TGetByNameValidatable>
        where TGetByNameValidatable : GetByNameValidatable, new()
    {
        #region Protected Methods
        /// <summary>
        /// <inheritdoc cref="EntityTestBase{TEntity}.GetTarget"/>
        /// <see cref="GetByNameParameter"/>
        /// </summary>
        /// <returns><inheritdoc cref="GetByNameParameter" path="/summary"/></returns>
        protected override TGetByNameValidatable GetTarget()
        {
            var target = base.GetTarget();

            target.Name = "Name";

            return target;
        }
        #endregion

        #region Tests
        public virtual void Name_Null() => this.TestNull(p => p.Name);

        public virtual void Name_Empty() => this.TestEmptyString(p => p.Name);

        public virtual void Name_WhiteSpace() => this.TestEmptyWhiteSpaceString(p => p.Name);
        #endregion
    }
}
