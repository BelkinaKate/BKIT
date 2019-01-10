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
            Type t = typeof(Class1);
            Console.WriteLine("\nИнформация о типе:");
            Console.WriteLine("Тип " + t.FullName + " унаследован от " + t.BaseType.FullName);
            Console.WriteLine("Пространство имен " + t.Namespace);
            Console.WriteLine("Находится в сборке " + t.AssemblyQualifiedName);
            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nПоля данных (public):");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }

            //Properties with attributes
            Console.WriteLine("\nСвойства(С атрибутом):");
            foreach (var x in t.GetProperties())
            {
                if (Attribute.IsDefined(x, typeof(NewAttribute)))
                {
                    Console.WriteLine(x);
                }
            }

            Console.WriteLine("\nВызов метода Plus:");
            Console.WriteLine(t.GetMethod("Plus").Invoke(new Class1(), new object[] { 10, 20 }));

            Console.Read();
        }
    }
}
