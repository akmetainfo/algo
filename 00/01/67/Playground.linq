<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 167. Two Sum II - Input array is sorted
// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 2 })]
[TestCase(new int[] { 2, 3, 4 }, 6, new int[] { 1, 3 })]
[TestCase(new int[] { -1, 0 }, -1, new int[] { 1, 2 })]
[TestCase(new int[] { 0, 0, 3, 4 }, 0, new int[] { 1, 2 })]
public void SolutionTests(int[] nums, int target, int[] expected)
{
    var actual = new Solution().TwoSum(nums, target);
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