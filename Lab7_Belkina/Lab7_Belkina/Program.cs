using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Belkina
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new List<Department>
            {
                new Department(1, "Руководство"),
                new Department(2, "Бухгалтерия"),
                new Department(3, "Отдел производства"),
                new Department(4, "Отдел разработки"),
                new Department(5, "Отдел проектирования")
            };

            var employees = new List<Employee>
            {
                new Employee(1, "Амирова", 1),
                new Employee(2, "Ахубекова", 2),
                new Employee(3, "Петров", 2),
                new Employee(4, "Емельяненко", 5),
                new Employee(5, "Коновалов", 4),
                new Employee(6, "Горяев", 3)
            };

            Console.WriteLine("Cписок всех сотрудников и отделов, отсортированный по отделам");

            var list1 =
                from employee in employees
                join department in departments on employee.DepartmentId equals department.Id
                orderby department.Name
                select new
                {
                    employee.Surname,
                    DepartmentName = department.Name
                };

            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();


            Console.WriteLine("Cписок всех сотрудников, у которых фамилия начинается с буквы «А»");

            var list2 =
                from employee in employees
                where employee.Surname[0] == 'А'
                select employee;

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();



            Console.WriteLine("Cписок всех отделов и количество сотрудников в каждом отделе");

            var list3 =
                from department in departments
                join employee in employees on department.Id equals employee.DepartmentId into employeesInDepartment
                select new
                {
                    department.Name,
                    CountOfEmployees = employeesInDepartment.Count()
                };

            foreach (var item in list3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            

            Console.WriteLine("Cписок отделов, в которых у всех сотрудников фамилия начинается с буквы «А»");

            var list4 =
                from department in departments
                join employee in employees on department.Id equals employee.DepartmentId into employeesInDepartment
                where employeesInDepartment.All(employee => employee.Surname[0] == 'А')
                select department;

            foreach (var item in list4)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();



            Console.WriteLine("Cписок отделов, в которых хотя бы у одного сотрудника фамилия начинается с буквы «А»");

            var list5 =
                from department in departments
                join employee in employees on department.Id equals employee.DepartmentId into employeesInDepartment
                where employeesInDepartment.Any(employee => employee.Surname[0] == 'А')
                select department;

            foreach (var item in list5)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var departmentsEmployees = new List<DepartmentsEmployees>
            {
                new DepartmentsEmployees(1,3),
                new DepartmentsEmployees(1,2),
                new DepartmentsEmployees(2,3),
                new DepartmentsEmployees(2,5),
                new DepartmentsEmployees(3,3),
                new DepartmentsEmployees(3,1),
                new DepartmentsEmployees(4,2),
                new DepartmentsEmployees(5,1),
                new DepartmentsEmployees(5,4),
                new DepartmentsEmployees(5,3),
                new DepartmentsEmployees(6,4),
                new DepartmentsEmployees(1,5)
            };

            Console.WriteLine("Cписок всех отделов и список сотрудников в каждом отделе");

            var list6 =
                from de in departmentsEmployees
                group de by de.DepartmentId into deps
                select new
                {
                    Department = departments.Single(dep => dep.Id == deps.Key),
                    Employees = string.Join(", ", employees.FindAll(employee => employee.DepartmentId == deps.Key))
                };

            foreach (var item in list6)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();



            Console.WriteLine("Cписок всех отделов и количество сотрудников в каждом отделе");

            var list7 =
                from de in departmentsEmployees
                group de by de.DepartmentId into deps
                select new
                {
                    Department = departments.Single(dep => dep.Id == deps.Key),
                    EmployeesCount = employees.FindAll(employee => employee.DepartmentId == deps.Key).Count
                };

            foreach (var item in list7)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.Read();
        }
    }
}
