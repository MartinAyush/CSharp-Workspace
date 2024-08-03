using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class LargestAreaInHistogram
    {
        public void Main()
        {
            int[] heights = [2, 1, 5, 6, 2, 3];
            int ans = LargestRectangleArea(heights);
            Console.WriteLine(ans);
        }

        public int LargestRectangleArea(int[] heights)
        {
            int[] prevSmaller = GeneratePrevSmallerElementsArray(heights);
            int[] nextSmaller = GenerateNextSmallerElementsArray(heights);
            int ans = int.MinValue;
            int len = heights.Length;

            for(int i = 0; i < len; i++)
            {
                // Calculating area which is height * width
                int val = heights[i] * (nextSmaller[i] - prevSmaller[i] - 1);
                ans = Math.Max(val, ans);
            }

            return ans;
        }

        private int[] GenerateNextSmallerElementsArray(int[] heights)
        {
            // If no smaller found then length will be placed in result else index of smaller elements
            Stack<int> smallerElements = new Stack<int>();
            int len = heights.Length;
            int[] result = new int[len];
            
            for(int i = len - 1; i >= 0; i--)
            {
                while(smallerElements.Count > 0 && heights[smallerElements.Peek()] >= heights[i])
                {
                    smallerElements.Pop();
                }

                if (smallerElements.Count > 0)
                {
                    result[i] = smallerElements.Peek();
                }
                else
                {
                    result[i] = len;
                }

                smallerElements.Push(i);
            }

            return result;
        }

        private int[] GeneratePrevSmallerElementsArray(int[] heights)
        {
            int len = heights.Length;
            int[] result = new int[len];
            Stack<int> smallerElements = new Stack<int>();

            for(int i = 0; i < len; i++)
            {
                while(smallerElements.Count > 0 && heights[smallerElements.Peek()] >= heights[i])
                {
                    smallerElements.Pop();
                }

                if(smallerElements.Count > 0)
                {
                    result[i] = smallerElements.Peek();
                }
                else
                {
                    result[i] = -1;
                }

                smallerElements.Push(i);
            }

            return result;
        }
    }
}
