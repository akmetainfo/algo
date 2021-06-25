<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 66. Plus One
// https://leetcode.com/problems/plus-one/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
[TestCase(new int[] { 4, 3, 2, 1 }, new int[] { 4, 3, 2, 2 })]
[TestCase(new int[] { 0 }, new int[] { 1 })]
[TestCase(new int[] { 9 }, new int[] { 1, 0 })]
[TestCase(new int[] { 9, 9}, new int[] { 1, 0, 0 })]
[TestCase(new int[] { 9, 9, 9}, new int[] { 1, 0, 0, 0 })]
public void SolutionTests(int[] nums, int[] expectedArr)
{
    var actual = new Solution().PlusOne(nums);
    Assert.That(actual, Is.EqualTo(expectedArr));
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