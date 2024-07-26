using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    struct Structures
    {
        // Fields
        private int _id;
        private int _salary;

        // Properties
        public int Id { get; set; }
        public int Salary { get; set; }

        // Do not have default constructor -> Only support parameterized constructor
        public Structures(int id)
        {
            this._id = this.Id = id;
            this._salary = this.Salary = 0;
        }

        // Methods
        // Public Methods
        public string MyName(string name)
        {
            return string.Format("Welcome {0}", name);
        }

        // Private Methods
        private int SalaryAfterIncrement(int percentage)
        {
            return (_salary / percentage * 100) + _salary;
        }

        // virtual or abstract methods are not allowed
    }
}
