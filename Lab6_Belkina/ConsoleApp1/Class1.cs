using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class1 
    {
        //Constructors
        public Class1() { }
        public Class1(int p) { }
        public Class1(string s) { }

        //Methods
        public int Plus(int x, int y) { return x + y; }
        public int Minus(int x, int y) { return x - y; }

        //Properties
        [NewAttribute("Описание для property1")]
        public string Property1 { get; set; }
        public int Property2 { get; set; }
        [NewAttribute(Description = "Описание для property3")]
        public double Property3 { get; private set; }

        //Fields
        public int p1;
        public float p2;
        
        
    }
}
