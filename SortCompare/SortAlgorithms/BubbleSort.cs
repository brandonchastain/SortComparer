using System;
namespace SortCompare.SortAlgorithms
{
    public class BubbleSort : ISortAlgorithm
    {
        public void Sort(int[] arrayToSort)
        {
            int[] a = arrayToSort;
            bool didSwap = true; // we know bubble sort is complete after a single pass with no swaps

            while (didSwap)
            {
                didSwap = false;

                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i - 1] > a[i])
                    {
                        int temp = a[i - 1];
                        a[i - 1] = a[i];
                        a[i] = temp;
                        didSwap = true;
                    }
                }
            }
        }
    }
}
