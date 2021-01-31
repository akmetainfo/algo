<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 500. Keyboard Row
// https://leetcode.com/problems/keyboard-row/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public string[] FindWords(string[] words)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new string[] { "Hello", "Alaska", "Dad", "Peace" }, new string[] { "Alaska", "Dad" })]
[TestCase(new string[] { "omk" }, new string[] { })]
[TestCase(new string[] { "adsdf","sfd" }, new string[] { "adsdf","sfd" })]
public void SolutionTests(string[] words, string[] expectedResult)
{
    var result = new Solution().FindWords(words);
    Assert.That(expectedResult, Is.EquivalentTo(result));
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