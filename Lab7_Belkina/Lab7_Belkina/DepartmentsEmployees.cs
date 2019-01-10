using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Belkina
{
    class DepartmentsEmployees
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }

        public DepartmentsEmployees(){ }

        public DepartmentsEmployees(int employeeId, int departmentId)
        {
            EmployeeId = employeeId;
            DepartmentId = departmentId;
        }

        public override string ToString()
        {
            return "Employee ID = " + EmployeeId + "; Department ID = " + DepartmentId;
        }
    }
}
