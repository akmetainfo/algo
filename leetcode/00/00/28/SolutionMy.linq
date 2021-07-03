<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 28. Implement strStr()
// https://leetcode.com/problems/implement-strstr/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
	public int StrStr(string haystack, string needle)
	{
		if (needle == string.Empty)
			return 0;

		if (haystack.Length < needle.Length)
			return -1;

		for (int i = 0; i < haystack.Length; i++)
		{
			if (haystack[i] == needle[0])
			{
				var pointer = 0;
				while (true)
				{
					if (i + pointer >= haystack.Length)
						break;

					if (haystack[i + pointer] != needle[pointer])
						break;
					
					pointer++;
					
					if(pointer == needle.Length)
						return i;
				}
			}
		}

		return -1;
	}
}

[Test]
[TestCase("hello", "ll", 2)]
[TestCase("aaaaa", "bba", -1)]
[TestCase("", "", 0)]
public void SolutionTests(string haystack, string needle, int expected)
{
    var actual = new Solution().StrStr(haystack, needle);
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