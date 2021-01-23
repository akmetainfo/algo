<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 387. First Unique Character in a String
// https://leetcode.com/problems/first-unique-character-in-a-string/

/*
    Time: O(n) one pass solution
    Space: O(1), alphabet array only

*/
public class Solution
{
    public int FirstUniqChar(string s)
    {
        const int noSuchChar = -3; // must be less zero
        const int charIsDup = -2; // must be less zero

        const int minDoesntExist = -1; // return value when all chars isn't unique

        var chars = new int[26]; // store first position or noSuchChar or charIsDup

        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = noSuchChar;
        }

        for (int i = 0; i < s.Length; i++)
        {
            int c = s[i] - 'a';

            switch (chars[c])
            {
                case noSuchChar:
                    chars[c] = i;
                    break;

                case charIsDup:
                    break;

                default:
                    chars[c] = charIsDup;
                    break;
            }
        }

        var min = minDoesntExist;

        foreach (var element in chars)
        {
            if (element == noSuchChar || element == charIsDup)
                continue;

            if (min != minDoesntExist && element < min || min == minDoesntExist && element >= 0)
            {
                min = element;
            }
        }

        return min;
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