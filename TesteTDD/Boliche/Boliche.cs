using System.Collections.Generic;

namespace BolicheGame
{
    public class Boliche
    {
        private IList<int> _roladas;

        public Boliche()
        {
            _roladas = new List<int>(22);
        }

        public void Rolar(int pinos)
        {
            _roladas.Add(pinos);
        }

        public int Pontuacao
        {
            get
            {
                var pontuacao = 0;

                var roladaIndice = 0;
                for (var jogada = 0; jogada < _roladas.Count / 2; jogada ++)
                {
                    pontuacao += _roladas[roladaIndice] + _roladas[roladaIndice + 1];

                    if (EhStrike(roladaIndice))
                    {
                        pontuacao += _roladas[roladaIndice + 2];
                        roladaIndice += 1;
                    }
                    else
                    {
                        if (EhSpare(roladaIndice))
                        {
                            pontuacao += _roladas[roladaIndice + 2];
                        }
                        roladaIndice += 2;
                    }
                }


                return pontuacao;
            }
        }

        private bool EhStrike(int roladaIndice)
        {
            return _roladas[roladaIndice] == 10;
        }

        private bool EhSpare(int roladaIndice)
        {
            return _roladas[roladaIndice] + _roladas[roladaIndice + 1] == 10;
        }
    }
}