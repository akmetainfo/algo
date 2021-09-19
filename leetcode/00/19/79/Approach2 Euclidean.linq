<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1979. Find Greatest Common Divisor of Array
// https://leetcode.com/problems/find-greatest-common-divisor-of-array/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution
{
    public int FindGCD(int[] nums)
    {
        var min = nums.Min();
        var max = nums.Max();

        return GCD(min, max);
    }

    // https://en.wikipedia.org/wiki/Greatest_common_divisor
    // https://en.wikipedia.org/wiki/Euclidean_algorithm
    // https://stackoverflow.com/a/41766138/5752652
    // https://stackoverflow.com/q/3980416/5752652
    /*
        Time: O(log N) worst case, O(1) best case
        Space: O(1)
    */
    private static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}

[Test]
[TestCase(new int[] { 2, 5, 6, 9, 10 }, 2)]
[TestCase(new int[] { 7, 5, 6, 8, 3 }, 1)]
[TestCase(new int[] { 3, 3 }, 3)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().FindGCD(nums);
    Assert.That(actual, Is.EqualTo(expected));
}

#region unit tests runner

void Main()
{
    var workDir = Path.Combine(Util.MyQueriesFolder, "nunit-work");

    var args = new string[]
    {
         "-noheader",
         $"--work={workDir}",
    };

    RunUnitTests(args);
}

void RunUnitTests(string[] args, Assembly assembly = null)
{
    Console.SetOut(new NoDisposeTextWriter(Console.Out));
    Console.SetError(new NoDisposeTextWriter(Console.Error));
    new AutoRun(assembly ?? Assembly.GetExecutingAssembly()).Execute(args);
}

// https://stackoverflow.com/q/52883672/5752652
class NoDisposeTextWriter : TextWriter
{
    private readonly TextWriter writer;
    public NoDisposeTextWriter(TextWriter writer) => this.writer = writer;

    public override Encoding Encoding => writer.Encoding;
    public override IFormatProvider FormatProvider => writer.FormatProvider;
    public override void Write(char value) => writer.Write(value);
    public override void Flush() => writer.Flush();
    // forward all other overrides as necessary

    protected override void Dispose(bool disposing)
    {
        // no nothing
    }
}

#endregion