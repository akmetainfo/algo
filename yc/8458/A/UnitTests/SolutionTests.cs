using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Tests for <see cref="Solution"/>
    /// </summary>
    public class SolutionTests
    {
        [TestCase("ab", "aabbccd", 4)]
        public void Test01(string jewels, string stones, int expected)
        {
            var actual = Solution.JewelAndStones(jewels, stones);
            Assert.AreEqual(expected, actual);
        }
    }
}