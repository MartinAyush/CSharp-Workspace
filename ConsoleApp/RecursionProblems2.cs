using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class RecursionProblems2
    {
        public void Main()
        {
            string str = "the simple engineer";
            string ans = ReverseStringRecursion(str, str.Length - 1);
            Console.WriteLine("Reversed string is {0}", ans);
        }

        private string ReverseStringRecursion(string str, int idx)
        {
            if(idx == 0)
            {
                return str[idx].ToString();
            }

            var lastChar = str[idx];
            var revStr = ReverseStringRecursion(str, idx - 1);
            return lastChar + revStr;
        }
    }
}
