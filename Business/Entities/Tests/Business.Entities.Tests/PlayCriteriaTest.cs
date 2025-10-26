using Business.Entities.Criterias;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.Entities.Tests
{
    /// <summary>
    /// Test unitarios de 
    /// <inheritdoc cref="PlayCriteria"/>
    /// </summary>
    [TestClass]
    public class PlayCriteriaTest : ChangeCriteriaBaseTest<PlayCriteria>
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

        [TestMethod]
        [TestCategory("Caso Optimo")]
        public void MediaId_Null() => this.TestOk(c => c.MediaId, null);

        [TestMethod]
        [TestCategory("Caso Optimo")]
        public void MediaId_Min() => this.TestOk(c => c.MediaId, 1);

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public void MediaId_Low() => this.TestInvalid(c => c.MediaId, 0);
        #endregion
    }
}
