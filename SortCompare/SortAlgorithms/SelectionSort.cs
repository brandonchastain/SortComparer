using System;
namespace SortCompare.SortAlgorithms
{
    public class SelectionSort : ISortAlgorithm
    {
        public void Sort(int[] arrayToSort)
        {
            int[] a = arrayToSort;

            // for each position in the sorted list
            for (int sortedEnd = 0; sortedEnd < a.Length; sortedEnd++)
            {
                // find the next minimum element
                int minIdx = sortedEnd;
                for (int i = sortedEnd + 1; i < a.Length; i++)
                {
                    if (a[i] < a[minIdx])
                    {
                        minIdx = i;
                    }
                }

                // swap next min element with the first unsorted element
                int temp = a[sortedEnd];
                a[sortedEnd] = a[minIdx];
                a[minIdx] = temp;
            }
        }
    }
}
