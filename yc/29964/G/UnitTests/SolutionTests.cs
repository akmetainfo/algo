using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Tests for <see cref="Solution"/>
    /// </summary>
    public class SolutionTests
    {
        //[TestCase(new int[] { }, 0)]
        //[TestCase(new int[] { 42 }, 500)]
        //[TestCase(new int[] { 1, 2, 3, 4 }, 5000)]
        //[TestCase(new int[] { 5, 5, 5, 5 }, 2000)]
        [TestCase(new int[] { 4, 2, 3, 3 }, 3000)]
        public void Test01(int[] nums, int expected)
        {
            var actual = Solution.Bonuses(nums);
            Assert.AreEqual(expected, actual);
        }
    }
}