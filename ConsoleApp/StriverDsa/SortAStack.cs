using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class SortAStack
    {
        public void Main()
        {
            Stack<int> st = new Stack<int>();
            st.Push(5);
            st.Push(-2);
            st.Push(9);
            st.Push(-7);
            st.Push(3);
            var stack = SortStack(st);
            while(stack.Count > 0)
            {
                Console.WriteLine(st.Pop());
            }
        }

        public Stack<int> SortStack(Stack<int> s)
        {
            if(s.Count <= 1)
            {
                return s;
            }
            Sort(s);
            return s;
        }

        private void Sort(Stack<int> s)
        {
            if(s.Count == 1)
            {
                return;
            }

            int value = s.Pop();
            Sort(s);
            Insert(s, value);
            return;
        }

        private void Insert(Stack<int> s, int value)
        {
            if(s.Count == 0 || s.Peek() <= value)
            {
                s.Push(value);
                return;
            }
            int temp = s.Pop();
            Insert(s, value);
            s.Push(temp);
            return;
        }
    }
}
