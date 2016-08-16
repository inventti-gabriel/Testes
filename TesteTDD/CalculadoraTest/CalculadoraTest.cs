using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Library.Test
{
    [TestClass]
    public class CalculadoraTest
    {
        private Calculadora _calculadora;

        [TestInitialize]
        public void Inicializar()
        {
            _calculadora = new Calculadora();
        }

        [TestMethod]
        public void DeveAdicionarVazio()
        {
            var resultado = _calculadora.Adicionar("");
            Assert.AreEqual(0, resultado);
        }

        [TestMethod]
        public void DeveAdicionarUmNumero()
        {
            var resultado = _calculadora.Adicionar("1");
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void DeveAdicionarDoisNumeros()
        {
            var resultado = _calculadora.Adicionar("1,2");
            Assert.AreEqual(3, resultado);
        }

        [TestMethod]
        public void DeveAdicionarVariosNumeros()
        {
            var resultado = _calculadora.Adicionar("1,2,3,4,5,6,7,8,9");
            Assert.AreEqual(45, resultado);
        }

        [TestMethod]
        public void DeveAdicionarVariosNumerosSeparadorQuebraLinha()
        {
            var resultado = _calculadora.Adicionar("1\n2\n3\n4\n5\n6\n7\n8\n9");
            Assert.AreEqual(45, resultado);
        }

        [TestMethod]
        public void DeveAdicionarVariosNumerosSeparadoresQuebraLinhaEVirgula()
        {
            var resultado = _calculadora.Adicionar("1\n2,3");
            Assert.AreEqual(6, resultado);
        }

        [TestMethod]
        public void DeveQuebrarQuandoSeparadoresSemNumeros()
        {
            EsperaExcecaoAdicionar("1,\n");
        }

        [TestMethod]
        public void DevePermitirDelimitadoresPersonalizados()
        {
            var resultado = _calculadora.Adicionar("//;\n1;2;3");
            Assert.AreEqual(6, resultado);
        }
        [TestMethod]
        public void DevePermitirDelimitadoresPersonalizadosVariosCaracteres()
        {
            var resultado = _calculadora.Adicionar("//[asd][qwe]\n1asd2qwe3");
            Assert.AreEqual(6, resultado);
        }

        [TestMethod]
        public void DeveLevantarExcecaoNumerosNegativos()
        {
            EsperaExcecaoAdicionar("1,-2,-3,4,-5");
        }

        [TestMethod]
        public void DeveIgnorarNumerosMaioresQue1000()
        {
            var resultado = _calculadora.Adicionar("1,2,3,1000,1010");
            Assert.AreEqual(1006, resultado);
        }

        private void EsperaExcecaoAdicionar(string valor)
        {
            try
            {
                _calculadora.Adicionar(valor);
                Assert.Fail();
            }
            catch (Exception e)
            {
                // Passou
                Console.WriteLine(e.Message);
            }
        }
    }
}
