using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteTDD;

namespace TesteTDDTestes
{
    [TestClass]
    public class CalculadoraDeSalarioTest
    {

        [TestMethod]
        public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAbaixoDoLimite()
        {
            var calculadora = new CalculadoraDeSalario();
            var desenvolvedor = new Funcionario("Mauricio", 1500.0, Cargo.DESENVOLVEDOR);
            var salario = calculadora.CalculaSalario(desenvolvedor);
            Assert.AreEqual(1500.0*0.9, salario, 0.00001);
        }

        [TestMethod]
        public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAcimaDoLimite()
        {
            var calculadora = new CalculadoraDeSalario();
            var desenvolvedor = new Funcionario("Mauricio", 4000.0, Cargo.DESENVOLVEDOR);
            var salario = calculadora.CalculaSalario(desenvolvedor);
            Assert.AreEqual(4000.0*0.8, salario, 0.00001);
        }

        [TestMethod]
        public void DeveCalcularSalarioParaDBAsComSalarioAbaixoDoLimite()
        {
            var calculadora = new CalculadoraDeSalario();
            var dba = new Funcionario("Mauricio", 500.0, Cargo.DBA);
            var salario = calculadora.CalculaSalario(dba);
            Assert.AreEqual(500.0*0.85, salario, 0.00001);
        }

        [TestMethod]
        public void DeveCalcularSalarioParaDBAsComSalarioAcimaDoLimite()
        {
            var calculadora = new CalculadoraDeSalario();
            var dba = new Funcionario("Mauricio", 4500.0, Cargo.DBA);
            var salario = calculadora.CalculaSalario(dba);
            Assert.AreEqual(4500.0 * 0.75, salario, 0.00001);

            
        }
    }
}