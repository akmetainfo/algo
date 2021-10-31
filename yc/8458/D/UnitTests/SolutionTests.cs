using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Tests for <see cref="Solution"/>
    /// </summary>
    public class SolutionTests
    {
        [TestCase("ab", "aabbccd", 4)]
        public void Test01(int n, int expected)
        {
            var actual = Solution.ValidParentheses(n);
            Assert.AreEqual(expected, actual);
        }
    }
}