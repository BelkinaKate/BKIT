using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Belkina
{
    delegate double PlusOrMinus(int p1, double p2);
    class Program
    {
        static void Main(string[] args)
        {
            ApplyToConsole(Plus);
            ApplyToConsole(delegate (int p1, double p2) { return p1 - p2; });

            ApplyToConsoleViaFunc(Plus);
            ApplyToConsoleViaFunc(delegate (int p1, double p2) { return p1 - p2; });

            Console.Read();
        }

        static double Plus(int p1, double p2)
        {
            return p1 + p2;
        }
        static void ApplyToConsole(PlusOrMinus func)
        {
            Console.WriteLine(func(10, 24.3));
        }

        static void ApplyToConsoleViaFunc(Func<int, double, double> func)
        {
            Console.WriteLine(func(10, 24.3));
        } 
    }
}
