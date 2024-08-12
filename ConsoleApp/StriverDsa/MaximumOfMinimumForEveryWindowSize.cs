using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class MaximumOfMinimumForEveryWindowSize
    {
        public void Main()
        {
            int[] arr = { 10, 20, 30, 50, 10, 70, 30 };
            int n = arr.Length;
            List<int> ans = maxOfMin(arr, n);
            foreach(var item in ans)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public int[] MaxMinWindowButeForce(int[] a, int n)
        {
            int[] ans = new int[n];
            for(int i = 0; i < n; i++)
            {
                //ans[i] = MaxInMinWindow(a, n, i + 1);
            }

            return ans;
        }

        private int MaxInMinWindowButeForce(int[] arr, int arrLen, int windowSize)
        {
            // Find min in window
            // For all min value return the max element
            if(windowSize == 1)
            {
                return arr.Max();
            }

            List<int> minElements = new List<int>();
            LinkedList<int> deque = new LinkedList<int>();

            for(int i = 0; i < windowSize; i++)
            {
                while(deque.Count > 0 && arr[deque.Last.Value] > arr[i])
                {
                    deque.RemoveLast();
                }
                deque.AddLast(i);
            }

            minElements.Add(arr[deque.First.Value]);

            for(int i = windowSize; i < arrLen; i++)
            {
                if(deque.First.Value == (i - windowSize))
                {
                    deque.RemoveFirst();
                }

                while(deque.Count > 0 && arr[deque.Last.Value] > arr[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);
                minElements.Add(arr[deque.First.Value]);
            }
            return minElements.Max();
        }

        public List<int> maxOfMin(int[] arr, int n)
        {
            // Find next and prev smaller idx's 
            // Find the range in which they are smaller by [ next - prev - 1] here next and prev are idx's
            // put the value in range [considering range - 1 as index]

            int[] nextSmaller = GetNextSmallerElement(arr, n);
            int[] prevSmaller = GetPrevSmallerElement(arr, n);

            int[] ans = new int[n];
            for(int i = 0; i < n; i++)
            {
                int range = (nextSmaller[i] - prevSmaller[i]) - 1;
                ans[range - 1] = Math.Max(arr[i], ans[range - 1]);
            }

            // if the element if greater in larger window then its also larger in smaller window
            // consider traversing backward because smaller window might not be filled
            for(int i = n - 2; i >= 0; i--)
            {
                ans[i] = Math.Max(ans[i], ans[i + 1]);
            }

            return ans.ToList();
        }

        private int[] GetPrevSmallerElement(int[] arr, int n)
        {
            int[] ans = new int[n];
            Stack<int> visitedIndex = new Stack<int>();

            for(int i = 0; i < n; i++)
            {
                while(visitedIndex.Count > 0 && arr[visitedIndex.Peek()] >= arr[i])
                {
                    visitedIndex.Pop();
                }

                if(visitedIndex.Count > 0)
                {
                    ans[i] = visitedIndex.Peek();
                }
                else
                {
                    ans[i] = -1;
                }

                visitedIndex.Push(i);
            }

            return ans;
        }

        private int[] GetNextSmallerElement(int[] arr, int n)
        {
            int[] ans = new int[n];
            Stack<int> visitedIndexes = new Stack<int>();

            for(int i = n - 1; i >= 0; i--)
            {
                while(visitedIndexes.Count > 0 && arr[visitedIndexes.Peek()] >= arr[i])
                {
                    visitedIndexes.Pop();
                }

                if(visitedIndexes.Count > 0)
                {
                    ans[i] = visitedIndexes.Peek();
                }
                else
                {
                    ans[i] = n;
                }

                visitedIndexes.Push(i);
            }

            return ans;
        }
    }
}
