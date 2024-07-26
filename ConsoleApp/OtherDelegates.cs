using System;

namespace TestApplication
{
    class OtherDelegates
    {
        public void Main()
        {
            //FuncDelegate();
            //ActionDelegate();
            PredicateDelegate();
        }

        // Func Delegate = T return type with 16 parameter.
        public void FuncDelegate()
        {
            /*
             * The Func delegate is a generic delegate, which means that it can be used to reference methods that have different return types.
             */
            /*
             * For eg. If func is not used then: 
             * public delegate MyDelegate(int a, int b); 
             * MyDelegate del = new MyDelegate(AddTwoNumbers);
             * Console.WriteLine(del(20, 30)); 
             */

            // Main advantage No need to write the delegate signature.
            Func<int, int, int> func = new Func<int, int, int>(AddTwoNumbers);
            int ans = func(20, 30);
            Console.WriteLine(ans);
        }

        // Action Delegate = void return type with 16 parameter.
        public void ActionDelegate()
        {
            /*
             * An Action delegate in C# is a type of delegate that points to a method that does not return a value.
             */

            Action<int, int> action = new Action<int, int>(PrintAdditionOfTwoNumbers);
            action(50, 60);
        }

        // Predicate Delegate = bool return type with 1 parameter.
        public void PredicateDelegate()
        {
            /*
             * A Predicate delegate in C# is a type of delegate that points to a method 
             * that takes one or more arguments and returns a Boolean value.
             */

            Predicate<int> predicate = new Predicate<int>(PositiveNumber);
            Console.WriteLine(predicate(10));
            Console.WriteLine(predicate(-10));
            Console.WriteLine(predicate(0));

            // other example => check if email address is valid or not | check if ipv4 address is valid or not.
        }


        // Methods to which delegate is point to.
        public int AddTwoNumbers(int a, int b)
        {
            return a + b;
        }

        public void PrintAdditionOfTwoNumbers(int a, int b)
        {
            Console.WriteLine("Addition of two numbers is {0}", a + b);
        }

        public bool PositiveNumber(int num)
        {
            return num >= 0;
        }
    }
}
