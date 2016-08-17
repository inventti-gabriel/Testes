using System.Linq;

namespace ConwayGameOfLife
{
    public class Celula
    {
        public Celula Direita { get; private set; }
        public Celula Esquerda { get; private set; }
        public Celula Cima { get; private set; }
        public Celula Baixo { get; private set; }
        public Celula EsquerdaCima => Esquerda != null && Cima != null ? Esquerda.Cima : null;
        public Celula EsquerdaBaixo => Esquerda != null && Baixo != null ? Esquerda.Baixo : null;
        public Celula DireitaCima => Direita != null && Cima != null ? Direita.Cima : null;
        public Celula DireitaBaixo => Direita != null && Baixo != null ? Direita.Baixo : null;

        private Celula[] Vizinhos => new[] { Direita, Esquerda, Cima, Baixo, EsquerdaCima, EsquerdaBaixo, DireitaCima, DireitaBaixo };

        public bool Viva { get; set; }

        public bool ProximoPasso()
        {
            var vizinhosVivos = VizinhosVivos();
            if (vizinhosVivos == 3)
            {
                return true;
            }
            if (vizinhosVivos == 2 && Viva)
            {
                return true;
            }
            return false;
        }

        internal void AssociaCelulas(Celula celulaEsquerda, Celula celulaCima)
        {
            AssociaEsquerda(celulaEsquerda);
            AssociaCima(celulaCima);
        }

        private void AssociaEsquerda(Celula celulaEsquerda)
        {
            if (celulaEsquerda != null)
            {
                celulaEsquerda.Direita = this;
                Esquerda = celulaEsquerda;
            }
        }

        private void AssociaCima(Celula celulaCima)
        {
            if (celulaCima != null)
            {
                celulaCima.Baixo = this;
                Cima = celulaCima;
            }
        }

        private int VizinhosVivos()
        {
            return Vizinhos.Count(d => d != null && d.Viva);
        }
    }
}