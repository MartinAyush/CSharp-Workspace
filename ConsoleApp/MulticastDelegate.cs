using System;

namespace TestApplication
{
    public delegate void MyDelegate(int a, int b);
    class MulticastDelegate
    {
        public void Add(int a, int b)
        {
            Console.WriteLine("Addition is : {0}", a + b);
        }

        public void Multiply(int a, int b)
        {
            Console.WriteLine("Multiplication is : {0}", a * b);
        }

        public void Main()
        {
            MyDelegate del = new MyDelegate(Add);
            del += Multiply; // adding reference of another method.

            del(10, 20);
        }
    }
}
