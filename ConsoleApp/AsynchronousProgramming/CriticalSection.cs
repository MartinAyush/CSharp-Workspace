using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.AsynchronousProgramming
{
    class CriticalSection
    {
        public void Main()
        {
            BankAccount account = new BankAccount();
            List<Task> tasks = new List<Task>();

            for (int task = 0; task < 10; task++)
            {
                Task t = new Task(() =>
                {
                    for(int i = 0; i < 100; i++)
                    {
                        account.Deposit(100);        
                    }
                });
                t.Start();
                tasks.Add(t);
                Task t1 = new Task(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        account.Withdraw(100);
                    }
                });
                t1.Start();
                tasks.Add(t1);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final account balance is {account.Balance}");
        }
    }

    class BankAccount
    {
        public object padlock = new object();
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            //lock (padlock)
            //{
                Balance += amount;
            //}
        }

        public void Withdraw(int amount)
        {
            //lock (padlock)
            //{
                Balance -= amount;
            //}
        }
    }
}
