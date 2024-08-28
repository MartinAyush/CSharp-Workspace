using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class KthPermutationSequence
    {
        public void Main()
        {
            string ans = GetPermutation(4, 17);
            Console.WriteLine(ans);
        }

        // Brute-force approach
        public string GetPermutationBruteForce(int n, int k)
        {
            int[] arr = new int[n];
            for(int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }

            List<string> permutations = new List<string>();
            GetAllPermutationsBruteForce(arr, ref permutations, 0);
            permutations.Sort();
            return permutations[k - 1];
        }

        private void GetAllPermutationsBruteForce(int[] arr, ref List<string> permutations, int idx)
        {
            if(idx == arr.Length)
            {
                string str = "";
                foreach(var item in arr)
                {
                    str += item.ToString();
                }
                permutations.Add(str);
                return;
            }

            for(int i = idx; i < arr.Length; i++)
            {
                (arr[idx], arr[i]) = (arr[i], arr[idx]);
                GetAllPermutationsBruteForce(arr, ref permutations, idx + 1);
                (arr[idx], arr[i]) = (arr[i], arr[idx]);
            }
        }

        // Optimal
        public string GetPermutation(int n, int k)
        {
            string ans = string.Empty;
            // Adding numbers from 1 -> N
            // Calc factorial of n - 1
            List<int> numbers = new List<int>();
            int fact = 1;
            for(int i = 1; i < n; i++)
            {
                fact *= i;
                numbers.Add(i);
            }
            numbers.Add(n);

            // because we are considering 0 based indexing
            // here k is representing which permutation to take
            k = k - 1;

            while (true)
            {
                ans += numbers[k / fact].ToString();
                numbers.RemoveAt(k / fact);
                if(numbers.Count == 0)
                {
                    break;
                }
                k = k % fact;
                fact = fact / numbers.Count;
            }

            return ans;
        }

    }
}
