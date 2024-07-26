using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces
{
    interface IEmployee
    {
        int Salary { get; set; }
        int EmployeeId { get; set; }

        string EmployeeSalary();

    }
}
