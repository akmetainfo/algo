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
[TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
[TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
[TestCase(new int[] { 1 }, 0, -1)]
public void SearchInRotatedSortedArray(int[] nums, int target, int expected)
{
	var actual = new Solution().Search(nums, target);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/explore/learn/card/binary-search/125/template-i/952/
#region Условие задачи
/*

You are given an integer array nums sorted in ascending order (with distinct values), and an integer target.

Suppose that nums is rotated at some pivot unknown to you beforehand (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

If target is found in the array return its index, otherwise, return -1.

 

Example 1:

Input: nums = [4,5,6,7,0,1,2], target = 0
Output: 4

Example 2:

Input: nums = [4,5,6,7,0,1,2], target = 3
Output: -1

Example 3:

Input: nums = [1], target = 0
Output: -1

 

Constraints:

    1 <= nums.length <= 5000
    -104 <= nums[i] <= 104
    All values of nums are unique.
    nums is guaranteed to be rotated at some pivot.
    -104 <= target <= 104

*/

#endregion

public class Solution
{
	// https://leetcode.com/problems/search-in-rotated-sorted-array/discuss/588195/C-binary-search-solution
	public int Search(int[] nums, int target)
	{

		if (nums == null || nums.Length == 0)
			return -1;

		int left = 0, right = nums.Length - 1;

		while (left <= right)
		{
			int mid = left + (right - left) / 2;

			if (target == nums[mid])
			{
				return mid;
			}
			else if (nums[mid] >= nums[left])
			{
				if (target >= nums[left] && target < nums[mid])
					right = mid - 1;
				else
					left = mid + 1;
			}
			else
			{
				if (target > nums[mid] && target <= nums[right])
					left = mid + 1;
				else
					right = mid - 1;
			}
		}

		return -1;
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