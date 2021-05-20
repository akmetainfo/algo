<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 03 C# Binary search in sorted array

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int Search(int[] nums, int target)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new int[] { }, 42, -1)]

[TestCase(new int[] { 7 }, 1, -1)]
[TestCase(new int[] { 7 }, 7, 0)]
[TestCase(new int[] { 7 }, 9, -1)]

[TestCase(new int[] { 1, 2, 3, 3, 4 }, 0, -1)]
[TestCase(new int[] { 1, 2, 3, 3, 4 }, 2, 1)]
//[TestCase(new int[] { 1, 2, 3, 3, 4 }, 3, 3)] // What expected here? Rightmost element
[TestCase(new int[] { 1, 2, 3, 3, 4 }, 4, 4)]
[TestCase(new int[] { 1, 2, 3, 3, 4 }, 5, -1)]
public void SolutionTests(int[] nums, int target, int expected)
{
    var actual = new Solution().Search(nums, target);
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