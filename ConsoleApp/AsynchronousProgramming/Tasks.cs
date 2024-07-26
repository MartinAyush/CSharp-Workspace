using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace TestApplication.AsynchronousProgramming
{
    class Tasks
    {
        /*
         * A task in C# is a unit of work that can be executed asynchronously.
         * This means that the task can run in the background while the main thread of execution continues.
         * IMPORTANT METHODS & PROPERTIES
         * 1. Task task = new Task(() => { work to be done });
         * 2. Task.Factory.StartNew(() => {});
         * 3. Cancelling task immediately => CancellationTokenSource cts = new CancellationTokenSource(); Then cts.Cancel();
         * 4. Cancelling task after some time => cts.Token.WaitHandle.WaitOne(5000);
         * 5. Waiting for task to complete => Task.WaitOne(), Task.WaitAny(), Task.WaitAll()
         * 6. Perform Action when Task is completed => Task.WhenAll(), Task.WhenAny()
         * 
         * 
         * 
         */

        public void PrintChars(char ch)
        {
            for(int i = 0; i < 1000; i++)
            {
                Console.Write(ch);
            }
        }
        public void Main()
        {
            // Create a task -> create another thread and run the function on another thread.

            // 1st way
            //Task task = new Task(() =>
            //{
            //    PrintChars('.');
            //});
            //task.Start();

            // 2nd way
            //Task.Factory.StartNew(() =>
            //{
            //    PrintChars('#');
            //});


            // Cancelling task in between

            // 1st way - using cancellation token, which will immediately cancel the task.
            //CancellationTokenSource cts = new CancellationTokenSource();
            //var token = cts.Token;

            //Task.Factory.StartNew(() =>
            //{
            //    int i = 1;
            //    while(true)
            //    {
            //        if (token.IsCancellationRequested)
            //        {
            //            Console.WriteLine("Token Cancellation requested");
            //            break;
            //        }
            //        Console.WriteLine("Iteration {0}", i++);
            //    }

            //    Console.WriteLine("Task Completed");
            //}, token);

            //Console.ReadKey();
            //cts.Cancel(); // This will invoke the token.IsCancellationRequested

            // 2nd way - cancelling task after some time.
            //CancellationTokenSource cts = new CancellationTokenSource();

            //Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("##### Getting data form the database...");
            //    bool cancelled = cts.Token.WaitHandle.WaitOne(5000);
            //    if (cancelled)
            //    {
            //        Console.WriteLine("Cancelled the process in between, got no data.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Got the data from the database, task completed");
            //    }
            //}, cts.Token);

            //Console.ReadKey();
            //cts.Cancel();


            /*
             * Task Chaining
             */

            //Task task1 = new Task(() =>
            //{
            //    Thread.Sleep(4000);
            //    Console.WriteLine("Task 1 completed");
            //});
            //task1.Start();

            //Task task2 = new Task(() =>
            //{
            //    Thread.Sleep(3000);
            //    Console.WriteLine("Task 2 completed");
            //});
            //task2.Start();

            //Console.WriteLine("Data preparation has been done!");

            //Task.WhenAll(task1, task2).Wait();

            //Console.WriteLine("Final Output");

            

        }
    }
}
