using System;
using System.Collections.Generic;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringsWithBrackets = { "({}[])(({})[])", "{[}]", "[[[)))"}; // Correct, Incorrect, Incorrect

            foreach (string stringWithBrackets in stringsWithBrackets)
            {
                Console.WriteLine(CheckPairs(stringWithBrackets)
                    ? $"{stringWithBrackets} -> Correct"
                    : $"{stringWithBrackets} -> Incorrect");
            }
        }

        private static bool CheckPairs(string sourceString)
        {
            // Push: добавляет элемент в стек в верхушку стека
            // Pop: извлекает и возвращает первый элемент из стека

            const string rule = "([{)]}";

            Stack<char> stack = new();

            foreach (char currentBracket in sourceString)
            {
                int indexInRule = rule.IndexOf(currentBracket);

                if (indexInRule >= 0 && indexInRule <= 2) // opened
                {
                    stack.Push(currentBracket);
                }

                if (indexInRule > 2) // closed
                {
                    if (stack.Count == 0 || stack.Pop() != rule[indexInRule - 3])
                    {
                        return false;
                    }
                }
            }

            if (stack.Count != 0)
            {
                return false;
            }

            return true;
        }
    }
}
