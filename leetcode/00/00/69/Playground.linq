<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 69. Sqrt(x)
// https://leetcode.com/problems/sqrtx/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int MySqrt(int x)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(2, 1)]
[TestCase(4, 2)]
[TestCase(8, 2)]
[TestCase(2147302921, 46339)]
[TestCase(2147395599, 46339)]
[TestCase(2147483647, 46340)]
[TestCase(9, 3)]
[TestCase(100, 10)]
public void SolutionTests(int x, int expected)
{
    var actual = new Solution().MySqrt(x);
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