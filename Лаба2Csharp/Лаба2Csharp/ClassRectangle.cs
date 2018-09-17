using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Csharp
{
    class Rectangle : GeomFigure, IPrint
    {
        public Rectangle(double high, double width)
        {
            this.High = high;
            this.Width = width;
        }
        public double High { get; set; }
        public double Width { get; set; }

        public override double CountArea()
        {
            return High * Width;
        }

        public override string ToString()
        {
            return "Прямоугольник со сторонами " + this.High + " и " + this.Width + ". Площадью " + this.CountArea().ToString() + "\n";
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
