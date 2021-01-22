<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

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

// Define other methods and classes here

[Test]
[TestCase("", "", 0)]
[TestCase("Hello", "ll", 2)]
[TestCase("Hello, Willy", "ll", 2)]
[TestCase("aaaaa", "bba", -1)]
[TestCase("123456789abc", "abcd", -1)]
[TestCase("mississippi", "issip", 4)]
public void Implement_strStr(string haystack, string needle, int expected)
{
	var actual = new Solution().StrStr(haystack, needle);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/explore/item/1161
#region Условие задачи
/*

Implement strStr().

Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

Clarification:

What should we return when needle is an empty string? This is a great question to ask during an interview.

For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().

 

Example 1:

Input: haystack = "hello", needle = "ll"
Output: 2

Example 2:

Input: haystack = "aaaaa", needle = "bba"
Output: -1

Example 3:

Input: haystack = "", needle = ""
Output: 0

 

Constraints:

    0 <= haystack.length, needle.length <= 5 * 104
    haystack and needle consist of only lower-case English characters.



*/

#endregion

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
					{
						break;
					}

					if (haystack[i + pointer] != needle[pointer])
					{
						break;
					}
					
					pointer++;
					
					if(pointer == needle.Length)
						break;
				}
				
				if(pointer == needle.Length)
					return i;
			}
		}

		return -1;
	}

	public int StrStr1(string haystack, string needle)
	{
		if (needle == string.Empty)
			return 0;

		if (haystack.Length < needle.Length)
			return -1;

		var i = 0;
		var found = false;
		var pointer = 0;
		var start = 0;
		while (i < haystack.Length)
		{
			if (found)
			{
				if (haystack[i] == needle[pointer])
				{
					pointer++;
					if (pointer == needle.Length)
						break;
				}
				else
				{
					found = false;
					pointer = 0;
					i = start - 1;
				}
			}
			else
			{
				if (haystack[i] == needle[pointer])
				{
					found = true;
					start = i;
					pointer++;
					if (pointer == needle.Length)
						break;
				}
			}

			i++;
		}

		if (found && pointer == needle.Length)
			return i - needle.Length + 1;

		return -1;
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще находится даже не в хвосте нормального распределения, но на километр до этой точки



#endregion

#region unit tests runner

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