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
[TestCase(5, 4)]
[TestCase(5, 5)]
[TestCase(1, 1)]
public void FirstBadVersion(int n, int firstBadVersion)
{
	var solution = new Solution();
	solution.Setup(firstBadVersion);
	var actual = solution.FirstBadVersion(n);
	Assert.That(actual, Is.EqualTo(firstBadVersion));
}

// https://leetcode.com/explore/learn/card/binary-search/126/template-ii/947/
#region Условие задачи
/*

You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.

Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

You are given an API bool isBadVersion(version) which returns whether version is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.


Example 1:

Input: n = 5, bad = 4
Output: 4
Explanation:
call isBadVersion(3) -> false
call isBadVersion(5) -> true
call isBadVersion(4) -> true
Then 4 is the first bad version.

Example 2:

Input: n = 1, bad = 1
Output: 1

Constraints:

    1 <= bad <= n <= 231 - 1

*/

#endregion

public class Solution : VersionControl
{
	public int FirstBadVersion(int n)
	{
		var left = 1;
		var right = n;
		
		while(left < right)
		{
			var mid = left + (right - left) / 2;
			
			if(!IsBadVersion(mid))
			{
				left = mid + 1;
			}
			else
			{
				right = mid;
			}
		}
		
		return left;
	}
}

public class VersionControl
{
	private int _firstBadVersion;
	
	public void Setup(int firstBadVersion)
	{
		this._firstBadVersion = firstBadVersion;
	}
	
	public bool IsBadVersion(int num)
	{
		return num >= this._firstBadVersion;
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