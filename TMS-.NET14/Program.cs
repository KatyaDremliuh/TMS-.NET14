using System;
using System.Collections.Generic;
using System.Text;

namespace TMS_.NET14
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeting("first", out _);
            Greeting("second", out string name);

            Console.Clear();

            // First player
            int min = InputNumber("Input MIN number: ");
            int max = InputNumber("Input MAX number: ");
            int numberPuzzle = InputNumber("Input a number number to guess: ");

            SwapMinMax(min, max, out int newMin, out int newMax);
            int attemptsCountBeforeLosing = CalculateAttemptsCount(newMin, newMax);

            Console.Clear();

            // Second player
            List<int> usersAttempts = new();

            int attempt = 0;

            int numberThatIsGuessed = InputNumber($"{name} inputs...");

            while (numberThatIsGuessed != numberPuzzle)
            {
                usersAttempts.Add(numberThatIsGuessed);

                Console.WriteLine((numberPuzzle > numberThatIsGuessed) ? "\u2191" : "\u2193");

                attempt++;

                if (attempt >= attemptsCountBeforeLosing)
                {
                    Console.WriteLine($"UR a looser. U've used more than {attemptsCountBeforeLosing}");
                    break;
                }

                numberThatIsGuessed =
                    InputNumber($"Attempt: {attempt}/{attemptsCountBeforeLosing}. Guess the number btw [{newMin}, {newMax}]: ");
            }

            if (numberThatIsGuessed == numberPuzzle)
            {
                Console.WriteLine("UR a winner!");
            }

            StringBuilder finalResult = new();
            foreach (int shot in usersAttempts)
            {
                finalResult.Append(shot + ", ");
            }

            Console.WriteLine(finalResult.ToString()[..(finalResult.ToString().Length - 2)]);
        }

        private static int CalculateAttemptsCount(int min, int max)
        {
            int lenght = max - min;

            int attempt = 1;
            int maxLength = 1;

            while (maxLength < lenght)
            {
                attempt++;
                maxLength *= 2;
            }

            return attempt;
        }

        private static int InputNumber(string message)
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

        private static void Greeting(string player, out string name)
        {
            Console.Write($"Input Ur name, {player} player: ");
            name = Console.ReadLine();
            Console.WriteLine($"Hi, {name}");
        }

        private static void SwapMinMax(int min, int max, out int newMin, out int newMax)
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
    }
}

