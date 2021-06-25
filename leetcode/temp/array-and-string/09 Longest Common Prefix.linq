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
//[TestCase(new string[] { "flower", "flow", "flight" }, "fl")]
//[TestCase(new string[] { "dog", "racecar", "car" }, "")]
//[TestCase(new string[] { }, "")]
//[TestCase(new string[] { "a", "abc", "abc" }, "a")]
[TestCase(new string[] { "ab", "a" }, "a")]
//[TestCase(new string[] { "abc", "abc", "abc" }, "abc")]
//[TestCase(new string[] { "abcdef" }, "abcdef")]
public void LongestCommonPrefix(string[] strs, string expected)
{
	var actual = new Solution().LongestCommonPrefix(strs);
	Assert.That(actual, Is.EqualTo(expected));
}


// https://leetcode.com/explore/item/1162
#region Условие задачи
/*

Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"

Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.

 

Constraints:

    0 <= strs.length <= 200
    0 <= strs[i].length <= 200
    strs[i] consists of only lower-case English letters.

*/

#endregion

public class Solution
{
	public string LongestCommonPrefix(string[] strs)
	{
		if(strs.Length == 0)
			return string.Empty;
			
		if(strs.Length == 1)
			return strs[0];
			
		var sb = new StringBuilder();
		
		var index = 0;
		
		while(true)
		{
			if(strs[0].Length == index)
				break;
				
			bool allSame = true;
			
			for (int i = 1; i < strs.Length; i++)
			{
				if(strs[i].Length <= index || strs[0][index] != strs[i][index])
				{
					allSame = false;
					break;
				}
			}
			
			if(allSame)
			{
				sb.Append(strs[0][index]);
				index++;
			}
			else
			{
				break;
			}
		}
		
		return sb.ToString();
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще лучше чем вершина нормального распределения

// Решение из моей группы
public string LongestCommonPrefix1(string[] strs)
{
	int i = 0;
	int j = 0;
	if (strs == null || strs.Length == 0)
	{
		return "";
	}
	int min = strs[0].Length;
	for (int k = 0; k < strs.Length; k++)
	{
		if (strs[k].Length < min)
		{
			min = strs[k].Length;
		}

	}
	StringBuilder sb = new StringBuilder();
	for (i = 0; i < min; i++)
	{
		char c = strs[0][i];
		for (j = 1; j < strs.Length; j++)
		{
			if (strs[j][i] != c)
			{
				return sb.ToString();
			}
		}
		sb.Append(c);
	}
	return sb.ToString();

}

// Лучше моего (Вот этот предварительный поиск строки похоже и делает эти решения лучше моего)
public string LongestCommonPrefix2(string[] strs)
{
	if (strs == null || strs.Length == 0) return "";

	var result = new StringBuilder();

	int length = int.MaxValue;
	foreach (var str in strs)
	{
		length = Math.Min(length, str.Length);
	}

	for (int i = 0; i < length; i++)
	{
		var ch = strs[0][i];
		var theSame = true;
		for (int j = 1; j < strs.Length; j++)
		{
			theSame = theSame & ch == strs[j][i];
		}

		if (theSame) result.Append(ch); else break;
	}

	return result.ToString();
}

// Лол, решение сильно быстрее - и оно использует linq
public string LongestCommonPrefix3(string[] strs)
{
	string retVal = string.Empty;

	if (strs.Length > 0)
	{
		string longest = strs.OrderByDescending(item => item.Length).First();
		for (int x = 0; x < longest.Length; x++)
		{
			try
			{
				if (strs.Any(item => item[x] != strs[0][x]))
				{
					break;
				}
				retVal += strs[0][x];
			}
			catch (Exception)
			{
				break;
			}
		}
	}

	return retVal;
}

// Пообедитель
public string LongestCommonPrefix4(string[] strs)
{
	if (strs.Length == 0)
	{
		return "";
	}
	if (strs.Length == 1)
	{
		return strs[0];
	}

	var sb = new StringBuilder();

	var minLength = strs.Min(x => x.Length);

	var found = false;

	for (var i = 0; i < minLength && !found; i++)
	{
		for (var j = 0; j < strs.Length - 1; j++)
		{
			if (strs[j][i] != strs[j + 1][i])
			{
				found = true;
				break;
			}
			if (j == strs.Length - 2)
			{
				sb.Append(strs[j][i]);
			}
		}
	}

	return sb.ToString();
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