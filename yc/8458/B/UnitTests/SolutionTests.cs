using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Tests for <see cref="Solution"/>
    /// </summary>
    public class SolutionTests
    {
        [TestCase(new int[] { 5, 1, 0, 1, 0, 1 }, 1)]
        public void Test01(int[] nums, int expected)
        {
            var actual = Solution.LongestSeries(nums);
            Assert.AreEqual(expected, actual);
        }
    }
}