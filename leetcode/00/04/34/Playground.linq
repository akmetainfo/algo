<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 434. Number of Segments in a String
// https://leetcode.com/problems/number-of-segments-in-a-string/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int CountSegments(string s)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase("Hello, my name is John", 5)]
[TestCase("Hello", 1)]
[TestCase("", 0)]
[TestCase("                ", 0)]
[TestCase("Of all the gin joints in all the towns in all the world,   ", 13)]
[TestCase("   Hello", 1)]
public void SolutionTests(string s, int expected)
{
    var actual = new Solution().CountSegments(s);
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