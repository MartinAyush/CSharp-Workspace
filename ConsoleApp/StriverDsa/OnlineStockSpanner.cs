using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{

    public class StockSpanner
    {
        private Stack<Tuple<int, int>> _stocksBucket;
        private int _idx = 0;
        public StockSpanner()
        {
            _stocksBucket = new Stack<Tuple<int, int>>();
        }

        public int Next(int price)
        {
            int ans = -1;
            while(_stocksBucket.Count > 0 && _stocksBucket.Peek().Item1 <= price)
            {
                _stocksBucket.Pop();
            }

            if(_stocksBucket.Count > 0)
            {
                ans = _idx - _stocksBucket.Peek().Item2;
            }
            else
            {
                ans = _idx - ans;
            }

            _stocksBucket.Push(new Tuple<int, int>(price, _idx));
            _idx++;
            return ans;
        }
    }
}
