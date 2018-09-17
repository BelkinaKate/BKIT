using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give a coefficient A");
            double a = GetCoef();
            Console.WriteLine("Your A is " + a);

            Console.WriteLine("Give a coefficient B");
            double b = GetCoef();
            Console.WriteLine("Your B is " + b);

            Console.WriteLine("Give a coefficient C");
            double c = GetCoef();
            Console.WriteLine("Your C is " + c);

            double D = CountDiscriminant(a, b, c);
            Console.WriteLine("Discriminant is " + D);

            double[] X = new double[2];
            if (D >= 0)
            {
                X = CountNotComplexX(b, D);
                Console.WriteLine("Counted X1 is " + X[0]);
                Console.WriteLine("Counted X2 is " + X[1]);
            }
            else
            {
                Console.WriteLine("Counted X1 is " + -b / 2 + -Math.Sqrt(-D) / 2 + "i");
                Console.WriteLine("Counted X2 is " + -b / 2 + "+" + Math.Sqrt(-D) / 2 + "i");
            }

            Console.Read();
        }

        static double GetCoef()
        {
            double coef;
            try
            {
                coef = Convert.ToDouble(Console.ReadLine());
                return coef;
            }

            catch (FormatException)
            {
                Console.WriteLine("There is a format exception. Try again");
                return GetCoef();
            }
        }

        static double CountDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }

        static double[] CountNotComplexX(double b, double d)
        {
            double[] X = new double[2];
            X[0] = -b / 2 - Math.Sqrt(d) / 2;
            X[1] = -b / 2 + Math.Sqrt(d) / 2;
            return X;
        }
    }
}
