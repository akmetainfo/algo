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
[TestCase(new int[] { 2, 2 }, 3, new int[] { -1, -1 })]
[TestCase(new int[] { 5, 7, 7, 8, 8, 10 }, 8, new int[] { 3, 4 })]
[TestCase(new int[] { 5, 7, 7, 8, 8, 10 }, 6, new int[] { -1, -1 })]
[TestCase(new int[] { }, 0, new int[] { -1, -1 })]
public void FindDiagonalOrder(int[] nums, int target, int[] expected)
{
	var actual = new Solution().SearchRange(nums, target);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
#region Условие задачи
/*

Given an array of integers nums sorted in ascending order, find the starting and ending position of a given target value.

If target is not found in the array, return [-1, -1].

Follow up: Could you write an algorithm with O(log n) runtime complexity?

Example 1:

Input: nums = [5,7,7,8,8,10], target = 8
Output: [3,4]

Example 2:

Input: nums = [5,7,7,8,8,10], target = 6
Output: [-1,-1]

Example 3:

Input: nums = [], target = 0
Output: [-1,-1]

 

Constraints:

    0 <= nums.length <= 105
    -109 <= nums[i] <= 109
    nums is a non-decreasing array.
    -109 <= target <= 109

*/

#endregion

public class Solution
{
	// Это несколько кривоватое, но надёжное решение за O(N) - а для O(logN) нужно бинарный поиск подтягивать
	public int[] SearchRange(int[] nums, int target)
	{
		if(nums.Length == 0)
			return new int[] { -1, -1 };
			
		var i = 0;
		while(i < nums.Length)
		{
			if(nums[i] >= target)
				break;
			
			i++;
		}

		if (i == nums.Length || nums[i] != target)
			return new int[] { -1, -1 };

		var min = i;
		var max = i;
		
		i++;

		while (i < nums.Length)
		{
			if (nums[i] > target)
				break;

			i++;
		}
		
		max = i;

		return new int[] { min, max -1 };
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