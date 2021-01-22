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
[TestCase(4, 2)]
[TestCase(8, 2)]
[TestCase(2147302921, 46339)]
[TestCase(2147395599, 46339)]
[TestCase(2147483647, 46340)]
[TestCase(9, 3)]
[TestCase(100, 10)]
public void FindDiagonalOrder(int x, int expected)
{
	var actual = new Solution().MySqrt(x);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/explore/learn/card/binary-search/125/template-i/950/
#region Условие задачи
/*

Given a non-negative integer x, compute and return the square root of x.

Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.

 

Example 1:

Input: x = 4
Output: 2

Example 2:

Input: x = 8
Output: 2
Explanation: The square root of 8 is 2.82842..., and since the decimal part is truncated, 2 is returned.

 

Constraints:

    0 <= x <= 231 - 1

   Hide Hint #1  
Try exploring all integers. (Credits: @annujoshi)
   Hide Hint #2  
Use the sorted property of integers to reduced the search space. (Credits: @annujoshi)

*/

#endregion

public class Solution
{
	public int MySqrt(int x)
	{
		if (x == 0 || x == 1)
			return x;

		int left = 0;
		int right = x / 2;
		int mid = 0;

		while (left <= right)
		{
			mid = left + (right - left) / 2;
			ulong squareMid = (ulong)mid * (ulong)mid;
			if (squareMid == (ulong)x)
			{
				return mid;
			}
			else if ((ulong)x > squareMid)
			{
				left = mid + 1;
			}
			else
			{
				right = mid - 1;
			}
		}

		return (mid * mid) > x ? mid - 1 : mid;
	}

	// newton's method
	public int MySqrtNewton(int x)
	{
		if (x == 0) return 0;
		double approx = 0.5 * x;
		double betterapprox = 0.0;
		while (true)
		{
			betterapprox = 0.5 * (approx + x / approx);
			if (approx - betterapprox < 0.001)
			{
				break;
			}
			approx = betterapprox;
		}
		return (int)betterapprox;
	}
}

#region Хорошие алгоритмы-победители

// Каноничное решение:

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