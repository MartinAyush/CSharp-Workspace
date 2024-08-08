using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class SlidingWindowMaximum
    {
        public void Main()
        {
            int[] nums = [1, 3, -1, -3, 5, 3, 6, 7];
            int k = 3;
            int[] ans = MaxSlidingWindow(nums, k);
            foreach(int num in ans)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int len = nums.Length;
            LinkedList<int> maxValues = new LinkedList<int>();
            int[] ans = new int[len - k + 1];

            for(int i = 0; i < k; i++)
            {
                while (maxValues.Count > 0 && nums[maxValues.Last.Value] <= nums[i])
                {
                    maxValues.RemoveLast();
                }

                maxValues.AddLast(i);
            }

            ans[0] = nums[maxValues.First.Value];

            for(int i = k; i < len; i++)
            {
                if(maxValues.First.Value == (i - k))
                {
                    maxValues.RemoveFirst();
                }

                while (maxValues.Count > 0 && nums[maxValues.Last.Value] <= nums[i])
                {
                    maxValues.RemoveLast();
                }

                maxValues.AddLast(i);

                ans[i - k + 1] = nums[maxValues.First.Value];
            }

            return ans;
        }
    }
}
