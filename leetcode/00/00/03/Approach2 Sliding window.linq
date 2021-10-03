<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 3. Longest Substring Without Repeating Characters
// https://leetcode.com/problems/longest-substring-without-repeating-characters/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int max = 0;
        int left = 0;
        int right = 0;
        var exist = new HashSet<char>();

        while (right < s.Length)
        {
            if (exist.Add(s[right]))
            {
                max = Math.Max(max, exist.Count);
                right++;
            }
            else
            {
                exist.Remove(s[left]);
                left++;
            }
        }

        return max;
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1
{
    public int LengthOfLongestSubstring(string s)
    {
        var left = 0;
        var right = 0;
        var max = 0;

        var seen = new HashSet<char>();

        while (right < s.Length)
        {
            if (seen.Contains(s[right]))
            {
                seen.Remove(s[left]);
                left++;
            }
            else
            {
                seen.Add(s[right]);
                right++;
                max = Math.Max(max, right - left);
            }
        }

        return max;
    }
}

[Test]
[TestCase("abcabcbb", 3)]
[TestCase("bbbbb", 1)]
[TestCase("pwwkew", 3)]
[TestCase("", 0)]
[TestCase(" ", 1)]
[TestCase("au", 2)]
[TestCase("dvdf", 3)]
public void SolutionTests(string s, int expected)
{
    var actual = new Solution().LengthOfLongestSubstring(s);
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