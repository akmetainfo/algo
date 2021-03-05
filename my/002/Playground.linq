<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// Shift Array Left

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public void Left(int[] nums, int from, int filler)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new int[] { }, -1, 0, new int[] { })]
[TestCase(new int[] { }, 0, 0, new int[] { })]
[TestCase(new int[] { }, 1, 0, new int[] { })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, -1, 0, new int[] { 1, 2, 3, 4, 5, 6 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 0, new int[] { 2, 3, 4, 5, 6, 0 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 0, new int[] { 1, 3, 4, 5, 6, 0 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 0, new int[] { 1, 2, 4, 5, 6, 0 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 0, new int[] { 1, 2, 3, 5, 6, 0 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 4, 0, new int[] { 1, 2, 3, 4, 6, 0 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 5, 0, new int[] { 1, 2, 3, 4, 5, 0 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6, 0, new int[] { 1, 2, 3, 4, 5, 6 })]
public void SolutionTests(int[] nums, int from, int filler, int[] expected)
{
    new Solution().Left(nums, from, filler);
    Assert.That(nums, Is.EqualTo(expected));
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