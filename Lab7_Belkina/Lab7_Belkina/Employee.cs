using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Belkina
{
    class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public int DepartmentId { get; set; }

        public Employee() { }
        public Employee(int id, string surname, int departmentId)
        {
            Id = id;
            Surname = surname;
            DepartmentId = departmentId;
        }

        public override string ToString()
        {
            return "Id = " + Id + "; Surname = " + Surname + "; Department Id = " + DepartmentId;
        }
    }
}
