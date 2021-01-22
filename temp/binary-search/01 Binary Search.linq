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
[TestCase(new int[] { -1, 0, 3, 5, 9, 12 }, 9, 4)]
[TestCase(new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1)]
[TestCase(new int[] { 5 }, 5, 0)]
[TestCase(new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1)]
[TestCase(new int[] { -1, 0, 3, 5, 9, 12 }, 0, 1)]
public void FindDiagonalOrder(int[] nums, int target, int expected)
{
	var actual = new Solution().Search(nums, target);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/explore/learn/card/binary-search/138/background/1038/
#region Условие задачи
/*

Given a sorted (in ascending order) integer array nums of n elements and a target value, write a function to search target in nums. If target exists, then return its index, otherwise return -1.


Example 1:

Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4

Example 2:

Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
Explanation: 2 does not exist in nums so return -1

 

Note:

    You may assume that all elements in nums are unique.
    n will be in the range [1, 10000].
    The value of each element in nums will be in the range [-9999, 9999].

*/

#endregion

public class Solution
{
	// Binary search
	public int Search(int[] nums, int target)
	{
		var left = 0;
		var right = nums.Length - 1;
		
		while (left <= right)
		{
			var mid = left + (right - left)/2;
			
			if(nums[mid] == target)
			{
				return mid;
			}
			else if(nums[mid] < target)
			{
				left = mid + 1;
			}
			else
			{
				right = mid - 1;
			}
		}

		return -1;
	}

	// Linear search
	public int Search1(int[] nums, int target)
	{
		for (int i = 0; i < nums.Length; i++)
		{
			if(nums[i] == target)
			{
				return i;
			}
		}

		return -1;
	}
}

#region Хорошие алгоритмы-победители

// Каноничное решение:

public class Solution1
{
	public int Search(int[] nums, int target)
	{
		if (nums == null || nums.Length == 0)
		{
			return -1;
		}

		int start = 0;
		int end = nums.Length - 1;

		while (start <= end)
		{
			int mid = start + (end - start) / 2;

			if (nums[mid] == target)
			{
				return mid;
			}
			else if (nums[mid] > target)
			{
				end = mid - 1;
			}
			else
			{
				start = mid + 1;
			}
		}
		return -1;
	}
}

// Решение более быстрое (за счёте чего?) и написано в рекурсивной форме как будто автор считает классическим именно такой вариант

public class Solution2
{

	public int BinarySearh(int[] nums, int target, int l, int r)
	{
		var m = (l + r) / 2;
		if (nums[m] == target)
			return m;
		if (l > r)
			return -1;
		if (nums[m] < target)
		{
			return BinarySearh(nums, target, m + 1, r);
		}
		else
			return BinarySearh(nums, target, l, m - 1);
	}

	public int Search(int[] nums, int target)
	{
		return BinarySearh(nums, target, 0, nums.Length - 1);
	}
}

// Ещё чуть быстрее, непонятно за счёт чего

public class Solution3
{
	public int Search(int[] nums, int target)
	{
		if (nums == null || nums.Length == 0)
		{
			return -1;
		}

		var start = 0;
		var end = nums.Length - 1;
		while (start + 1 < end)
		{
			var mid = (start + end) / 2;
			if (target == nums[mid]) return mid;

			if (target > nums[mid]) start = mid;
			else end = mid;
		}

		if (nums[start] == target) return start;
		if (nums[end] == target) return end;

		return -1;
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