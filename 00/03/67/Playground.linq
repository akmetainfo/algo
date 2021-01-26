<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 367. Valid Perfect Square
// https://leetcode.com/problems/valid-perfect-square/

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution
{
    public bool IsPerfectSquare(int num)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(1, true)]
[TestCase(2, false)]
[TestCase(3, false)]
[TestCase(4, true)]
[TestCase(5, false)]
[TestCase(6, false)]
[TestCase(7, false)]
[TestCase(8, false)]
[TestCase(9, true)]
[TestCase(14, false)]
[TestCase(16, true)]
public void SolutionTests(int nums, bool expected)
{
    var actual = new Solution().IsPerfectSquare(nums);
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