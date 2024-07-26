using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class DelegatesWithExample
    {
        public delegate string GreetUser(string firstName, string LastName); // delegate definition

        public void Main()
        {
            GreetUser greetUser = new GreetUser(HelloUser); // now greetUser is function pointer, which can point to one or more functions
            string greetings = greetUser("Martin", "Anthony"); // invoking function pointer
            Console.WriteLine(greetings);
        }

        public string HelloUser(string firstName, string LastName)
        {
            return string.Format("Greetings {0},{1}", firstName, LastName);
        } // function to which delegate will point to
    }
}
