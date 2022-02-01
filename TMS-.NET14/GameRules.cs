using System;
using System.Collections.Generic;

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
                numberPuzzle = InputValidNumber();
            }

            NumberPuzzle = numberPuzzle;
            return NumberPuzzle;
        }

        private int InputValidNumber()
        {
            int number;
            do
            {
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    break;
                }

                Console.WriteLine("Try again. Input only a number: ");
            }
            while (true);

            return number;
        }

        public int InputValidNumber(string message)
        {
            Console.Write(message);

            return InputValidNumber();
        }

        public bool IsUserAnIdiot(int userInputNumber, List<int> usersPreviosAttempts)
        {
            return usersPreviosAttempts.Contains(userInputNumber);
        }

        public bool IsUserTryANumberOutOfBounds(int userInputNumber, int min, int max)
        {
            if (userInputNumber < min || userInputNumber > max)
            {
                return true;
            }

            return false;
        }
    }
}
