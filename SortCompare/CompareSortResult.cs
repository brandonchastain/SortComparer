using System;
using System.Collections.Generic;

namespace SortCompare
{
    public class CompareSortResult
    {
        public CompareSortResult(int[] unsorted)
        {
            this.SortTimes = new Dictionary<string, string>();
            //this.Unsorted = new int[unsorted.Length];
            //Array.Copy(unsorted, this.Unsorted, unsorted.Length);
        }

        public IDictionary<string, string> SortTimes { get; private set; }
        public int[] Unsorted { get; private set; }

        public override string ToString()
        {
            string res = "";

            foreach ((string sort, string time) in SortTimes)
            {
                res += $"{sort}: {time}\n";
            }

            return res;
        }
    }
}