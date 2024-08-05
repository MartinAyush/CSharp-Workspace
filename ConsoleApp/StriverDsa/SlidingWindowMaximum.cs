using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class SlidingWindowMaximum
    {
        public void Main()
        {

        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int len = nums.Length;
            List<int> result = new List<int>();
            LinkedList<int> deque = new LinkedList<int>();
            
            int max = int.MinValue;
            for(int i = 0; i < k; i++)
            {
                max = Math.Max(max, nums[i]);
            }

            for(int i = k; i < len; i++)
            {

            }
        }
    }
}
