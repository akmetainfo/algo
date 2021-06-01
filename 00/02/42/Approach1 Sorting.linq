<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 242. Valid Anagram
// https://leetcode.com/problems/valid-anagram/

/*
    Time: O(n log n)Assume that n is the length of s, sorting costs O(nlogn) and comparing two strings costs O(n). Sorting time dominates and the overall time complexity is O(nlogn).
    Space: O(1)  Space depends on the sorting implementation which, usually, costs O(1) auxiliary space if heapsort is used.
*/
public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        char[] str1 = s.ToCharArray();
        char[] str2 = t.ToCharArray();
        Array.Sort(str1);
        Array.Sort(str2);
        return str1.SequenceEqual(str2);
    }
}

[Test]
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