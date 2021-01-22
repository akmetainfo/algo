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
[TestCase(1, true)]
[TestCase(2, false)]
[TestCase(4, true)]
[TestCase(14, false)]
[TestCase(16, true)]
public void ValidPerfectSquare(int nums, bool expected)
{
	var actual = new Solution().IsPerfectSquare(nums);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/problems/valid-perfect-square/
#region Условие задачи
/*

Given a positive integer num, write a function which returns True if num is a perfect square else False.

Follow up: Do not use any built-in library function such as sqrt.

Example 1:

Input: num = 16
Output: true

Example 2:

Input: num = 14
Output: false

Constraints:

    1 <= num <= 2^31 - 1

*/

#endregion

public class Solution
{
	public bool IsPerfectSquare(int num)
	{
		if(num == 1)
			return true;

		var left = 1;
		var right = num;
		
		while(left <= right)
		{
			var mid = left + (right - left) / 2;
			
			ulong sq = (ulong)mid * (ulong)mid;
			
			if(sq == (ulong)num)
				return true;
				
			if(sq < (ulong)num)
			{
				left = mid + 1;
			}
			else
			{
				right = mid - 1;
			}
		}
		
		return false;
	}
}

#region Solution

/*

*/

#endregion

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