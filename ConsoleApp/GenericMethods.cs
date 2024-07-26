using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class GenericMethods
    {
        public void Main()
        {
            int x = Max<int>(10, 20);
            string x2 = Max<string>("hello", "world");
            Console.WriteLine(x);
            Console.WriteLine(x2);

            Print(10); // Prints 10
            Print("Hello"); // Prints "Hello"

            int[] numbers = { 10, 20, 30 };
            //int sum = Sum(numbers); // Returns 60

            int[] nums = Reverse(numbers);
            foreach(var num in nums)
            {
                Console.WriteLine(num);
            }

        }

        /*
           Write a generic method called Max that can find the maximum value of two values of any type. 
           The Max method should take two values of type T as input and return the maximum value. 
           The T parameter is a type parameter, which means that it can be replaced with any type when the method is called.
        */

        public static T Max<T>(T val1, T val2) where T : IComparable<T>
        {
            if (val1.CompareTo(val2) > 0)
            {
                return val1;
            }
            else
            {
                return val2;
            }
        }

        /*
            Write a generic method called Print that can print any type of value. 
            The Print method should take a value of type T as input and print it to the console. 
            The T parameter is a type parameter, which means that it can be replaced with any type when the method is called.
         */

        public static void Print<T>(T val)
        {
            Console.WriteLine(val);
        }

        /*
         * Write a generic method called Sum that can calculate the sum of any number of values of type T. 
         * The Sum method should take an array of values of type T as input and return the sum of the values. 
         * The T parameter is a type parameter, which means that it can be replaced with any type when the method is called.
         */

        //public static T Sum<T>(T[] array) where T : struct, IComparable<T>
        //{
        //    T sum = 0;
        //    foreach (T value in array)
        //    {
        //        sum += value;
        //    }
        //    return sum;
        //}

        /*
        Write a generic method called Reverse that can reverse the order of an array of values of type T. 
        The Reverse method should take an array of values of type T as input and return a new array with the values in reverse order. 
        The T parameter is a type parameter, which means that it can be replaced with any type when the method is called.
         */

        public static T[] Reverse<T>(T[] array)
        {
            int i = 0;
            while(i < array.Length/2)
            {
                (array[i], array[array.Length - 1 - i]) = (array[array.Length - 1 - i], array[i]);
                i++;
            }
            return array;
        }

    }
}
