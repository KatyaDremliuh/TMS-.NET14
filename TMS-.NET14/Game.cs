using System;
using System.Collections.Generic;
using System.Text;

namespace TMS_.NET14
{
    class Game
    {
        private GameRules Rules { get; set; }
        private readonly List<int> _usersAttempts = new();
        private int CurrentAttempt { get; set; }
        private int NumberThatIsGuessed { get; set; }

        public void FirstPlayer()
        {
            // First player
            Greeting("first", new User());
       
            
            int min = InputNumber("Input MIN number: ");
            int max = InputNumber("Input MAX number: ");
            int numberPuzzle = InputNumber("Input a number number to guess: ");

            SwapMinMax(min, max, out int newMin, out int newMax);
            int attemptsCountBeforeLosing = CalculateAttemptsCount(newMin, newMax);

            Rules = new GameRules()
            {
                Min = newMin,
                Max = newMax,
                NumberPuzzle = numberPuzzle,
                AttemptsCountBeforeLosing = attemptsCountBeforeLosing
            };

            Console.Clear();
        }

        public void SecondPlayer()
        {
            Greeting("second", new User());

            do
            {
                SecondPlayerTryToGuess();
            }
            while (NumberThatIsGuessed != Rules.NumberPuzzle);

            CheckOnTheGameResult();
        }

        private void SecondPlayerTryToGuess()
        {

            NumberThatIsGuessed =
                InputNumber($"Attempt: {CurrentAttempt}/{Rules.AttemptsCountBeforeLosing}. " +
                            $"Guess the number btw [{Rules.Min}, {Rules.Max}]: "); // swap

            _usersAttempts.Add(NumberThatIsGuessed);

            Console.WriteLine((Rules.NumberPuzzle > NumberThatIsGuessed) ? "\u2191" : "\u2193");

            CurrentAttempt++;
        }

        private void CheckOnTheGameResult()
        {
            Console.WriteLine(NumberThatIsGuessed == Rules.NumberPuzzle
                ? "Сongrats! UR a winner!"
                : $"UR a looser :(\n. U've used more than {Rules.AttemptsCountBeforeLosing}.");

            StringBuilder finalResult = new();
            foreach (int shot in _usersAttempts)
            {
                finalResult.Append(shot + ", ");
            }

            Console.WriteLine(finalResult.ToString()[..(finalResult.ToString().Length - 2)]);
        }

        private void Greeting(string player, User user)
        {
            Console.Write($"Input Ur name, {player} player: ");
            user.Name = Console.ReadLine();
            Console.WriteLine($"Hi, {user.Name}");
        }

        private int InputNumber(string message)
        {
            Console.Write(message);
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

        private void SwapMinMax(int min, int max, out int newMin, out int newMax)
        {
            if (min > max)
            {
                int temp = min;
                min = max;
                max = temp;
            }

            newMin = min;
            newMax = max;
        }

        private int CalculateAttemptsCount(int min, int max)
        {
            int lenght = max - min;

            int availableAttempts = 1;
            int maxLength = 1;

            while (maxLength < lenght)
            {
                availableAttempts++;
                maxLength *= 2;
            }

            return availableAttempts;
        }
    }
}
