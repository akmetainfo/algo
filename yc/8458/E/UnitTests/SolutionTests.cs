using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Tests for <see cref="Solution"/>
    /// </summary>
    public class SolutionTests
    {
        [TestCase("qiu", "iuq", true)]
        public void Test01(string a, string b, bool expected)
        {
            var actual = Solution.IsAnagram(a, b);
            Assert.AreEqual(expected, actual);
        }
    }
}