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

            var obj = new RecursionProblems2();
            obj.Main();

            timer.Stop();
            Console.WriteLine($"Time Elapsed: {timer.Elapsed.TotalSeconds} Sec");
        }
    }
}
