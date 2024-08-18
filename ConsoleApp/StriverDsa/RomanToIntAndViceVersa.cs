using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class RomanToIntAndViceVersa
    {
        public void main()
        {
            string str = "MCMXCIV";
            string ans = IntToRoman(1994);
            Console.WriteLine(ans);
        }

        public int RomanToInt(string s)
        {
            // Intution: the roman number are read from left to right.
            // if the current character is greater than the next character then it's value is added positively to the ans
            // else the chracter value is added negatively to the ans

            Dictionary<char, int> mappings = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            int len = s.Length;
            int ans = 0;

            for (int i = 0; i < len; i++)
            {
                if (i == len - 1 || mappings[s[i]] > mappings[s[i + 1]])
                {
                    ans += mappings[s[i]];
                }
                else
                {
                    ans += -1 * mappings[s[i]];
                }
            }

            return ans;
        }

        public string IntToRoman(int num)
        {
            List<(string, int)> mappings = new List<(string, int)>()
            {
                new ( "I", 1),
                new ( "IV", 4),
                new ( "V", 5 ),
                new ( "IX", 9 ),
                new ( "X", 10 ),
                new ( "XL", 40 ),
                new ( "L", 50 ),
                new ( "XC", 90 ),
                new ( "C", 100 ),
                new ( "CD", 400 ),
                new ( "D", 500 ),
                new ( "CM", 900 ),
                new ( "M", 1000 )
            };

            int len = mappings.Count;
            string ans = string.Empty;

            for (int i = len - 1; i >= 0; i--)
            {
                int count = num / mappings[i].Item2;
                if (count > 0)
                {
                    num = num % mappings[i].Item2;
                    while (count > 0)
                    {
                        ans += mappings[i].Item1;
                        count--;
                    }
                }
            }

            return ans;
        }
    }
}
