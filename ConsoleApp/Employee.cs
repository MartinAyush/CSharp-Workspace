using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Interfaces;

namespace TestApplication
{
    class Employee : IEmployee
    {
        private int _salary;
        private int _empId;
        public int Salary { get; set; }
        public int EmployeeId { get; set; }

        public Employee(int empId, int salary)
        {
            this._empId = empId;
            this._salary = salary;
        }

        public string EmployeeSalary()
        {
            return $"Employee : {_empId} with salary : {_salary}.";
        }
    }
}
