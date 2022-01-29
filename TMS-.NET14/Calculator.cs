using System;

namespace TMS_.NET14
{
    class Calculator
    {
        private double FirstNumber { get; set; }
        private double SecondNumber { get; set; }
        private char MathSign { get; set; }
        
        public void GetSourceData()
        {
            this.FirstNumber = InputNumber("Input first number: ");
            this.SecondNumber = InputNumber("Input second number: ");
            this.MathSign = InputMathSign("Input math sign: \"+\", \"-\", \"*\", \"\"");
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


        private char InputMathSign(string message)
        {
            char mathSign = default;

            do
            {
                Console.Write(message);
                string inputString = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(inputString) && char.TryParse(inputString, out mathSign) && !IsInvalidMathOperation(inputString))
                {
                    break;
                }

                Console.WriteLine("Gender is not in the correct format. The letters allowed to enter are: \"F(f)\" or \"M(m)\"");
            }
            while (true);

            return mathSign;
        }

        private bool IsInvalidMathOperation(string inputString)
        {
            return !inputString.Equals("+", StringComparison.InvariantCultureIgnoreCase) &&
                   !inputString.Equals("-", StringComparison.InvariantCultureIgnoreCase) &&
                   !inputString.Equals("*", StringComparison.InvariantCultureIgnoreCase) &&
                   !inputString.Equals("/", StringComparison.InvariantCultureIgnoreCase);

        }

        public double Calculate(char mathSigh)
        {
            double resultOfMathOperation = mathSigh switch
            {
                '+' => Addition(),
                '-' => Subtraction(),
                '*' => Multiplication(),
                '/' => Division(),
                _ => 0
            };

            return resultOfMathOperation;
        }

        private double Addition()
        {
            return FirstNumber + SecondNumber;
        }

        private double Subtraction()
        {
            return FirstNumber - SecondNumber;
        }
        private double Multiplication()
        {
            return FirstNumber * SecondNumber;
        }

        private double Division()
        {
            double result = 0d;
            try
            {
                result = FirstNumber / SecondNumber;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("U can not divide by zero.");
            }

            return result;
        }
    }
}
