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
[TestCase(new[] { 3,4,3,2,1 }, 1)]
[TestCase(new[] { 1, 2, 3 }, 2)]
[TestCase(new[] { 1 }, 0)]
[TestCase(new[] { 2, 1 }, 0)]
[TestCase(new[] { 1,2 }, 1)]
[TestCase(new[] { 1, 2, 3, 1 }, 2)]
[TestCase(new[] { 1, 2, 1, 3, 5, 6, 4 }, 5)]
public void FindPeakElement(int[] nums, int peekIndexExpected)
{
	var actual = new Solution().FindPeakElement(nums);
	Assert.That(actual, Is.EqualTo(peekIndexExpected));
}

// https://leetcode.com/explore/learn/card/binary-search/126/template-ii/948/
#region Условие задачи
/*

A peak element is an element that is strictly greater than its neighbors.

Given an integer array nums, find a peak element, and return its index. If the array contains multiple peaks, return the index to any of the peaks.

You may imagine that nums[-1] = nums[n] = -∞.

 

Example 1:

Input: nums = [1,2,3,1]
Output: 2
Explanation: 3 is a peak element and your function should return the index number 2.

Example 2:

Input: nums = [1,2,1,3,5,6,4]
Output: 5
Explanation: Your function can return either index number 1 where the peak element is 2, or index number 5 where the peak element is 6.


Constraints:

    1 <= nums.length <= 1000
    -231 <= nums[i] <= 231 - 1
    nums[i] != nums[i + 1] for all valid i.


*/

#endregion

public class Solution
{
	// Наполовину решил сам, наполовину подсмотрел элементы решения у других и вставил в своё, но так и не понял до конца логику.
	public int FindPeakElement(int[] nums)
	{
		if(nums.Length == 1)
			return 0;
			
		if (nums.Length == 2)
			return nums[0] > nums[1] ? 0 : 1;
			
		var left = 0;
		var right = nums.Length - 1;
		while(left < right)
		{
			var mid = left + (right - left) / 2;
				
			if (mid < right && mid > left && nums[mid] > nums[mid - 1] && nums[mid] > nums[mid + 1])
				return mid;

			if(mid < right && nums[mid] < nums[mid + 1])
			{
				left = mid + 1;
			}
			else
			{
				right = mid - 1;
			}
		}
		
		return left;
	}
}

#region Мои комментарии

/*

https://www.geeksforgeeks.org/find-a-peak-in-a-given-array/


Типовые решения часто содержат такой код:

    if (arr[0] >= arr[1])
        return 0;
    if (arr[n - 1] >= arr[n - 2])
        return n - 1;

Это объясняется просто:

If input array is sorted in strictly increasing order, the last element is always a peak element. For example, 50 is peak element in {10, 20, 30, 40, 50}.
If the input array is sorted in strictly decreasing order, the first element is always a peak element. 100 is the peak element in {100, 80, 60, 50, 20}.

Потому что мы мысленно помним: You may imagine that nums[-1] = nums[n] = -∞.


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