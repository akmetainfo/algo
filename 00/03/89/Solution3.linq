<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 389. Find the Difference
// https://leetcode.com/problems/find-the-difference/

/*
    Time: O(m + n), where m = s.Length, n = t.Length
    Space: O(1)
*/
public class Solution
{
    // because both string consists of lower-case English letters we can use int[26] only
    public char FindTheDifference(string s, string t)
    {
        var frequency = new int[256];
        
        foreach (var c in s)
            frequency[c]++;

        foreach (var c in t)
            frequency[c]--;

        for (int i = 0; i < 256; i++)
        {
            if (frequency[i] < 0)
                return (char)i;
        }

        throw new Exception("No difference");
    }
}

[Test]
[TestCase("abcd", "abcde", 'e')]
[TestCase("", "y", 'y')]
[TestCase("a", "aa", 'a')]
[TestCase("ae", "aea", 'a')]
public void SolutionTests(string s, string t, char expected)
{
    var actual = new Solution().FindTheDifference(s, t);
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