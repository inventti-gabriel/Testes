using ConwayGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwayGameOfLifeTest
{
    [TestClass]
    public class GameTest
    {
        private Game _game;

        [TestInitialize]
        public void Inicializar()
        {
            _game = new Game();
        }

        [TestMethod]
        public void DeveMorrerCelulaSemVizinhos()
        {
            var resultado = _game.ProximoPasso("\n" +
                "         \n" +
                "    X    \n" +
                "         ");
            var esperado = "\n" +
                "         \n" +
                "         \n" +
                "         ";
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void DeveManterCelulasComUmOuDoisVizinhos()
        {
            var resultado = _game.ProximoPasso("\n" +
                "    X     \n" +
                "    X   X \n" +
                "    X   X \n" +
                "        X \n" +
                "          ");
            var esperado = "\n" +
                "          \n" +
                "   XXX    \n" +
                "       XXX\n" +
                "          \n" +
                "          ";
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void DeveMorrerCelulasComMaisDeTresVizinhos()
        {
            var resultado = _game.ProximoPasso("\n" +
                "   X      \n" +
                "  XXX     \n" +
                "   X  X   \n" +
                "     X    \n" +
                "    XXX   ");
            var esperado = "\n" +
                "  XXX     \n" +
                "  X X     \n" +
                "  XX X    \n" +
                "          \n" +
                "    XXX   ";
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void DeveViverCelulasMortasComTresVizinhos()
        {
            var resultado = _game.ProximoPasso("\n" +
                "          \n" +
                "  XXX     \n" +
                "          ");
            var esperado = "\n" +
                "   X      \n" +
                "   X      \n" +
                "   X      ";
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void DeveRetornarNaveLeve()
        {
            var resultado = _game.ProximoPasso("\n" +
                "        \n" +
                "   XX   \n" +
                " XX XX  \n" +
                " XXXX   \n" +
                "  XX    \n" +
                "        ");
            var esperado = "\n" +
                "        \n" +
                "  XXXX  \n" +
                " X   X  \n" +
                "     X  \n" +
                " X  X   \n" +
                "        ";
            Assert.AreEqual(esperado, resultado);
        }
    }
}
