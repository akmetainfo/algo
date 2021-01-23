<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 383. Ransom Note
// https://leetcode.com/problems/ransom-note/

public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var chars = new int[26];
        
        foreach (var c in magazine)
        {
            chars[c - 'a']++;
        }

        foreach (var c in ransomNote)
        {
            if (chars[c - 'a']-- == 0)
            {
                return false;
            }
        }

        return true;
    }

    // all letters are lowercase, so new int[26] enough
    public bool CanConstructOld(string ransomNote, string magazine)
    {
        var chars = new int[256];

        foreach (var c in magazine)
        {
            chars[c]++;
        }

        foreach (var c in ransomNote)
        {
            chars[c]--;

            if (chars[c] < 0)
            {
                return false;
            }
        }

        return true;
    }
}

[Test]
[TestCase("a", "b", false)]
[TestCase("aa", "ab", false)]
[TestCase("aa", "aab", true)]
public void SolutionTests(string ransomNote, string magazine, bool expected)
{
    var actual = new Solution().CanConstruct(ransomNote, magazine);
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