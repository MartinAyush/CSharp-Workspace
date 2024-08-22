using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class RecursionProblems1
    {
        public void Main()
        {
            int[] nums = { 1, 2, 3 };
            var ans = Permute(nums);
            foreach(var item1 in ans)
            {
                foreach(var item2 in item1)
                {
                    Console.Write(item2 + " ");
                }
                Console.WriteLine();
            }
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

        
    }
}
