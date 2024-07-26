using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class MajorityElementLeetcode
    {
        public void Main()
        {

        }

        public int MajorityElementEasy(int[] nums)
        {
            int prev = nums[0];
            int count = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    prev = nums[i];
                }

                if (nums[i] == prev)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            return prev;
        }

        //public IList<int> MajorityElement(int[] nums)
        //{
        //}

    }
}
