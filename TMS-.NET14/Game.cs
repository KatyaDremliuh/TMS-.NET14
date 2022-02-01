using System;
using System.Collections.Generic;

namespace TMS_.NET14
{
    class Game
    {
        private GameRules _rules = new();
        private readonly List<int> _usersAttempts = new();
        private int _currentAttempt;
        private int NumberThatIsGuessed { get; set; }

        public void FirstPlayer()
        {
            Greeting("first", new User());

            int min = _rules.InputValidNumber("Input MIN number: ");
            int max = _rules.InputValidNumber("Input MAX number: ");
            int numberPuzzle = _rules.InputValidNumber("Input a number number to guess: ");

            SwapMinMax(min, max, out int newMin, out int newMax);
            int attemptsCountBeforeLosing = CalculateAttemptsCount(newMin, newMax);

            _rules = new GameRules()
            {
                Min = newMin,
                Max = newMax,
                NumberPuzzle = numberPuzzle,
                AttemptsCountBeforeLosing = attemptsCountBeforeLosing
            };

            _rules.CheckNumberPuzzle(_rules.Min, _rules.Max, _rules.NumberPuzzle);

            Console.Clear();
        }

        public void SecondPlayer()
        {
            Greeting("second", new User());

            do
            {
                SecondPlayerTryToGuess();
            }
            while ((NumberThatIsGuessed != _rules.NumberPuzzle) && (_currentAttempt != _rules.AttemptsCountBeforeLosing));

            CheckOnTheGameResult();
        }

        private void SecondPlayerTryToGuess()
        {
            _currentAttempt++;

            do
            {
                NumberThatIsGuessed =
              _rules.InputValidNumber($"Attempt: {_currentAttempt}/{_rules.AttemptsCountBeforeLosing}. " +
                           $"Guess the number btw [{_rules.Min}, {_rules.Max}]: "); // swap

                if (_rules.IsUserAnIdiot(NumberThatIsGuessed, _usersAttempts))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("U've already mentioned this number. Choose another one.\n");
                    Console.ResetColor();
                    continue;
                }

                if (_rules.IsUserTryANumberOutOfBounds(NumberThatIsGuessed, _rules.Min, _rules.Max))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("U can not input a number out of bounds. Choose another one.\n");
                    Console.ResetColor();
                    continue;
                }

                break;
            }
            while ((_rules.IsUserAnIdiot(NumberThatIsGuessed, _usersAttempts))
                   || (_rules.IsUserTryANumberOutOfBounds(NumberThatIsGuessed, _rules.Min, _rules.Max)));

            _usersAttempts.Add(NumberThatIsGuessed);

            if (_rules.NumberPuzzle > NumberThatIsGuessed) // 1 - 10 (5) => 7
            {
                Console.WriteLine("\u2191"); // need more
                _rules.Min = NumberThatIsGuessed++;
                NumberThatIsGuessed--;
            }
            else if (_rules.NumberPuzzle < NumberThatIsGuessed)
            {
                Console.WriteLine("\u2193"); // need less
                _rules.Max = NumberThatIsGuessed--;
                NumberThatIsGuessed++;
            }
        }

        private void Greeting(string player, User user)
        {
            Console.Write($"Input Ur name, {player} player: ");
            user.Name = Console.ReadLine();
            Console.WriteLine($"Hi, {user.Name}");
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

        private void CheckOnTheGameResult()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(NumberThatIsGuessed == _rules.NumberPuzzle
                ? "Сongrats! UR a winner!"
                : $"UR a looser :(. U've used more than {_rules.AttemptsCountBeforeLosing} available attempts. The answer was: {_rules.NumberPuzzle}");

            foreach (int shot in _usersAttempts)
            {
                Console.Write(new string(string.Join(',', shot)));
            }

            Console.ResetColor();
        }
    }
}
