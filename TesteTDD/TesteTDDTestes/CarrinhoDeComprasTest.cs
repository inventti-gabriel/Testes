using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteTDD;

namespace TesteTDDTestes
{
    public class CarrinhoDeComprasBuilder
    {
        public CarrinhoDeCompras carrinho;

        public CarrinhoDeComprasBuilder()
        {
            carrinho = new CarrinhoDeCompras();
        }

        public CarrinhoDeComprasBuilder ComItens(params double[] valores)
        {
            foreach (var valor in valores)
            {
                carrinho.Adiciona(new Item("item", 1, valor));
            }
            return this;
        }

        public CarrinhoDeCompras Cria()
        {
            return carrinho;
        }
    }


    public class CarrinhoDeComprasTest
    {
        private CarrinhoDeCompras carrinho;

        [TestInitialize]
        public void Inicializa()
        {
            carrinho = new CarrinhoDeCompras();
        }

        [TestMethod]
        public void DeveRetornarZeroSeCarrinhoVazio()
        {
            Assert.AreEqual(0.0, carrinho.MaiorValor(), 0.0001);
        }

        [TestMethod]
        public
        void DeveRetornarValorDoItemSeCarrinhoCom1Elemento()
        {
            carrinho.Adiciona(new Item("Geladeira", 1, 900.0));
            Assert.AreEqual(900.0, carrinho.MaiorValor(), 0.0001);
        }

        [TestMethod]
        public void DeveRetornarMaiorValorSeCarrinhoContemMuitosElementos()
        {
            carrinho.Adiciona(new Item("Geladeira", 1, 900.0));
            carrinho.Adiciona(new Item("Fogão", 1, 1500.0));
            carrinho.Adiciona(new Item("Máquina de Lavar", 1, 750.0));
            Assert.AreEqual(1500.0, carrinho.MaiorValor(), 0.0001);
        }
    }
}