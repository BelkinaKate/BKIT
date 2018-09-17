using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(6, 3);
            Square square = new Square(3);
            Circle circle = new Circle(4);

            rectangle.Print();
            square.Print();
            circle.Print();

            Console.ReadLine();

        }
    }
}
