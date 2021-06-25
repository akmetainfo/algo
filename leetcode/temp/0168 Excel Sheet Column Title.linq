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
[TestCase(1, "A")]
[TestCase(2, "B")]
[TestCase(3, "C")]
[TestCase(25, "Y")]
[TestCase(26, "Z")]
//[TestCase(27, "AA")]
//[TestCase(28, "AB")]
//[TestCase(701, "ZY")]
//[TestCase(703, "AAA")]
public void ExcelSheetColumnTitle(int n, string expected)
{
	var actual = new Solution().ConvertToTitle(n);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/problems/excel-sheet-column-title/
#region Условие задачи
/*

Given a positive integer, return its corresponding column title as appear in an Excel sheet.

For example:

    1 -> A
    2 -> B
    3 -> C
    ...
    26 -> Z
    27 -> AA
    28 -> AB 
    ...

Example 1:

Input: 1
Output: "A"

Example 2:

Input: 28
Output: "AB"

Example 3:

Input: 701
Output: "ZY"


*/

#endregion

public class Solution
{
	public string ConvertToTitle(int n)
	{
		var sb = new StringBuilder();
		
		var curr = n;
		
		while(true)
		{
			var rest = curr % 26;
			var symbol = (char)(rest + 64 + (rest == 0 ? 26 : 0));
			sb.Append(symbol);
			$"n = {n}. rest = {rest}, symbol={symbol}, curr = {curr - (rest == 0 ? 26 : 0)}".Dump();
			curr = curr - (rest == 0 ? 26 : 0);

			if (curr < 26)
				break;

			//if(curr == 26 && rest == 0)
			//	break;
		}

		return sb.ToString();
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