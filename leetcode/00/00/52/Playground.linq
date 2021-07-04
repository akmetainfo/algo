<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 52. N-Queens II
// https://leetcode.com/problems/n-queens-ii/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int TotalNQueens(int n)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(1, 1)]
[TestCase(2, 0)]
[TestCase(3, 0)]
[TestCase(4, 2)]
[TestCase(5, 10)]
[TestCase(6, 4)]
[TestCase(7, 40)]
[TestCase(8, 92)]
[TestCase(9, 352)]
[TestCase(10, 724)]
public void SolutionTests(int n, int expected)
{
    var actual = new Solution().TotalNQueens(n);
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