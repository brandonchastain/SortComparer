using System;
namespace SortCompare.SortAlgorithms
{
    public class QuickSort : ISortAlgorithm
    {
        private readonly Random random;

        public QuickSort()
        {
            this.random = new Random();
        }

        public void Sort(int[] arrayToSort)
        {
            SortHelper(arrayToSort, 0, arrayToSort.Length - 1);
        }

        private void SortHelper(int[] a, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            // choose pivot
            int pivot = this.random.Next(end - start) + start;
            int pivotVal = a[pivot];

            // swap pivot with end element to get it out of the way
            a[pivot] = a[end];
            a[end] = pivotVal;

            // arrange elements less than pivot on the left,
            // greater than pivot on the right.
            int i = start;
            int j = start;

            while (j < end)
            {
                if (a[j] <= pivotVal)
                {
                    int temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                }

                j++;
            }

            // swap end and pivot back
            a[end] = a[i];
            a[i] = pivotVal;

            // Quick sort the partitions on each side of the pivot
            SortHelper(a, start, i - 1);
            SortHelper(a, i + 1, end);
        }
    }
}
