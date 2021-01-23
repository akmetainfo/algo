<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 383. Ransom Note
// https://leetcode.com/problems/ransom-note/

/*
    Time: O(N+M)
    Space: O(M) for store dictionary
    
    N - length of ransomNote, M - length of magazine
*/
public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        if (ransomNote.Length > magazine.Length)
            return false;

        var dict = new Dictionary<char, int>(magazine.Length);

        foreach (var c in magazine)
        {
            if (!dict.ContainsKey(c))
            {
                dict[c] = 0;
            }

            dict[c]++;
        }

        foreach (var c in ransomNote)
        {
            if (!dict.ContainsKey(c) || dict[c] == 0)
            {
                return false;
            }

            dict[c]--;
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