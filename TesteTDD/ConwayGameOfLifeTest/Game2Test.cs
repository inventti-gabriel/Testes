using ConwayGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwayGameOfLifeTest
{
    [TestClass]
    public class Game2Test
    {
        [TestMethod]
        public void SeCriouLigacoesDasCelulas()
        {
            var t = new Tabuleiro(3, 3);
            var celula = t.ObterCelula(1, 1);
            Assert.IsNotNull(celula.Direita);
            Assert.IsNotNull(celula.Esquerda);
            Assert.IsNotNull(celula.Cima);
            Assert.IsNotNull(celula.Baixo);

            Assert.IsNotNull(celula.EsquerdaCima);
            Assert.IsNotNull(celula.EsquerdaBaixo);
            Assert.IsNotNull(celula.DireitaCima);
            Assert.IsNotNull(celula.DireitaBaixo);
        }

        [TestMethod]
        public void SeCelulaVizinhaViva()
        {
            var t = new Tabuleiro(3, 1);
            var celula = t.ObterCelula(1, 0);
            celula.Viva = true;
            celula = t.ObterCelula(0, 0);
            Assert.IsTrue(celula.Direita.Viva);
        }

        [TestMethod]
        public void DeveMatarCelulasSemVizinhos()
        {
            var t = new Tabuleiro(1, 1);
            var celula = t.ObterCelula(0, 0);
            celula.Viva = true;
            var viva = celula.ProximoPasso();
            Assert.IsFalse(viva);
        }

        [TestMethod]
        public void DeveManterCelulasComDoisOuTresVizinhos()
        {
            var t = new Tabuleiro(3, 1);
            var celulaMeio = t.ObterCelula(1, 0);

            Viver(t, 0, 0);
            celulaMeio.Viva = true;
            Viver(t, 2, 0);

            celulaMeio.ProximoPasso();
            Assert.IsTrue(celulaMeio.Viva);
        }

        [TestMethod]
        public void DeveMatarCelulasComMaisDeTresVizinhos()
        {
            var t = new Tabuleiro(3, 2);
            var celulaMeio = t.ObterCelula(1, 0);
            Viver(t, 0, 0);
            celulaMeio.Viva = true;
            Viver(t, 2, 0);
            Viver(t, 1, 1);
            Viver(t, 2, 1);
            /*
             * XVX
             *  XX
             */
            var viva = celulaMeio.ProximoPasso();
            Assert.IsFalse(viva);
        }

        [TestMethod]
        public void DeveViverCelulasComTresVizinhos()
        {
            var t = new Tabuleiro(3, 2);
            var celulaMeio = t.ObterCelula(1, 0);
            Viver(t, 0, 0);
            Viver(t, 2, 0);
            Viver(t, 1, 1);
            /*
             * X_X
             *  X
             */
            var viva = celulaMeio.ProximoPasso();
            Assert.IsTrue(viva);
        }

        [TestMethod]
        public void DeveRealizarProximoPassoNoTabuleiro()
        {
            /*  XX
             * X XX
             * ----
             *  XXX 
             *   XX 
             */
            var t = new Tabuleiro(4, 2);
            Viver(t, 1, 0);
            Viver(t, 2, 0);
            Viver(t, 0, 1);
            Viver(t, 2, 1);
            Viver(t, 3, 1);

            t.ExecutarProximoPasso();

            Assert.IsFalse(t.ObterCelula(0, 0).Viva);
            Assert.IsTrue(t.ObterCelula(1, 0).Viva);
            Assert.IsTrue(t.ObterCelula(2, 0).Viva);
            Assert.IsTrue(t.ObterCelula(3, 0).Viva);

            Assert.IsFalse(t.ObterCelula(0, 1).Viva);
            Assert.IsFalse(t.ObterCelula(1, 1).Viva);
            Assert.IsTrue(t.ObterCelula(2, 1).Viva);
            Assert.IsTrue(t.ObterCelula(3, 1).Viva);
        }

        public void Viver(Tabuleiro tabuleiro, int x, int y)
        {
            tabuleiro.ObterCelula(x, y).Viva = true;
        }
    }
}