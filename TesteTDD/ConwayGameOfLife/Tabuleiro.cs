using System;

namespace ConwayGameOfLife
{
    public class Tabuleiro
    {
        private readonly int _largura;
        private readonly int _altura;
        private Celula[][] Celulas { get; set; }

        public Tabuleiro(int largura, int altura)
        {
            _largura = largura;
            _altura = altura;
            Celulas = CriarCelulas(largura, altura);
        }

        private static Celula[][] CriarCelulas(int largura, int altura)
        {
            var celulas = new Celula[largura][];
            for (var coluna = 0; coluna < largura; coluna++)
            {
                Celula celulaCima = null;
                celulas[coluna] = new Celula[altura];
                for (var linha = 0; linha < altura; linha++)
                {
                    var celula = new Celula();
                    celulas[coluna][linha] = celula;

                    var celulaEsquerda = ObterCelula(celulas, coluna - 1, linha);
                    celula.AssociaCelulas(celulaEsquerda, celulaCima);
                    celulaCima = celula;
                }
            }
            return celulas;
        }

        private static Celula ObterCelula(Celula[][] celulas, int x, int y)
        {
            try
            {
                return celulas[x][y];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        public Celula ObterCelula(int x, int y)
        {
            return ObterCelula(Celulas, x, y);
        }

        public void ExecutarProximoPasso()
        {
            var celulasNovas = CriarCelulas(_largura, _altura);
            for (var coluna = 0; coluna < _largura; coluna++)
            {
                for (var linha = 0; linha < _altura; linha++)
                {
                    celulasNovas[coluna][linha].Viva = Celulas[coluna][linha].ProximoPasso();
                }
            }
            Celulas = celulasNovas;
        }
    }
}