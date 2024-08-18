using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class CombinationSum
    {
        public void Main()
        {
        }

        public IList<IList<int>> CombinationSumOne(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            GetAllCombinationsOne(candidates, target, 0, new List<int>(), ans);
            return ans;
        }

        private void GetAllCombinationsOne(int[] candidates, int target, int idx, List<int> list, IList<IList<int>> ans)
        {
            if(idx == candidates.Length)
            {
                if(target == 0)
                {
                    ans.Add(new List<int>(list));
                }
                return;
            }

            if (candidates[idx] <= target)
            {
                list.Add(candidates[idx]);
                GetAllCombinationsOne(candidates, target - candidates[idx], idx, list, ans);
                list.RemoveAt(list.Count - 1);
            }
            GetAllCombinationsOne(candidates, target, idx + 1, list, ans);
            return;
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(candidates);
            GetAllCombinationsTwo(candidates, target, 0, ans, new List<int>());
            return ans;
        }

        private void GetAllCombinationsTwo(int[] candidates, int target, int idx, IList<IList<int>> ans, List<int> list)
        {
            if(target == 0)
            {
                ans.Add(new List<int>(list));
                return;
            }
            
            for(int i = idx; i < candidates.Length; i++)
            {
                // If the element is same as previous element then skip this.
                if (i > idx && candidates[i] == candidates[i - 1]) 
                {
                    continue;
                }

                if (candidates[i] > target)
                {
                    break;
                }

                list.Add(candidates[i]);
                GetAllCombinationsTwo(candidates, target - candidates[i], i + 1, ans, list);
                list.RemoveAt(list.Count - 1);
            }
            return;
        }
    }
}
