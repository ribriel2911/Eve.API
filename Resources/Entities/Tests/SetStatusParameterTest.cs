using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources.Entities.Parameters;

namespace Resources.Entities.Tests
{
    /// <summary>
    /// Test unitarios de 
    /// <inheritdoc cref="SetStatusParameter" path="/summary"/>
    /// </summary>
    [TestClass]
    public class SetStatusParameterTest : GetByIdBaseParameterTest<SetStatusParameter>
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
}
