using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Tests for <see cref="Solution"/>
    /// </summary>
    public class SolutionTests
    {
        [TestCase(new int[] { 2, 4, 8, 8, 8 }, new int[] { 2, 4, 8 })]
        public void Test01(int[] nums, int[] expected)
        {
            var actual = Solution.RemoveDuplicates(nums);
            Assert.AreEqual(expected, actual);
        }
    }
}