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
[TestCase("A", 1)]
[TestCase("B", 2)]
[TestCase("C", 3)]
[TestCase("Z", 26)]
[TestCase("AA", 27)]
[TestCase("AB", 28)]
[TestCase("ZY", 701)]
[TestCase("AAA", 703)]
public void FindDiagonalOrder(string s, int expected)
{
	var actual = new Solution().TitleToNumber(s);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/problems/excel-sheet-column-number/
#region Условие задачи
/*

Given a column title as appear in an Excel sheet, return its corresponding column number.

For example:

    A -> 1
    B -> 2
    C -> 3
    ...
    Z -> 26
    AA -> 27
    AB -> 28 
    ...

Example 1:

Input: "A"
Output: 1

Example 2:

Input: "AB"
Output: 28

Example 3:

Input: "ZY"
Output: 701

 

Constraints:

    1 <= s.length <= 7
    s consists only of uppercase English letters.
    s is between "A" and "FXSHRXW".

*/

#endregion

public class Solution
{
	public int TitleToNumber(string s)
	{
		var sum = 0;
		var pointer = s.Length;
		while (--pointer >= 0)
		{
			var current = (byte)s[pointer] - 64;
			var position = (int)Math.Pow(26, s.Length - pointer - 1);
			//$"pointer={pointer} pow={s.Length - pointer - 1}  current={current}, position={position}, sum={position * current}".Dump();
			sum += position * current;
		}
		return sum;
	}
}

#region Хорошие алгоритмы-победители

// 

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