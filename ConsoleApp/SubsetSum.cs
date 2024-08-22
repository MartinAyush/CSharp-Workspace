using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class SubsetSum
    {
        public void Main()
        {
            int[] nums = [1, 2, 2];
            var ans = SubsetsWithDup(nums);
            foreach (var item in ans)
            {
                foreach (var item2 in item)
                {
                    Console.Write(item2 + " ");
                }
                Console.WriteLine();
            }
        }

        public List<int> SubsetSums(List<int> arr, int N)
        {
            List<int> ans = new List<int>();
            GenerateAllSubsets(arr, N, 0, 0, ref ans);
            ans.Sort();
            return ans;
        }

        private void GenerateAllSubsets(List<int> arr, int n, int idx, int sum, ref List<int> ans)
        {
            if (idx == n)
            {
                ans.Add(sum);
                return;
            }

            sum += arr[idx];
            GenerateAllSubsets(arr, n, idx + 1, sum, ref ans);
            sum -= arr[idx];
            GenerateAllSubsets(arr, n, idx + 1, sum, ref ans);
            return;
        }

        private void GenerateSubsetUsingPowerSet(List<int> arr, int n)
        {
            // Using power set here

            for (int i = 0; i < (1 << n); i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        Console.Write(arr[j]);
                    }
                }
                Console.WriteLine();
            }
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> ans = new List<IList<int>>();
            List<int> temp = new List<int>();
            GetAllUniqueSubsets(nums, 0, ans, temp);
            return ans;
        }

        private void GetAllUniqueSubsets(int[] nums, int idx, IList<IList<int>> ans, List<int> temp)
        {
            ans.Add(new List<int>(temp));

            for (int i = idx; i < nums.Length; i++)
            {
                if (i > idx && nums[i] == nums[i - 1])
                {
                    continue;
                }

                temp.Add(nums[i]);
                GetAllUniqueSubsets(nums, i + 1, ans, temp);
                temp.RemoveAt(temp.Count - 1);
            }

            return;
        }
    }
}
