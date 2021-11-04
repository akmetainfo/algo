using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Tests for <see cref="Solution"/>
    /// </summary>
    public class SolutionTests
    {
        [TestCase(6, 5, 10, new int[] { 1, 2, 3, 4, 5, 6 }, 10)]
        [TestCase(5, 7, 12, new int[] { 5, 22, 17, 13, 8 }, 27)]
        public void Test01(int n, int x, int k, int[] deadlines, int expected)
        {
            var actual = Solution.TechDept(n, x, k, deadlines);
            Assert.AreEqual(expected, actual);
        }
    }
}