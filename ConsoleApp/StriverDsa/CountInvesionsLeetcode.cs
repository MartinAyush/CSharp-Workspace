using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class CountInvesionsLeetcode
    {
        public void Main()
        {
            int n = 5;
            int[] arr = { 2, 5, 1, 3, 4 };
            int ans = getInversions(arr, n);
            Console.WriteLine("something");
            Console.WriteLine(ans);
        }

        int getInversions(int[] arr, int n)
        {
            int count = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length; j++)
                {
                    if(i < j && arr[i] > arr[j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
