using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    internal class LongestConsequitiveSequence
    {
        public void Main()
        {
            int[] nums = [0, 3, 7, 2, 5, 8, 4, 6, 0, 1];
            int ans = LongestConsecutive(nums);
            Console.WriteLine(ans);
        }

        public int LongestConsecutive(int[] nums)
        {
            // Intution: find the starting point of the sequence, that is where element do not have (element - 1) in the input array
            int len = nums.Length;
            if(len == 0)
            {
                return 0;
            }

            HashSet<int> visited = new HashSet<int>();
            for(int i = 0; i < len; i++)
            {
                visited.Add(nums[i]);
            }

            int currCount = 1, ans = -1;
            for(int i = 0; i < len; i++)
            {
                if (!visited.Contains(nums[i] - 1)) // find the starting point
                {
                    currCount = 1;
                    int startPoint = nums[i];
                    while (visited.Contains(startPoint + 1))
                    {
                        currCount++;
                        startPoint++;
                    }
                    ans = Math.Max(currCount, ans);
                }
            }

            return ans;
        }
    }
}
