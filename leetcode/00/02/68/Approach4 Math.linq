<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 268. Missing Number
// https://leetcode.com/problems/missing-number/

/*
    Time: O(N)
    Space: O(1)
*/
/*
Total sum of  arithmetic progression is n * (n - 1) / 2
*/
public class Solution
{
    public int MissingNumber(int[] nums)
    {
        var sum = nums.Sum();
        var n = nums.Length;
        return n * (n - 1) / 2 - sum + n;
    }
}

[Test]
[TestCase(new int[] { 3, 0, 1 }, 2)]
[TestCase(new int[] { 0, 1 }, 2)]
[TestCase(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
[TestCase(new int[] { 0 }, 1)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().MissingNumber(nums);
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