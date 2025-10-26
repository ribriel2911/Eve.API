using Business.Entities.Criterias;
using Cross.Entities.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.Entities.Tests
{
    /// <summary>
    /// Test unitarios de 
    /// <inheritdoc cref="ChangeCriteria"/>
    /// </summary>
    [TestClass]
    public class ChangeCriteriaTest : ChangeCriteriaBaseTest<ChangeCriteria>
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

        [TestMethod]
        [TestCategory("Caso Optimo")]
        public override void RepeatMode_NoRepeat() => base.RepeatMode_NoRepeat();

        [TestMethod]
        [TestCategory("Caso Optimo")]
        public override void RepeatMode_RepeatAll() => base.RepeatMode_RepeatAll();

        [TestMethod]
        [TestCategory("Caso Optimo")]
        public override void RepeatMode_RepeatOne() => base.RepeatMode_RepeatOne();

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public override void RepeatMode_Invalid() => base.RepeatMode_Invalid();
        #endregion
    }

    /// <summary>
    /// Test unitarios base de 
    /// <typeparamref name="TChangeValidatable"/>
    /// </summary>
    /// <typeparam name="TChangeValidatable"><inheritdoc cref="ChangeValidatable" path="/summary"/></typeparam>
    public abstract class ChangeCriteriaBaseTest<TChangeValidatable> : VolumeCriteriaBaseTest<TChangeValidatable>
        where TChangeValidatable : ChangeValidatable, new()
    {
        #region Tests
        public virtual void RepeatMode_NoRepeat() 
            => this.TestOk(c => c.RepeatMode, (int)RepeatMode.NoRepeat);

        public virtual void RepeatMode_RepeatAll() 
            => this.TestOk(c => c.RepeatMode, (int)RepeatMode.RepeatAll);

        public virtual void RepeatMode_RepeatOne() 
            => this.TestOk(c => c.RepeatMode, (int)RepeatMode.RepeatOne);

        public virtual void RepeatMode_Invalid() => this.TestInvalid(c => c.RepeatMode, -1);
        #endregion
    }
}
