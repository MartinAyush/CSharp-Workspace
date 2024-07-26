using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class AnonymousFunctions
    {
        // To define an anonymous method, you use the delegate keyword followed by the signature of the method.
        // Anonymous methods can also be used as event handlers.
        // Anonymous methods can be passed as a parameter to a delegate
        // Anonymous methods can be used to avoid creating new methods, which can save memory.

        public void Main()
        {
            MyDelegate del = new MyDelegate(AddTwoNumbers); // normal way

            // Anonymous method using delegate keyword
            MyDelegate del2 = new MyDelegate(delegate (int a, int b) 
            {
                Console.WriteLine("Addition is : {0}", a + b);
            });

            // Anonymous method using lambda expression
            MyDelegate del3 = new MyDelegate((a, b) =>
            {
                Console.WriteLine("Addition is : {0}", a + b);
            });

            // calling delegates
            del(10, 20);
            del2(20, 30);
            del3(100, 200);
        }
        public void AddTwoNumbers(int a, int b)
        {
            Console.WriteLine("Addition is : {0}", a + b);
        }
    }
}
