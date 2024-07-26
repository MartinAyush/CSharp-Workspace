using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class MergeIntervalsLeetcode
    {
        public void Main()
        {
            int[][] intervals = [[1, 4], [0, 0]];
            var ans = Merge(intervals);
            foreach(var item in ans)
            {
                foreach(var item2 in item)
                {
                    Console.Write(item2 + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int[][] Merge(int[][] intervals)
        {
            // In an interval (i, j), if (x, y) is such that x < j, then (x, y) is an overlapping interval

            // sort the intervals
            intervals = intervals.OrderBy(x => x[0])
                                 .ThenBy(x => x[1]).ToArray();

            List<int[]> overlappingIntervals = new List<int[]>();
            overlappingIntervals.Add(intervals[0]);

            for(int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= overlappingIntervals.Last()[1])
                {
                    if(intervals[i][1] > overlappingIntervals.Last()[1])
                    {
                        overlappingIntervals.Last()[1] = intervals[i][1];
                    }
                    
                    if (intervals[i][0] < overlappingIntervals.Last()[0])
                    {
                        overlappingIntervals.Last()[0] = intervals[i][0];
                    }
                }
                else
                {
                    overlappingIntervals.Add(intervals[i]);
                }
            }

            return overlappingIntervals.ToArray();
        }
    }
}
