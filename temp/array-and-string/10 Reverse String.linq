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
[TestCase(new char[] { }, new char[] { })]
[TestCase(new char[] { 'a' }, new char[] { 'a' })]
[TestCase(new char[] { 'a', 'b' }, new char[] { 'b', 'a' })]
[TestCase(new char[] { 'a', 'b', 'c' }, new char[] { 'c', 'b', 'a' })]
[TestCase(new char[] { 'h', 'e', 'l', 'l', 'o' }, new char[] { 'o', 'l', 'l', 'e', 'h' })]
[TestCase(new char[] { 'H', 'a', 'n', 'n', 'a', 'h' }, new char[] { 'h', 'a', 'n', 'n', 'a', 'H' })]
public void ReverseString(char[] s, char[] expectedArr)
{
	new Solution().ReverseString(s);
	Assert.That(s, Is.EqualTo(expectedArr));
}

// https://leetcode.com/explore/item/1183
#region Условие задачи
/*

Write a function that reverses a string. The input string is given as an array of characters char[].

Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

You may assume all the characters consist of printable ascii characters.

 

Example 1:

Input: ["h","e","l","l","o"]
Output: ["o","l","l","e","h"]

Example 2:

Input: ["H","a","n","n","a","h"]
Output: ["h","a","n","n","a","H"]

Hint #1
The entire logic for reversing a string is based on using the opposite directional two-pointer approach!

*/

#endregion

public class Solution
{
	public void ReverseString(char[] s)
	{
		if(s.Length < 2)
			return;
			
		var left = 0;
		var right = s.Length -1;
		while(left <  right)
		{
			var swap = s[left];
			s[left] = s[right];
			s[right] = swap;
			
			left++;
			right--;
		}
	}
}

#region Хорошие алгоритмы-победители

// Мой ответ находится среди плохих (сильно не дотянул даже до вершины нормального распределения)

// Ответы из моей группы - вот не думал, что рекурсия имеет ту же сложность что и мой ответ
public class Solution1
{
	public void ReverseString(char[] s)
	{
		if (s.Length <= 1)
			return;
		Reverse(s, 0, s.Length - 1);
	}

	private void Reverse(char[] s, int start, int end)
	{
		if (start >= end)
			return;

		char temp = s[start];
		s[start] = s[end];
		s[end] = temp;

		Reverse(s, start + 1, end - 1);
	}
}

// Лучше моего. Странно, что моя провенка s.length < 2 так замедляет обход.
public void ReverseString2(char[] s)
{

	int left = 0, right = s.Length - 1;

	while (left < right)
	{
		char temp = s[left];
		s[left] = s[right];
		s[right] = temp;
		left++;
		right--;
	}


}

// Ещё лучше. Добрались до вершины нормального распределения ответов.
public void ReverseString3(char[] s)
{
	var n = s.Length;
	for (var i = 0; i < n / 2; i++)
	{
		var tmp = s[i];
		s[i] = s[n - i - 1];
		s[n - i - 1] = tmp;
	}

}

// Практически такой же по скорости, но мы пошли в зону хороших ответов.
public void ReverseString4(char[] s)
{
	for (int i = 0; i < s.Length / 2; i++)
	{
		char temp = s[i];
		s[i] = s[s.Length - 1 - i];
		s[s.Length - 1 - i] = temp;
	}
}

// Это снова мой ответ без проверок
public void ReverseString5(char[] s)
{
	int start = 0;
	int end = s.Length - 1;
	while (start < end)
	{
		char temp = s[end];
		s[end] = s[start];
		s[start] = temp;
		start++;
		end--;
	}
}

// Ещё лучше
public void ReverseString6(char[] s)
{
	int i = 0;
	int j = s.Length - 1;

	while (i < j)
	{
		char tmp = s[i];
		s[i] = s[j];
		s[j] = tmp;
		i++;
		j--;
	}
}

// И ещё. 
public void ReverseString7(char[] s)
{
	//Input:  ["h","e","l","l","o"]
	//Output: ["o","l","l","e","h"]
	int right = s.Length - 1;
	int left = 0;
	while (left < right)
	{
		char temp = s[left];
		s[left++] = s[right];
		s[right--] = temp;
	}
}

// Ещё.
public void ReverseString8(char[] s)
{
	for (int i = 0; i < s.Length / 2; i++)
	{
		char temp = s[i];
		s[i] = s[s.Length - 1 - i];
		s[s.Length - 1 - i] = temp;
	}
}

// Типа победитель
public void ReverseString9(char[] s)
{
	if (s.Length <= 1) return;
	int start = 0, end = s.Length - 1;

	while (start < end)
	{
		char temp = s[start];
		s[start] = s[end];
		s[end] = temp;
		end--; start++;
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