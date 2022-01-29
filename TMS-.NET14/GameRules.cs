using System;

namespace TMS_.NET14
{
    class GameRules
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int NumberPuzzle { get; set; }
        public int AttemptsCountBeforeLosing { get; set; }

        public int CheckNumberPuzzle(int min, int max, int numberPuzzle)
        {
            while (numberPuzzle < min || numberPuzzle > max)
            {
                Console.WriteLine($"Ur mystery number ought to be btw {min} and {max} including.");
                numberPuzzle = InputValidNumberPuzzle();
            }

            NumberPuzzle = numberPuzzle;
            return NumberPuzzle;
        }

        private int InputValidNumberPuzzle()
        {
            int number = 0;

            while (true)
            {
                try
                {
                    string numberString = Console.ReadLine();

                    if (numberString != null)
                    {
                        number = int.Parse(numberString);
                    }

                    break;
                }
                catch (Exception)
                {
                    Console.Write("Try again. Input only a number: ");
                }
            }

            return number;
        }
    }
}
