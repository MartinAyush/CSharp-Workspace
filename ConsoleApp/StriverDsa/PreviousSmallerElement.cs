using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class PreviousSmallerElement
    {
        public void Main()
        {
            List<int> arr = [4, 5, 2, 10, 8];
            List<int> ans = PrevSmaller(arr);
            foreach(var item in ans)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public List<int> PrevSmaller(List<int> arr)
        {
            Stack<int> smallerElements = new Stack<int>();
            List<int> ans = new List<int>();
            int len = arr.Count;

            for(int i = 0; i < len; i++)
            {
                while(smallerElements.Count > 0 && smallerElements.Peek() >= arr[i])
                {
                    smallerElements.Pop();
                }
                if(smallerElements.Count > 0 && smallerElements.Peek() < arr[i])
                {
                    ans.Add(smallerElements.Peek());
                }
                else
                {
                    ans.Add(-1);
                }
                smallerElements.Push(arr[i]);
            }

            return ans;

        }
    }
}
