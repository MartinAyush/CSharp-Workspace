using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class TrappingRainWater
    {
        public void Main()
        {
            int[] height = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];
            var ans = Trap(height);
            Console.WriteLine(ans);
        }

        public int Trap(int[] height)
        {
            int[] leftMax = new int[height.Length];
            int[] rightMax = new int[height.Length];

            // cal left
            leftMax[0] = height[0];
            for(int i = 1; i < height.Length; i++)
            {
                leftMax[i] = Math.Max(height[i], leftMax[i - 1]);
            }

            // cal right
            rightMax[height.Length - 1] = height[height.Length - 1];
            for(int i = height.Length - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
            }

            int sum = 0;

            for(int i = 0; i < height.Length; i++)
            {
                sum += Math.Min(leftMax[i], rightMax[i]) - height[i];
            }

            return sum;
        }
    }
}
