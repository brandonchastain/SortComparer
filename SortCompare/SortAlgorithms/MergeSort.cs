using System;
namespace SortCompare.SortAlgorithms
{
    public class MergeSort : ISortAlgorithm
    {
        public void Sort(int[] arrayToSort)
        {
            var res = MergeSortHelper(arrayToSort, 0, arrayToSort.Length - 1);
            Array.Copy(res, arrayToSort, arrayToSort.Length);
        }

        private int[] MergeSortHelper(int[] a, int first, int last)
        {
            if (last == first)
            {
                return new int[] { a[first] };
            }

            // split into two halves and sort each half
            int mid = ((last - first) / 2) + first;
            int[] left = MergeSortHelper(a, first, mid);
            int[] right = MergeSortHelper(a, mid + 1, last);

            // merge the sorted halves
            int l = 0;
            int r = 0;
            int[] merged = new int[last - first + 1];

            for (int i = 0; i < merged.Length; i++)
            {

                if (l < left.Length && r < right.Length)
                {
                    if (left[l] < right[r])
                    {
                        merged[i] = left[l];
                        l++;
                    }
                    else
                    {
                        merged[i] = right[r];
                        r++;
                    }
                }
                else if (l < left.Length)
                {
                    merged[i] = left[l];
                    l++;
                }
                else // r < right.Length is true
                {
                    merged[i] = right[r];
                    r++;
                }
            }

            return merged;
        }
    }
}
