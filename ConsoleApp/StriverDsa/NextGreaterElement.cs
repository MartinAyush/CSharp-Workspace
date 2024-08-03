using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class NextGreaterElement
    {
        public void Main()
        {
            //int[] nums1 = [4, 1, 2], nums2 = [1, 3, 4, 2];
            //var ans = NextGreaterElementOne(nums1, nums2);
            //foreach(var item in ans)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            int[] nums = [1, 2, 3, 4, 3];
            int[] ans = NextGreaterElementsTwo(nums);
            foreach(var item in ans)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public int[] NextGreaterElementOne(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length, len2 = nums2.Length;
            int[] ans = new int[len1];

            for(int i = 0; i < len1; i++)
            {
                int currElement = nums1[i];
                int j = 0;
                while(j < len2)
                {
                    if (nums2[j] == currElement)
                    {
                        while (j < len2 && nums2[j] <= currElement)
                        {
                            j++;
                        }
                        if(j == len2)
                        {
                            ans[i] = -1;
                        }
                        else if (nums2[j] > currElement)
                        {
                            ans[i] = nums2[j];
                        }
                        break;
                    }
                    j++;
                }
            }

            return ans;
        }

        public int[] NextGreaterElementsTwo(int[] nums)
        {
            /*
             * Intuition: Traverse the array backward and check if we have visited an element greater than the current element.
             *
             * For a circular array, concatenate the array with itself. This way, if there is a greater element to the left of the current element, we can account for it.
             * The trick is to traverse the array 2 * len times and use idx % len to avoid index out of bounds.
             */

            Stack<int> greaterElements = new Stack<int>();
            int len = nums.Length;
            int[] ans = new int[len];

            for(int i = ((2 * len) - 1); i >= 0; i--)
            {
                while(greaterElements.Count > 0 && greaterElements.Peek() <= nums[i % len])
                {
                    greaterElements.Pop();
                }
                if(greaterElements.Count > 0 && greaterElements.Peek() > nums[i % len])
                {
                    ans[i % len] = greaterElements.Peek();
                }
                else
                {
                    ans[i % len] = -1;
                }
                greaterElements.Push(nums[i % len]);
            }

            return ans;
        }

        public int[] NextGreaterElementsTwoEasy(int[] nums) 
        {
            // Intuition: Traverse the array backward and check if we have visited an element greater than the current element.
            Stack<int> greaterElements = new Stack<int>();
            int len = nums.Length;
            int[] ans = new int[len];

            // For circular array pre-fill the stack so we have greater element for the later elements
            for(int i = len - 1; i >= 0; i--)
            {
                greaterElements.Push(nums[i]);
            }

            for(int i = len - 1; i >= 0; i--)
            {
                while(greaterElements.Count > 0 && greaterElements.Peek() <= nums[i])
                {
                    greaterElements.Pop();
                }

                if(greaterElements.Count > 0 && greaterElements.Peek() > nums[i])
                {
                    ans[i] = greaterElements.Peek();
                }
                else
                {
                    ans[i] = -1;
                }

                greaterElements.Push(nums[i]);
            }

            return ans;
        }
    }
}
