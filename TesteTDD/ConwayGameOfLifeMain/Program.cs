using System;
using System.Threading;
using ConwayGameOfLife;

namespace ConwayGameOfLifeMain
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var form = "\n" +
                "           \n" +
                "   XX      \n" +
                " XX XX     \n" +
                " XXXX      \n" +
                "  XX       \n" +
                "           ";
            while (true)
            {
                Console.Write(form);
                form = game.ProximoPasso(form);
                Thread.Sleep(1000);
            }
        }
    }
}
