<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 3. Longest Substring Without Repeating Characters
// https://leetcode.com/problems/longest-substring-without-repeating-characters/

/*
    Time: O(N^3)
    Space: O(N)
    
    Optimized bruteforce: max len cannot be more than distinct chars
*/
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0)
            return 0;

        var curMax = 0;

        for (var len = 1; len <= s.Distinct().Count(); len++)
        {
            for (var i = 0; i < s.Length - len + 1; i++)
            {
                var seen = new HashSet<char>();
                var stringContainsRepeatingChars = false;
                for (int k = 0; k < len; k++)
                {
                    if (seen.Contains(s[i + k]))
                    {
                        stringContainsRepeatingChars = true;
                        break;
                    }
                    else
                    {
                        seen.Add(s[i + k]);
                    }
                }
                if (stringContainsRepeatingChars == false && len > curMax)
                {
                    curMax = len;
                    break;
                }
            }
        }

        return curMax;
    }
}

/*
    Time: O(N^3)
    Space: O(N)
    
    Time limit exceed
*/
public class Solution1
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0)
            return 0;

        var curMax = 0;

        for (var len = 1; len <= s.Length; len++)
        {
            for (var i = 0; i < s.Length - len + 1; i++)
            {
                var seen = new HashSet<char>();
                var stringContainsRepeatingChars = false;
                for (int k = 0; k < len; k++)
                {
                    if (seen.Contains(s[i + k]))
                    {
                        stringContainsRepeatingChars = true;
                        break;
                    }
                    else
                    {
                        seen.Add(s[i + k]);
                    }
                }
                if (stringContainsRepeatingChars == false && len > curMax)
                {
                    curMax = len;
                    break;
                }
            }
        }

        return curMax;
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