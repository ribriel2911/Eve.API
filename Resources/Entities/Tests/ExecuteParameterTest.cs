using Resources.Entities.Identifiers;
using Cross.Tests;
using Resources.Entities.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Resources.Entities.Tests
{
    /// <summary>
    /// Test unitarios de 
    /// <inheritdoc cref="ExecuteParameter"/>
    /// </summary>
    [TestClass]
    public class ExecuteParameterTest : EntityTestBase<ExecuteParameter>
    {
        #region Protected Methods
        /// <summary>
        /// <inheritdoc cref="EntityTestBase{TEntity}.GetTarget"/>
        /// <see cref="ExecuteParameter"/>
        /// </summary>
        /// <returns><inheritdoc cref="ExecuteParameter" path="/summary"/></returns>
        protected override ExecuteParameter GetTarget() => 
            new ExecuteParameter
            {
                Code = "1"
            };

        [TestInitialize]
        public override void Init() => this.Test_Initializer();
        #endregion

        #region Tests
        [TestMethod]
        [TestCategory("Caso Optimo")]
        public override void Ok() => this.TestOk();

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public void Code_Null() => this.TestNull(p => p.Code);

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public void Code_Empty() => this.TestEmptyString(p => p.Code);

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public void Code_Not_Numeric() => this.TestInvalid(p => p.Code, "asd");

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public void Code_GetStates() => this.TestInvalid(p => p.Code, Arduino.GetStatesInstruction);

        [TestMethod]
        [TestCategory("Caso de error esperado")]
        public void Code_Reset() => this.TestInvalid(p => p.Code, Arduino.ResetInstruction);
        #endregion
    }
}
