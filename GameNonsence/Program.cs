using System;
using System.Collections.Generic;
using System.Text;

namespace GameNonsence
{
    class Program
    {
        static void Main(string[] args)
        {
            GameProcess game = new();

            game.FirstPlayer();
            game.SecondPlayer();
        }
    }
}
