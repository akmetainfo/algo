<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 896. Monotonic Array
// https://leetcode.com/problems/monotonic-array/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public bool IsMonotonic(int[] A)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new int[] { 1, 2, 2, 3 }, true)]
[TestCase(new int[] { 6, 5, 4, 4 }, true)]
[TestCase(new int[] { 1, 3, 2 }, false)]
[TestCase(new int[] { 1, 2, 4, 5 }, true)]
[TestCase(new int[] { 1, 1, 1 }, true)]
[TestCase(new int[] { 1, 3, 2 }, false)]
public void SolutionTests(int[] nums, bool expected)
{
    var actual = new Solution().IsMonotonic(nums);
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