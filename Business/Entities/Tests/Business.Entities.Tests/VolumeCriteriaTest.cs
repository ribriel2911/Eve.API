using Business.Entities.Criterias;
using Cross.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.Entities.Tests
{
    /// <summary>
    /// Test unitarios de 
    /// <inheritdoc cref="VolumeCriteria"/>
    /// </summary>
    [TestClass]
    public class VolumeCriteriaTest : VolumeCriteriaBaseTest<VolumeCriteria>
    {
        [TestInitialize]
        public override void Init() => this.Test_Initializer();

        #region Tests
        [TestMethod]
        [TestCategory("Caso Optimo")]
        public override void Ok() => this.TestOk();

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public override void Volume_High() => base.Volume_High();

        [TestMethod]
        [TestCategory("Caso Optimo")]
        public override void Volume_Max() => base.Volume_Max();

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public override void Volume_Low() => base.Volume_Low();

        [TestMethod]
        [TestCategory("Caso Optimo")]
        public override void Volume_Min() => base.Volume_Min();
        #endregion
    }


    /// <summary>
    /// Test unitarios base de 
    /// <typeparamref name="TVolumeValidatable"/>
    /// </summary>
    /// <typeparam name="TVolumeValidatable"><inheritdoc cref="VolumeValidatable" path="/summary"/></typeparam>
    public abstract class VolumeCriteriaBaseTest<TVolumeValidatable> : EntityTestBase<TVolumeValidatable>
        where TVolumeValidatable : VolumeValidatable, new()
    {
        #region Protected Methods
        /// <summary>
        /// <inheritdoc cref="EntityTestBase{TEntity}.GetTarget"/>
        /// <see cref="VolumeValidatable"/>
        /// </summary>
        /// <returns><inheritdoc cref="VolumeValidatable" path="/summary"/></returns>
        protected override TVolumeValidatable GetTarget()
        {
            var target = base.GetTarget();

            target.Volume = 50;

            return target;
        }
        #endregion

        #region Tests
        public virtual void Volume_High() => this.TestInvalid(c => c.Volume, 101);

        public virtual void Volume_Max() => this.TestOk(c => c.Volume, 100);

        public virtual void Volume_Low() => this.TestInvalid(c => c.Volume, -1);

        public virtual void Volume_Min() => this.TestOk(c => c.Volume, 0);
        #endregion
    }
}
