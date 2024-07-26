using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class ThreeSumLeetcode
    {
        public void Main()
        {
            int[] nums = [-1, 0, 1, 2, -1, -4];
            var ans = ThreeSum(nums); 
            foreach(var item in ans)
            {
                foreach(var temp in item)
                {
                    Console.Write(temp + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            // Intution: we need x + y + z = 0 and if I fix x then I can use two pointer to find the other two element

            // Sorting array to use the two pointer technique
            Array.Sort(nums);
            IList<IList<int>> answers = new List<IList<int>>();
            for(int firstIdx = 0; firstIdx < nums.Length - 2; firstIdx++)
            {
                // exclude all similar elements because we don't want to create duplicate pairs
                if (firstIdx > 0 && nums[firstIdx] == nums[firstIdx - 1])
                    continue;

                // using two pointer to find the 2nd and 3rd element of a pair
                int secondIdx = firstIdx + 1, thirdIdx = nums.Length - 1;
                while (secondIdx < thirdIdx)
                {
                    int num = nums[firstIdx] + nums[secondIdx] + nums[thirdIdx];
                    if (num == 0)
                    {
                        answers.Add(new List<int>() { nums[firstIdx], nums[secondIdx++], nums[thirdIdx--] });
                        while (secondIdx < thirdIdx && nums[secondIdx] == nums[secondIdx - 1])
                        {
                            secondIdx++;
                        }
                        while (secondIdx < thirdIdx && nums[thirdIdx] == nums[thirdIdx + 1])
                        {
                            thirdIdx--;
                        }
                    }
                    else if (num < 0)
                    {
                        secondIdx++;
                    }
                    else
                    {
                        thirdIdx--;
                    }
                }
            }
            return answers;
        }
    }
}
