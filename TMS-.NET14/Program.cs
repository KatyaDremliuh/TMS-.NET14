using System;

namespace TMS_.NET14
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new();
            game.FirstPlayer();
            game.SecondPlayer();

            //Calculator calculator = new Calculator();
            //calculator.GetSourceData();
            //calculator.Calculate('+');
        }
    }
}

