using System;
using System.Collections.Generic;
using System.Text;

namespace Brackets
{
    class BracketsPairs
    {
        private string Brackets { get; set; }

        /*
         * ({}[])(({})[]) - Correct
         * {[}] - Incorrect
         * [[[))) - Incorrect
         */

        public void CountBracketPairs()
        {
            GetUsersInput();
            CutIrrelevantChars();

            Console.WriteLine(
                CheckPairs(Brackets)
                    ? $"{Brackets} -> Correct" : $"{Brackets} -> Incorrect");
        }

        private void GetUsersInput()
        {
            Console.Write("Input string: ");
            Brackets = Console.ReadLine().Trim();
        }

        private void CutIrrelevantChars()
        {
            StringBuilder validString = new();

            foreach (char charBracket in Brackets)
            {
                if (IsBracket(charBracket))
                {
                    validString.Append(charBracket);
                }
            }

            Brackets = validString.ToString();
        }

        private bool IsBracket(char anySign)
        {
            return anySign is ')' or '(' or '[' or ']' or '{' or '}';
        }

        private bool CheckPairs(string sourceString)
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
