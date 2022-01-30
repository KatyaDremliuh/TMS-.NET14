using System;
using System.Collections.Generic;
using System.Text;

namespace Calc2
{
    public class ReversePolishNotation
    {
        // Calculate — метод общедоступный, ему будет передаваться выражение в виде строки,
        // и он будет возвращать результат вычисления. Результат он будет получать используя другие методы.
        public static double Calculate(string input)
        {
            string output = GetExpression(input); //Преобразовываем выражение в постфиксную запись
            double result = Counting(output); //Решаем полученное выражение
            return result; //Возвращаем результат
        }

        //Метод, преобразующий входную строку с выражением в постфиксную запись
        //GetExpression — метод, которому основной метод Calculate будет передавать выражение,
        //и получать его уже в постфиксной записи.
        private static string GetExpression(string input)
        {
            StringBuilder output = new(); //Строка для хранения выражения
            Stack<char> operStack = new(); //Стек для хранения операторов

            for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
            {
                //Разделители пропускаем
                if (IsDelimeter(input[i]))
                    continue; //Переходим к следующему символу

                //Если символ - цифра, то считываем все число
                if (char.IsDigit(input[i])) //Если цифра
                {
                    //Читаем до разделителя или оператора, что бы получить число
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output.Append(input[i]); //Добавляем каждую цифру числа к нашей строке
                        i++; //Переходим к следующему символу

                        if (i == input.Length) break; //Если символ - последний, то выходим из цикла
                    }

                    output.Append(' '); //Дописываем после числа пробел в строку с выражением
                    i--; //Возвращаемся на один символ назад, к символу перед разделителем
                }

                //Если символ - оператор
                if (IsOperator(input[i])) //Если оператор
                {
                    if (input[i] == '(') //Если символ - открывающая скобка
                    {
                        operStack.Push(input[i]); //Записываем её в стек
                    }
                    else if (input[i] == ')') //Если символ - закрывающая скобка
                    {
                        //Выписываем все операторы до открывающей скобки в строку
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output.Append(s.ToString() + ' ');
                            s = operStack.Pop();
                        }
                    }
                    else //Если любой другой оператор
                    {
                        if (operStack.Count > 0) //Если в стеке есть элементы
                        {
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                            {
                                output.Append(operStack.Pop() + " "); //То добавляем последний оператор из стека в строку с выражением
                            }
                        }

                        operStack.Push(char.Parse(input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека
                    }
                }
            }

            //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
            while (operStack.Count > 0)
            {
                output.Append(operStack.Pop() + " ");
            }

            return output.ToString(); //Возвращаем выражение в постфиксной записи
        }

        //Метод, вычисляющий значение выражения, уже преобразованного в постфиксную запись
        //Counting — метод, который получая постфиксную запись выражения будет вычислять его результат.
        private static double Counting(string input)
        {
            double result = 0; //Результат
            Stack<double> temp = new(); //Dhtvtyysq стек для решения

            for (int i = 0; i < input.Length; i++) //Для каждого символа в строке
            {
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                if (char.IsDigit(input[i]))
                {
                    StringBuilder a = new();

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
                    {
                        a.Append( input[i]); //Добавляем
                        i++;
                        if (i == input.Length)
                        {
                            break;
                        }
                    }
                    temp.Push(double.Parse(a.ToString())); //Записываем в стек
                    i--;
                }
                else if (IsOperator(input[i])) //Если символ - оператор
                {
                    //Берем два последних значения из стека
                    double a = temp.Pop();
                    double b = temp.Pop();

                    result = input[i] switch //И производим над ними действие, согласно оператору
                    {
                        '+' => b + a,
                        '-' => b - a,
                        '*' => b * a,
                        '/' => b / a,
                        '^' => double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()),
                        _ => result
                    };
                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
            }
            return temp.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
        }

        //IsDelimeter — возвращает true, если проверяемый символ — разделитель ("пробел" или "равно")
        private static bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
            {
                return true;
            }

            return false;
        }

        //    IsOperator — возвращает true, если проверяемый символ — оператор
        private static bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
            {
                return true;
            }

            return false;
        }

        //GetPriority — метод возвращает приоритет проверяемого оператора, нужно для сортировки операторов
        private static byte GetPriority(char s)
        {
            return s switch
            {
                '(' => 0,
                ')' => 1,
                '+' => 2,
                '-' => 3,
                '*' => 4,
                '/' => 4,
                '^' => 5,
                _ => 6
            };
        }
    }
}
