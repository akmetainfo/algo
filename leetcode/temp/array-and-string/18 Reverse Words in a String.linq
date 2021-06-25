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
[TestCase("   the sky    is blue", "blue is sky the")]
[TestCase("   the sky    is blue a", "a blue is sky the")]
//[TestCase("abc", "abc")]
//[TestCase("the sky is blue", "blue is sky the")]
public void ReverseWordsInString3(string s, string expected)
{
	var actual = new Solution().ReverseWords(s);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/explore/item/1164
#region Условие задачи
/*

Given an input string s, reverse the order of the words.

A word is defined as a sequence of non-space characters. The words in s will be separated by at least one space.

Return a string of the words in reverse order concatenated by a single space.

Note that s may contain leading or trailing spaces or multiple spaces between two words. The returned string should only have a single space separating the words. Do not include any extra spaces.

 

Example 1:

Input: s = "the sky is blue"
Output: "blue is sky the"

Example 2:

Input: s = "  hello world  "
Output: "world hello"
Explanation: Your reversed string should not contain leading or trailing spaces.

Example 3:

Input: s = "a good   example"
Output: "example good a"
Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.

Example 4:

Input: s = "  Bob    Loves  Alice   "
Output: "Alice Loves Bob"

Example 5:

Input: s = "Alice does not even like bob"
Output: "bob like even not does Alice"

 

Constraints:

    1 <= s.length <= 104
    s contains English letters (upper-case and lower-case), digits, and spaces ' '.
    There is at least one word in s.

 

Follow up:

    Could you solve it in-place with O(1) extra space?


*/

#endregion

public class Solution
{
	public string ReverseWords(string s)
	{
		if(s.Length == 1)
			return s;
			
		var sb = new StringBuilder(s.Length);

		var wordBegins = s[s.Length - 1] == ' ';
		int wordStart = 0;
		int wordEnd = 0;

		var i = s.Length - 1;
		
		while(i >= 0)
		{
			if(wordBegins)
			{
				if (s[i] == ' ')
				{
					wordBegins = false;
					wordStart = i + 1;
					
					if(sb.Length != 0)
						sb.Append(" ");

					//$"word is = '{s.Substring(wordStart, wordEnd - wordStart + 1)}'".Dump();
					sb.Append(s.Substring(wordStart, wordEnd - wordStart + 1));
				}
				else
				{
					// Do nothing?
				}
			}
			else
			{
				if (s[i] == ' ')
				{
					// Do nothing?
				}
				else
				{
					wordBegins = true;
					wordEnd = i;
				}
			}
			//$"s={s[i]}".Dump();
			i--;
		}

		return sb.ToString();
	}
}

#region Хорошие алгоритмы-победители

// Мой ответ

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