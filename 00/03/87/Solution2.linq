<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 387. First Unique Character in a String
// https://leetcode.com/problems/first-unique-character-in-a-string/

public class Solution
{
    public int FirstUniqChar(string s)
    {
        var charAndCount = new int[26];

        foreach (var c in s)
        {
            charAndCount[c - 'a']++;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (charAndCount[s[i] - 'a'] == 1)
            {
                return i;
            }
        }

        return -1;
    }
    
    // can be optimized as new int[26]
    public int FirstUniqCharOld(string s)
    {
        var charAndCount = new int[256];

        foreach (var c in s)
        {
            charAndCount[c]++;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (charAndCount[s[i]] == 1)
            {
                return i;
            }
        }
        
        return -1;
    }
}

[Test]
[TestCase("leetcode", 0)]
[TestCase("loveleetcode", 2)]
[TestCase("abab", -1)]
public void SolutionTests(string s, int expected)
{
    var actual = new Solution().FirstUniqChar(s);
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