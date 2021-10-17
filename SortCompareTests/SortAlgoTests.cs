using System;
using Xunit;
using SortCompare.SortAlgorithms;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace SortCompareTests
{
    public class SortAlgoTests
    {
        private ITestOutputHelper logger;

        public SortAlgoTests(ITestOutputHelper output)
        {
            this.logger = output;
        }

        [Fact]
        public void TestSortWorks()
        {
            var sorts = this.GetSortAlgos();

            foreach (var sort in sorts)
            {
                var arr = new[] { 10, 9, 8, 700, 200, 1, 33 };

                // create a known-sorted array
                var arrCopy = new int[arr.Length];
                Array.Copy(arr, arrCopy, arr.Length);
                Array.Sort(arrCopy);

                sort.Sort(arr);

                this.logger.WriteLine($"exp: {string.Join(",", arrCopy)}");
                this.logger.WriteLine($"res: {string.Join(",", arr)}");

                Assert.Equal(arrCopy, arr);
            }
        }

        private IEnumerable<ISortAlgorithm> GetSortAlgos()
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISortAlgorithm).IsAssignableFrom(x)
                            && !x.IsInterface
                            && !x.IsAbstract);

            foreach (var type in types)
            {
                yield return (ISortAlgorithm)Activator.CreateInstance(type);
            }
        }
    }
}
