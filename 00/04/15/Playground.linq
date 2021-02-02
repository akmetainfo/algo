<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 415. Add Strings
// https://leetcode.com/problems/add-strings/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public string AddStrings(string num1, string num2)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase("0", "0", "0")]
[TestCase("0", "2", "2")]
[TestCase("2", "0", "2")]
[TestCase("1", "9", "10")]
[TestCase("100", "201", "301")]
[TestCase("100", "1201", "1301")]
public void SolutionTests(string num1, string num2, string expected)
{
    var actual = new Solution().AddStrings(num1, num2);
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