using System;

namespace TestApplication
{
    class UsingStatement_IDispose : IDisposable
    {
        /*
         * The "IDisposable" interface of "System" namespace, has a method called dispose.
         * Dispose is used to close un-managed resources that are created during the life-time of the object.
         * 
         * NOTE: Compiler with automatically call the dispose method when closing the using statement.
         * 
         * STEPS:
         * 1. Inherit IDisposable interface to a class
         * 2. Implement the dispose method and close the unmanaged resources
         * 3. use current class by using statement
         * 
         * 
         * USAGE:
         * using(UsingStatement_IDispose obj = new UsingStatement_IDispose())
         * {
         *      obj.DoSomeWork();
         * }
         * Console.WriteLine("Some additional work outside the using statement");
         */

        public UsingStatement_IDispose()
        {
            // Initialize resources
            Console.WriteLine("File or database connection begin.");
        }

        public void DoSomeWork()
        {
            Console.WriteLine("Done some work...");
        }

        public void Dispose()
        {
            // close un-managed resources
            Console.WriteLine("Closing File or database connection.");
        }
    }
}
