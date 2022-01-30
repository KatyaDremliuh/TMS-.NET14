using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceString = "1+2*(3+4/2-(1+2))*2+1";
            Calculate(sourceString);
        }

        private static void Calculate(string mathExpression)
        {
            Stack<double> numbers = new();
            Stack<char> operations = new();

            foreach (char sign in mathExpression)
            {
                if (char.IsNumber(sign))
                {
                    numbers.Push((int)char.GetNumericValue(sign));
                    continue;
                }

                if (operations.Count == 0 && IsMathOperation(sign))
                {
                    operations.Push(sign);
                    continue;
                }

                if (IsMathOperation(sign))
                {
                    char theLastOperation = operations.Peek();

                    if ((FindOutPriorityOfOperation(theLastOperation) < FindOutPriorityOfOperation(sign))
                        || IsBracket(theLastOperation))
                    {
                        operations.Push(sign);
                    }
                    else if (FindOutPriorityOfOperation(theLastOperation) > FindOutPriorityOfOperation(sign))
                    {
                        double theLastNumber = TakeTheLastNumber(numbers);
                        numbers.Pop();
                        double secondToTheLastNumber = TakeTheLastNumber(numbers);
                        numbers.Pop();
                        theLastOperation = TakeTheLastMathOperator(operations);
                        double result = MakeCalculation(secondToTheLastNumber, theLastNumber, theLastOperation);
                        operations.Pop();
                        numbers.Push(result);
                    }
                    else
                    {
                        if (FindOutPriorityOfOperation(theLastOperation) == FindOutPriorityOfOperation(sign))
                        {
                            double theLastNumber = TakeTheLastNumber(numbers);
                            numbers.Pop();
                            double secondToTheLastNumber = TakeTheLastNumber(numbers);
                            numbers.Pop();
                            theLastOperation = TakeTheLastMathOperator(operations);
                            double result = MakeCalculation(secondToTheLastNumber, theLastNumber, theLastOperation);
                            operations.Pop();
                            numbers.Push(result);
                        }
                    }

                    continue;
                }

                if (IsBracket(sign))
                {
                    char lastOperation = operations.Peek();

                    if (!IsBracket(lastOperation))
                    {
                        operations.Push(sign);
                    }
                }

            }

            foreach (double number in numbers)
            {
                Console.WriteLine(Convert.ToDouble(number));
            }

            foreach (char operation in operations)
            {
                Console.WriteLine(operation);
            }

        }

        private static int FindOutPriorityOfOperation(char currentSign)
        {
            int priority = currentSign switch
            {
                '+' => 1,
                '-' => 1,
                '*' => 2,
                '/' => 2,
                _ => 0
            };

            return priority;
        }

        private static bool IsMathOperation(char currentSign)
        {
            return currentSign is '+' or '-' or '*' or '/';
        }

        private static bool IsBracket(char currentSign)
        {
            return currentSign is '(' or ')';
        }

        private static double TakeTheLastNumber(Stack<double> numbers)
        {
            return numbers.Peek();
        }

        private static char TakeTheLastMathOperator(Stack<char> operations)
        {
            return operations.Peek();
        }

        public static double MakeCalculation(double firstNumber, double secondNumber, char mathSigh)
        {
            double resultOfMathOperation = mathSigh switch
            {
                '+' => Addition(firstNumber, secondNumber),
                '-' => Subtraction(firstNumber, secondNumber),
                '*' => Multiplication(firstNumber, secondNumber),
                '/' => Division(firstNumber, secondNumber),
                _ => 0
            };

            return resultOfMathOperation;
        }

        private static double Addition(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        private static double Subtraction(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
        private static double Multiplication(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        private static double Division(double firstNumber, double secondNumber)
        {
            double result = 0d;
            try
            {
                result = firstNumber / secondNumber;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("U can not divide by zero.");
            }

            return result;
        }
    }
}
