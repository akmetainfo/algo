<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 392. Is Subsequence
// https://leetcode.com/problems/is-subsequence/

/*
    Time: O(n), where n = t.Length
    Space: O(1)
*/
public class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        if(s.Length == 0)
            return true;
            
        var si = 0;
        
        for (int ti = 0; ti < t.Length; ti++)
        {
            if(s[si] == t[ti])
                si++;

            if (si == s.Length)
                return true;
        }
        
        return false;
    }

    // same as above, minor differences
    public bool IsSubsequence2(string s, string t)
    {
        var j = 0;
        
        for (int i = 0; j < s.Length && i < t.Length; i++)
        {
            if (s[j] == t[i])
                j++;
        }

        return j == s.Length;
    }
}

[Test]
[TestCase("abc", "ahbgdc", true)]
[TestCase("axc", "ahbgdc", false)]
[TestCase("", "ahbgdc", true)]
public void SolutionTests(string s, string t, bool expected)
{
    var actual = new Solution().IsSubsequence(s, t);
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