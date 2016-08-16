using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculadora.Library
{
    public class Calculadora
    {
        public int Adicionar(string numeros)
        {
            var numerosSoma = ResolveNumeros(numeros);

            return SomaNormal(numerosSoma);
            //return SomaLinq(numerosSoma);
        }

        private int SomaNormal(int[] numerosSoma)
        {
            var soma = 0;
            IList<int> negativos = new List<int>();
            foreach (var numero in numerosSoma)
            {
                if (numero < 0)
                {
                    negativos.Add(numero);
                }
                if (numero <= 1000)
                {
                    soma += numero;
                }
            }

            if (negativos.Count > 0)
            {
                throw new ArgumentException("Negativos não permitidos: " + string.Join(", ", negativos));
            }
            return soma;
        }

        private int SomaLinq(int[] numerosSoma)
        {
            var negativos = numerosSoma.Where(d => d < 0).ToArray();
            if (negativos.Length > 0)
            {
                throw new ArgumentException("Negativos não permitidos: " + string.Join(", ", negativos));
            }
            return numerosSoma.Where(d => d <= 1000).Sum();
        }

        private int[] ResolveNumeros(string numeros)
        {
            string[] delimitadores = { ",", "\n" };
            var matchDelimitador = Regex.Match(numeros, "//(.|\\[.+\\])\n(.*)");

            if (matchDelimitador.Success)
            {
                var delimitador = matchDelimitador.Groups[1].Value;
                if (delimitador.Length > 1)
                {
                    delimitadores = delimitador.Substring(1, delimitador.Length - 2)
                        .Split(new[] { "][" }, StringSplitOptions.None);
                }
                else
                {
                    delimitadores = new[] { delimitador };
                }
                numeros = matchDelimitador.Groups[2].Value;
            }
            if (numeros.Length == 0)
            {
                return new int[0];
            }
            return numeros.Split(delimitadores, StringSplitOptions.None).Select(int.Parse).ToArray();
        }
    }
}
