using ConsoleApp.StriverDsa;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            var obj = new MinStack();
            obj.Push(0);
            obj.Push(1);
            obj.Push(0);
            Console.WriteLine(obj.GetMin());
            obj.Pop();
            //Console.WriteLine(obj.Top());
            Console.WriteLine(obj.GetMin());

            timer.Stop();
            Console.WriteLine($"Time Elapsed: {timer.Elapsed.TotalSeconds} Sec");
        }
        
    }
}
