<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 389. Find the Difference
// https://leetcode.com/problems/find-the-difference/

/*
    Time: O(m * n), where m = s.Length, n = t.Length
    Space: O(n), where n = s.Length
*/
public class Solution
{
    public char FindTheDifference(string s, string t)
    {
        var hs = new List<char>(s);
        foreach (var c in t)
        {
            if (hs.Contains(c))
            {
                hs.Remove(c);
            }
            else
            {
                return c;
            }
        }

        throw new Exception("Something went wrong. Is input correct?");
    }
}

[Test]
[TestCase("abcd", "abcde", 'e')]
[TestCase("", "y", 'y')]
[TestCase("a", "aa", 'a')]
[TestCase("ae", "aea", 'a')]
[TestCase("aab", "aabc", 'c')]
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