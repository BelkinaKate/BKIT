using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2Csharp
{
    class Square : Rectangle, IPrint
    {
        public Square(double size) : base(size, size) { }
        public override string ToString()
        {
            return "Квадрат со стороной " + this.High + ". Площадью " + this.CountArea().ToString() + "\n";
        }
    }
}
