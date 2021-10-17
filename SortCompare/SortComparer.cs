using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SortCompare.SortAlgorithms;

namespace SortCompare
{
    public class SortComparer
    {
        private object lockObject = new object();

        public CompareSortResult CompareSorts(int arraySize)
        {
            const int min = 0;
            const int max = 1000;

            var rand = new Random();
            int[] array = Enumerable
                .Repeat(0, arraySize)
                .Select(i => rand.Next(min, max))
                .ToArray();

            var result = new CompareSortResult(array);

            Parallel.ForEach(GetSortAlgos(), alg =>
            {
                int[] tempArray = (int[])array.Clone();

                var sw = Stopwatch.StartNew();
                alg.Sort(tempArray);
                sw.Stop();

                string time = $"{sw.ElapsedMilliseconds}ms";
                if (!AssertSorted(tempArray))
                {
                    time = "ERROR: not correctly sorted";
                }

                lock(this.lockObject)
                {
                    result.SortTimes.Add(alg.GetType().Name, time);
                }
            });

            return result;
        }

        private IEnumerable<ISortAlgorithm> GetSortAlgos()
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISortAlgorithm).IsAssignableFrom(x)
                            && !x.IsInterface
                            && !x.IsAbstract)
                .Except(new[] { typeof(BubbleSort), typeof(InsertionSort), typeof(SelectionSort) });

            foreach (var type in types)
            {
                yield return (ISortAlgorithm)Activator.CreateInstance(type);
            }
        }


        private bool AssertSorted(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}