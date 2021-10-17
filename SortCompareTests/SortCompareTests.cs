using System;
using Xunit;
using Xunit.Abstractions;
using SortCompare;

namespace SortCompareTests
{
    public class SortComparerTests
    {
        private ITestOutputHelper logger;

        public SortComparerTests(ITestOutputHelper output)
        {
            this.logger = output;
        }

        [Fact]
        public void TestCompareSortWorks()
        {
            var comparer = new SortComparer();

            CompareSortResult res = comparer.CompareSorts(1000);
            this.logger.WriteLine($"res: {res}");

            Assert.NotNull(res);
            Assert.NotNull(res.SortTimes);
            Assert.True(res.SortTimes.Count > 0);
        }
    }
}
