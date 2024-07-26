using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace ConsoleApp
{
    // Interfaces only contains 
    // Properties
    // Methods
    // Do not contains -> Fields
    interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        string Gender { get; set; }

        void PrintDetails();

    }
}
