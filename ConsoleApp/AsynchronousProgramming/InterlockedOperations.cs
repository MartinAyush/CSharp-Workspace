using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApplication.AsynchronousProgramming
{
    class BankAccountInterlocked
    {
        private int _balanceField;
        public int Balance 
        {
            get 
            {
                return _balanceField;
            }
            private set
            {
                _balanceField = value;
            } 
        }
        public void Deposit(int amount)
        {
            Interlocked.Add(ref _balanceField, amount);
            //Balance += amount;
        }

        public void Withdraw(int amount)
        {
            Interlocked.Add(ref _balanceField, -amount);
            //Balance -= amount;
        }
    }
    class InterlockedOperations
    {
        public void Main()
        {
            BankAccountInterlocked ba1 = new BankAccountInterlocked();
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                Task t1 = new Task(() =>
                {
                    for(int i = 0; i < 100; i++)
                    {
                        ba1.Deposit(1000);
                    }
                });
                t1.Start();
                tasks.Add(t1);
                Task t2 = new Task(() =>
                {
                    for (int withdrawIteration = 0; withdrawIteration < 100; withdrawIteration++)
                    {
                        ba1.Withdraw(1000);
                    }
                });
                t2.Start();
                tasks.Add(t2);
            }
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final balance is {ba1.Balance}");

            
        }
    }
}
