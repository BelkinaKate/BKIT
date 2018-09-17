using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Csharp
{
    class Circle : GeomFigure, IPrint
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; set; }

        public override double CountArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override string ToString()
        {
            return "Круг радиуса " + this.Radius + ". Площадью " + this.CountArea().ToString() + "\n";
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
