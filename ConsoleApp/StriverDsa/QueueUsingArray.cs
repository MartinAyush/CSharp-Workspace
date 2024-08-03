using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    internal class QueueUsingArray
    {
    }
    class MyQueue
    {
        //Your code here
        //private int[] arr;
        //private int top;

        //public MyQueue()
        //{
        //    arr = new int[100005];
        //    top = 0;
        //    rear = 0;
        //}

        //public void push(int x)
        //{
        //    //Your code here
        //    this.arr[rear] = x;
        //    rear++;
        //}

        //public int pop()
        //{
        //    //Your code here
        //    int element = this.arr[top];
        //    top++;
        //    return element;
        //}
    }

    public class MyStack
    {
        private int[] arr;
        private int top;

        public MyStack()
        {
            arr = new int[1000];
            top = -1;
        }

        public void Push(int x)
        {
            // Your Code
            if(top == -1)
            {
                top = 0;
            }
            arr[top] = x;
            top++;
        }

        public int Pop()
        {
            // Your Code
            if(top == -1)
            {
                return -1;
            }
            return arr[top--];
        }
    }
}
