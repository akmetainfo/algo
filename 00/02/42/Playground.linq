<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 242. Valid Anagram
// https://leetcode.com/problems/valid-anagram/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase("a", "ab", false)]
[TestCase("anagram", "nagaram", true)]
[TestCase("rat", "car", false)]
public void SolutionTests(string s, string t, bool expected)
{
    var actual = new Solution().IsAnagram(s, t);
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