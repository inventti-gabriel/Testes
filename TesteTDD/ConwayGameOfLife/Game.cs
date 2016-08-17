using System;

namespace ConwayGameOfLife
{
    public class Game
    {
        public string ProximoPasso(string anterior)
        {
            var linhas = anterior.Split('\n');
            var linhasNovas = new string[linhas.Length];
            for (var l = 0; l < linhas.Length; l++)
            {
                var linhaNova = "";
                for (var c = 0; c < linhas[l].Length; c++)
                {
                    var vizinhos = 0;
                    var incrementa = new Action<bool>(possueVizinho =>
                    {
                        if (possueVizinho)
                        {
                            vizinhos ++;
                        }
                    });

                    var temCima = l > 1;
                    var temBaixo= l < linhas.Length - 1;
                    var temEsquerda= c > 0;
                    var temDireita = c < linhas[l].Length - 1;

                    incrementa(temCima && Vivo(linhas[l - 1][c]));
                    incrementa(temBaixo && Vivo(linhas[l + 1][c]));
                    incrementa(temEsquerda && Vivo(linhas[l][c - 1]));
                    incrementa(temDireita && Vivo(linhas[l][c + 1]));

                    incrementa(temEsquerda && temCima && Vivo(linhas[l - 1][c - 1]));
                    incrementa(temDireita && temCima && Vivo(linhas[l - 1][c + 1]));
                    incrementa(temEsquerda && temBaixo && Vivo(linhas[l + 1][c - 1]));
                    incrementa(temDireita && temBaixo && Vivo(linhas[l + 1][c + 1]));

                    var novoEstado = ' ';
                    if (vizinhos == 3)
                    {
                        novoEstado = 'X';
                    }
                    else if (vizinhos == 2 && Vivo(linhas[l][c]))
                    {
                        novoEstado = 'X';
                    }
                    linhaNova += novoEstado;
                }
                linhasNovas[l] = linhaNova;
            }
            return string.Join("\n", linhasNovas);
        }

        private bool Vivo(char c)
        {
            return c == 'X';
        }
    }
}
