using System;
using System.Collections.Generic;

namespace Calc2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) //Бесконечный цикл
            {
                Console.Write("Введите выражение: "); //Предлагаем ввести выражение
                Console.WriteLine(ReversePolishNotation.Calculate(Console.ReadLine())); //Считываем, и выводим результат
            }
        }
    }
}
