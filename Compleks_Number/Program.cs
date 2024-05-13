using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compleks_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите 1 комплексное число");
            string input = Console.ReadLine();

            input = input.Replace(" ", "");
            string[] parts = input.Split('+', 'i');

            double realPart = double.Parse(parts[0]);
            double imaginaryPart = double.Parse(parts[1]);

            Console.WriteLine("Введите 2 комплексное число");
            string input2 = Console.ReadLine();

            input2 = input2.Replace(" ", "");
            string[] part = input2.Split('+', 'i');

            double realPart2 = double.Parse(part[0]);
            double imaginaryPart2 = double.Parse(part[1]);

            ComplexNumber num1 = new ComplexNumber(realPart, imaginaryPart);
            ComplexNumber num2 = new ComplexNumber(realPart2, imaginaryPart2);

            ComplexNumber.Add(num1, num2);

            ComplexNumber.Subtraction(num1, num2);

            ComplexNumber.Multiplication(num1, num2);

            ComplexNumber.Division(num1, num2);

            Console.Read();
        }
    }

    public class ComplexNumber
    {
        private double real;
        private double ratio;

        public ComplexNumber(double real, double ratio)
        {
            this.real = real;
            this.ratio = ratio;
        }

        public static void Add(ComplexNumber num1, ComplexNumber num2)
        {
            Print(num1.real + num2.real, num1.ratio + num2.ratio); 
        }

        public static void Subtraction(ComplexNumber num1, ComplexNumber num2)
        {
            Print(num1.real - num2.real, num1.ratio - num2.ratio);
        }

        public static void Multiplication(ComplexNumber num1, ComplexNumber num2)
        {
            Print(num1.real * num2.real - num1.ratio * num2.ratio, num1.real * num2.ratio + num1.ratio * num2.real);
        }

        public static void Division(ComplexNumber num1, ComplexNumber num2)
        {
            double denominator = Math.Pow(num2.real, 2) + Math.Pow(num2.ratio, 2);

            if (denominator == 0)
            {
                throw new DivideByZeroException("Деление на ноль невозможно");
            }

            Print((num1.real * num2.real + num1.ratio * num2.ratio) / denominator, (num1.ratio * num2.real - num1.real * num2.ratio) / denominator);
        }

        public static void Print(double real, double ratio)
        {
            if (ratio == 0)
            {
                Console.WriteLine(real);
            }
            else if (ratio > 0)
            {
                Console.WriteLine($"{real}+{ratio}i");
            }
            else
            {
                Console.WriteLine($"{real}{ratio}i");
            }
        }
    }
}
