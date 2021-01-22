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
[TestCase("egg", "add", true)]
[TestCase("paper", "title", true)]
[TestCase("badc", "baba", false)]
[TestCase("bd", "bb", false)]
public void FindDiagonalOrder(string s, string t, bool expected)
{
	var actual = new Solution().IsIsomorphic(s,t);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/problems/isomorphic-strings/
#region Условие задачи
/*

Given two strings s and t, determine if they are isomorphic.

Two strings s and t are isomorphic if the characters in s can be replaced to get t.

All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character, but a character may map to itself.

 

Example 1:

Input: s = "egg", t = "add"
Output: true

Example 2:

Input: s = "foo", t = "bar"
Output: false

Example 3:

Input: s = "paper", t = "title"
Output: true

 

Constraints:

    1 <= s.length <= 5 * 104
    t.length == s.length
    s and t consist of any valid ascii character.

*/

#endregion

public class Solution
{
	public bool IsIsomorphic(string s, string t)
	{
		if (s.Length != t.Length)
			return false;

		var transforms = new Dictionary<char, char>();
		for (int i = 0; i < s.Length; i++)
		{
			if (transforms.ContainsKey(s[i]))
			{
				if (transforms[s[i]] != t[i])
					return false;
			}
			else
			{
				transforms.Add(s[i], t[i]);
			}
		}

		var chars = new HashSet<int>();

		foreach (var element in transforms.Values)
		{
			if (chars.Contains(element))
				return false;

			chars.Add(element);
		}

		return true;
	}
}

#region Хорошие алгоритмы-победители

// Моё решение на горе нормального распределения

// Решение из моей группы
public class Solution1
{
	public bool IsIsomorphic(string s, string t)
	{
		if (s.Length != t.Length) return false;
		Dictionary<char, char> dic = new Dictionary<char, char>();
		if (s.Length == 1) return true;

		for (int i = 0; i < s.Length; i++)
		{
			if (!dic.ContainsKey(s[i]))
			{
				if (dic.ContainsValue(t[i]))
				{
					return false;
				}
				else
				{
					dic.Add(s[i], t[i]);
				}
			}
			else if (dic[s[i]] != t[i])
			{
				return false;
			}
		}

		return true;
	}
}

// Чуть лучше

public class Solution2
{
	public bool IsIsomorphic(string s, string t)
	{
		var counts_s = new int[256];
		var counts_t = new int[256];
		for (var i = 0; i < s.Length; i++)
		{
			if (counts_s[s[i]] != counts_t[t[i]]) return false;
			counts_s[s[i]] = i + 1;
			counts_t[t[i]] = i + 1;
		}
		return true;
	}
}

// Резко лучше

public class Solution3
{
	public bool IsIsomorphic(string s, string t)
	{
		for (int i = 0; i < s.Length; ++i)
		{
			if (s.IndexOf(s[i], 0, i) != t.IndexOf(t[i], 0, i))
			{
				return false;
			}
		}
		return true;
	}
}

// Хм, снова вариант которым я проходил (но в одном же цикле!):

public class Solution4
{
	public bool IsIsomorphic(string s, string t)
	{
		if (s == null && t == null)
			return true;

		if (s == null ^ t == null)
			return false;

		if (s.Length != t.Length)
			return false;

		Dictionary<char, char> dict = new Dictionary<char, char>();
		HashSet<char> usedSet = new HashSet<char>();

		//StringBuilder sb = new StringBuilder();
		for (int i = 0; i < s.Length; ++i)
		{
			if (!dict.ContainsKey(s[i]))
			{
				if (usedSet.Contains(t[i]))
					return false;

				dict[s[i]] = t[i];
				usedSet.Add(t[i]);
			}

			if (dict[s[i]] != t[i])
				return false;
		}

		return true;
	}
}

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