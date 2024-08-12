using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class AtoIOrStringToInt
    {
        public void Main()
        {
            string str = "2147483648";
            int ans = MyAtoi(str);
            Console.WriteLine(ans);
        }

        public int MyAtoi(string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            s = s.Trim();
            int len = s.Length;

            const int maxValue = int.MaxValue - 1;
            const int minValue = int.MinValue;

            long ans = 0;
            bool sign = false;
            bool numberVisited = false;
            bool signVisited = false;

            for (int i = 0; i < len; i++)
            {
                if (!char.IsNumber(s[i]))
                {
                    if ((s[i] == '+' || s[i] == '-') && !numberVisited && !signVisited)
                    {
                        signVisited = true;
                        sign = s[i] == '-' ? true : false;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    numberVisited = true;
                    long cmp = ans * 10;
                    if (cmp >= maxValue || cmp <= minValue)
                    {
                        return sign ? minValue : maxValue;
                    }
                    ans = cmp + (s[i] - '0');
                }
            }

            ans = sign ? -1 * ans : ans;
            if (ans >= maxValue || ans <= minValue)
            {
                return sign ? minValue : maxValue;
            }
            return (int)ans;
        }
    }
}
