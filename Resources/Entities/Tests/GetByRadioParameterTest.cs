using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources.Entities.Parameters;

namespace Resources.Entities.Tests
{
    /// <summary>
    /// Test unitarios de 
    /// <inheritdoc cref="GetByRadioParameter" path="/summary"/>
    /// </summary>
    [TestClass]
    public class GetByRadioParameterTest : GetByNameBaseParameterTest<GetByRadioParameter>
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
        public override void Name_Empty() => base.Name_Empty();

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public override void Name_WhiteSpace() => base.Name_WhiteSpace();

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public void Name_And_Frequency_Null() 
        {
            this.Target.Name = null;

            this.TestFormatableFault("No ha ingresado parametros de busqueda suficientes.", e => e.Frequency);
        }

        [TestMethod]
        [TestCategory("Caso Optimo")]
        public void Frequency_Ok()
        {
            this.Target.Name = null;

            this.TestOk(p => p.Frequency, 1);
        }
        #endregion
    }
}
