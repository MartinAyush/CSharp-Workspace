using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    internal class LargestSubarrayWithZeroSum
    {
        public int MaxLen(int[] arr, int n)
        {
            //Your code here
            if (n == 0)
            {
                return 0;
            }

            int prefixSum = 0;
            int ans = 0;
            Dictionary<int, int> psumIdxMap = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                prefixSum += arr[i];

                if (prefixSum == 0)
                {
                    // consider all the elements from the start
                    ans = Math.Max(ans, i + 1);
                }

                if (psumIdxMap.ContainsKey(prefixSum))
                {
                    ans = Math.Max(ans, i - psumIdxMap[prefixSum]);
                }
                else
                {
                    psumIdxMap[prefixSum] = i;
                }
            }

            return ans;
        }
    }
}
