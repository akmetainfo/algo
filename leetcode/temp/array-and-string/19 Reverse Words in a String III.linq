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
[TestCase("", "")]
[TestCase("abc", "cba")]
[TestCase("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
public void ReverseWordsInString3(string s, string expected)
{
	var actual = new Solution().ReverseWords(s);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/explore/item/1165
#region Условие задачи
/*

Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

Example 1:

Input: "Let's take LeetCode contest"
Output: "s'teL ekat edoCteeL tsetnoc"

Note: In the string, each word is separated by single space and there will not be any extra space in the string. 

*/

#endregion

public class Solution
{
	public string ReverseWords(string s)
	{
		var sb = new StringBuilder(s.Length);
		var queue = new Stack<char>(s.Length);
		
		var times = 0;
		for (int i = 0; i < s.Length; i++)
		{
			if(s[i] != ' ')
			{
				queue.Push(s[i]);
				times++;
			}
			else
			{
				while(times != 0)
				{
					sb.Append(queue.Pop());
					times--;
				}
				sb.Append(' ');
			}
		}

		while (times != 0)
		{
			sb.Append(queue.Pop());
			times--;
		}

		return sb.ToString();
	}
}

#region Хорошие алгоритмы-победители

// Мой ответ использовал Stack - не знаю, стоило ли так делать или стоило честно мудохаться только с базовыми типами

//
public string ReverseWords1(string s)
{
	string[] words = s.Split(' ');
	StringBuilder ans = new StringBuilder();
	foreach (var word in words)
	{
		char[] arr = word.ToCharArray();
		Array.Reverse(arr);
		ans = ans.Append(arr);
		ans = ans.Append(" ");
		//string output = new string(arr)+" ";
		//ans=ans.Append(output);
	}
	return ans.ToString().Trim();
}

//
public string ReverseWords2(string s)
{
	char[] chars = s.ToCharArray();

	for (int i = 0; i < chars.Length; i++)
	{
		if (chars[i] != ' ')
		{
			int j = i;
			while (j < chars.Length && chars[j] != ' ')
				j++;

			int k = j - 1;
			while (i < k)
			{
				char temp = chars[i];
				chars[i] = chars[k];
				chars[k] = temp;
				i++;
				k--;
			}

			i = j;
		}
	}

	return new string(chars);
}

//
public class Solution3
{
	public string ReverseWords(string s)
	{
		int startIndex = 0;
		int endIndex = 0;
		char[] str = s.ToCharArray();
		while (endIndex < s.Length)
		{
			if (endIndex == s.Length - 1)
				reverseWord(str, startIndex, endIndex);

			if (str[endIndex] == ' ')
			{
				reverseWord(str, startIndex, endIndex - 1);
				startIndex = endIndex + 1;
			}
			endIndex++;
		}
		return new string(str);
	}

	private void reverseWord(char[] cArr, int startIndex, int endIndex)
	{
		if (startIndex < endIndex)
		{
			for (int i = startIndex, j = endIndex; i <= startIndex + (endIndex - startIndex) / 2; i++, j--)
			{
				char temp = cArr[i];
				cArr[i] = cArr[j];
				cArr[j] = temp;
			}
		}
	}
}

//
public string ReverseWords4(string s)
{
	string[] words = s.Split(' ');
	for (int i = 0; i < words.Length; i++)
	{
		char[] arr = words[i].ToCharArray();
		Array.Reverse(arr);
		words[i] = new string(arr);
	}
	return String.Join(" ", words);
}

// Типа лучший
public class Solution5
{
	public string ReverseWords(string s)
	{
		int startIndex = 0;
		int endIndex = 0;
		char[] str = s.ToCharArray();
		while (endIndex < s.Length)
		{
			if (endIndex == s.Length - 1)
				reverseWord(str, startIndex, endIndex);

			if (str[endIndex] == ' ')
			{
				reverseWord(str, startIndex, endIndex - 1);
				startIndex = endIndex + 1;
			}
			endIndex++;
		}
		return new string(str);
	}

	private void reverseWord(char[] cArr, int startIndex, int endIndex)
	{
		if (startIndex < endIndex)
		{
			for (int i = startIndex, j = endIndex; i <= startIndex + (endIndex - startIndex) / 2; i++, j--)
			{
				char temp = cArr[i];
				cArr[i] = cArr[j];
				cArr[j] = temp;
			}
		}
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