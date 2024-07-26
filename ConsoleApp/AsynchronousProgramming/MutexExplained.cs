using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestApplication.AsynchronousProgramming
{
    class MutexExplained
    {
        public void Main()
        {
            Mutex mutex = new Mutex();

            BankAccount account = new BankAccount();
            List<Task> tasks = new List<Task>();
            for(int i = 0; i < 10; i++)
            {
                Task t1 = Task.Factory.StartNew(() =>
                {
                    for(int j = 0; j < 100; j++)
                    {
                        account.Deposit(100);
                    }
                });
                tasks.Add(t1);

                Task t2 = Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 100; j++)
                    {
                        account.Withdraw(100);
                    }
                });
                tasks.Add(t2);
            }
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final Ammount is : {account.Balance}");
        }


    }
}
