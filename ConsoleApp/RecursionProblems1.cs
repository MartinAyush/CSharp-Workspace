using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class RecursionProblems1
    {
        public void Main()
        {
            string s = "ABCD";
            PrintALlPermutations(s, 0);
        }

        private void PrintALlPermutations(string s, int idx)
        {
            if(idx == s.Length)
            {
                Console.WriteLine(s);
            }
            var str = new StringBuilder(s);
            for(int i = idx; i < s.Length; i++)
            {
                (str[i], str[idx]) = (str[idx], str[i]);
                PrintALlPermutations(str.ToString(), idx + 1);
                (str[i], str[idx]) = (str[idx], str[i]);
            }
        }

        private void SortArrayRecursivly(List<int> arr)
        {
            SortArray(ref arr);
        }

        private void SortArray(ref List<int> arr)
        {
            if(arr.Count == 1)
            {
                return;
            }
            int lastElement = arr[arr.Count - 1];
            arr.RemoveAt(arr.Count - 1);
            SortArray(ref arr);
            InsertElementAtCorrectLoc(ref arr, lastElement);
        }

        private void InsertElementAtCorrectLoc(ref List<int> arr, int lastElement)
        {
            if(arr.Count == 0 || arr[arr.Count - 1] <= lastElement)
            {
                arr.Add(lastElement);
                return;
            }
            int last = arr[arr.Count - 1];
            arr.RemoveAt(arr.Count - 1);
            InsertElementAtCorrectLoc(ref arr, lastElement);
            arr.Add(last);
        }

        private void PrintAllSubstring(string str, string ans, int idx)
        {
            if(idx == str.Length)
            {
                Console.WriteLine(ans);
                return;
            }
            PrintAllSubstring(str, ans + str[idx], idx + 1);
            PrintAllSubstring(str, ans, idx + 1);
        }

        private void GenerateAllPermutation(List<int> nums, List<int> output)
        {
            if (output.Count == nums.Count)
            {
                foreach (var item in output)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < nums.Count; i++)
            {
                if (output.Contains(nums[i]))
                {
                    continue;
                }

                output.Add(nums[i]);
                GenerateAllPermutation(nums, output);
                output.RemoveAt(output.Count - 1);
            }
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            GenerateAllPermutations(nums, 0, ref ans);
            return ans;
        }

        private void GenerateAllPermutations(int[] nums, int idx, ref IList<IList<int>> ans)
        {
            if(idx == nums.Length)
            {
                ans.Add(new List<int>(nums));
                return;
            }

            for (int i = idx; i < nums.Length; i++)
            {
                // Intution Behind swapping: Give chance to every element to be at that index (idx).
                (nums[i], nums[idx]) = (nums[idx], nums[i]);
                GenerateAllPermutations(nums, idx + 1, ref ans);
                (nums[i], nums[idx]) = (nums[idx], nums[i]);
            }
            return;
        }

        void DeleteMidInStack(Stack<int> s, int sizeOfStack)
        {
            DeleteMidInStackHelper(ref s, sizeOfStack / 2);
        }

        private void DeleteMidInStackHelper(ref Stack<int> s, int sizeOfStack)
        {
            if (sizeOfStack == 0)
            {
                s.Pop();
                return;
            }
            int top = s.Pop();
            DeleteMidInStackHelper(ref s, sizeOfStack - 1);
            s.Push(top);
        }

        private void ReverseStackUsingRecursion(Stack<int> st)
        {
            if(st.Count == 1)
            {
                return;
            }
            int top = st.Pop();
            ReverseStackUsingRecursion(st);
            InsertElementAtBottom(ref st, top);
        }

        private void InsertElementAtBottom(ref Stack<int> st, int element)
        {
            if(st.Count == 0)
            {
                st.Push(element);
                return;
            }

            int top = st.Pop();
            InsertElementAtBottom(ref st, element);
            st.Push(top);
        }

        public int KthGrammar(int n, int k)
        {
            if(n == 1 && k == 1)
            {
                return 0;
            }

            int mid = (int)(Math.Pow(2, n - 1) / 2);

            if(k <= mid)
            {
                return KthGrammar(n - 1, k);
            }
            else
            {
                return  1 - KthGrammar(n - 1, k - mid);
            }
        }
    }
}