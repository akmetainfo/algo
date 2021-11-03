<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 70. Climbing Stairs
// https://leetcode.com/problems/climbing-stairs/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int ClimbStairs(int n)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(0, 0)]
[TestCase(1, 1)]
[TestCase(2, 2)]
[TestCase(3, 3)]
[TestCase(4, 5)]
[TestCase(5, 8)]
[TestCase(6, 13)]
[TestCase(7, 21)]
public void SolutionTests(int n, int expected)
{
    var actual = new Solution().ClimbStairs(n);
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