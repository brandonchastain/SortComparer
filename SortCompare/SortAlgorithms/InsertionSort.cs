using System;
namespace SortCompare.SortAlgorithms
{
    public class InsertionSort : ISortAlgorithm
    {
        public void Sort(int[] arrayToSort)
        {
            int[] a = arrayToSort;

            // for each position in the sorted portion of the array
            for (int sortedEnd = 1; sortedEnd < a.Length; sortedEnd++)
            {
                // save the new val to be inserted into sorted list
                int newVal = a[sortedEnd];

                // find position to insert the new val
                int insertAt = 0;
                while (newVal >= a[insertAt] && insertAt < sortedEnd)
                {
                    insertAt++;
                }

                // shift the right side of sorted portion to make room for new val
                for (int i = sortedEnd; i >= insertAt + 1; i--)
                {
                    a[i] = a[i - 1];
                }

                // set the new val in the correct pos
                a[insertAt] = newVal;
            }
        }
    }
}
