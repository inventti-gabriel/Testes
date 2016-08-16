using BolicheGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BolicheTest
{
    [TestClass]
    public class BolicheTest
    {
        private Boliche CriarBoliche()
        {
            return new Boliche();
        }

        [TestMethod]
        public void RolarTodosZeros()
        {
            var boliche = CriarBoliche();
            RolarVarios(boliche, 20, 0);
            Assert.AreEqual(0, boliche.Pontuacao);
        }

        [TestMethod]
        public void RolarTodosUns()
        {
            var boliche = CriarBoliche();
            RolarVarios(boliche, 20, 1);
            Assert.AreEqual(20, boliche.Pontuacao);
        }

        [TestMethod]
        public void DeveRealizarSpare()
        {
            var boliche = CriarBoliche();
            boliche.Rolar(5);
            boliche.Rolar(5);
            boliche.Rolar(3);
            RolarVarios(boliche, 17, 0);
            Assert.AreEqual(16, boliche.Pontuacao);
        }

        [TestMethod]
        public void DeveRealizarStrike()
        {
            var boliche = CriarBoliche();
            boliche.Rolar(10);
            boliche.Rolar(5);
            boliche.Rolar(3);
            RolarVarios(boliche, 17, 0);
            Assert.AreEqual(26, boliche.Pontuacao);
        }

        [TestMethod]
        public void DeveRealizarJogoPerfeito()
        {
            var boliche = CriarBoliche();
            RolarVarios(boliche, 20, 10);
            Assert.AreEqual(300, boliche.Pontuacao);
        }

        private static void RolarVarios(Boliche boliche, int quantidade, int valor)
        {
            for (var i = 0; i < quantidade; i++)
            {
                boliche.Rolar(valor);
            }
        }
    }
}