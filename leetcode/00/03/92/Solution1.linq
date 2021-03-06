<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 392. Is Subsequence
// https://leetcode.com/problems/is-subsequence/

/*
    Time: O(n), where n = max from s.Length and t.Length
    Space: O(m), where m = s.Length (for store queue)
*/
public class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0)
            return true;

        var queue = new Queue<char>(s);

        for (int i = 0; i < t.Length; i++)
        {
            if (queue.Count == 0)
                return false;

            if (queue.Peek() == t[i])
                queue.Dequeue();
        }

        return queue.Count == 0;
    }
}

/*
    Time: O(n), where n = max from s.Length and t.Length
    Space: O(m), where m = t.Length (for store queue)
*/
public class Solution1
{
    public bool IsSubsequence(string s, string t)
    {
        var queue = new Queue<char>(t);

        var i = 0;
        while (i < s.Length)
        {
            if (queue.Count() == 0)
                return false;

            if (s[i] == queue.Dequeue())
                i++;
        }
        return i == s.Length;
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