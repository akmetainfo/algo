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
[TestCase(new int[] { -4,-1,0,3,10 }, new int[] { 0,1,9,16,100 })]
[TestCase(new int[] { -7,-3,2,3,11 }, new int[] {4,9,9,49,121 })]
public void SortedSquares(int[] nums, int[] expected)
{
	var actual = new Solution().SortedSquares(nums);
	//actual.Dump();
	Assert.That(expected, Is.EqualTo(actual));
}

// https://leetcode.com/explore/item/3261

#region Условие задачи
/*

Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.

Example 1:

Input: nums = [-4,-1,0,3,10]
Output: [0,1,9,16,100]
Explanation: After squaring, the array becomes [16,1,0,9,100].
After sorting, it becomes [0,1,9,16,100].

Example 2:

Input: nums = [-7,-3,2,3,11]
Output: [4,9,9,49,121]
 

Constraints:

    1 <= nums.length <= 104
    -104 <= nums[i] <= 104
    nums is sorted in non-decreasing order.



*/
#endregion

public class Solution
{
    public int[] SortedSquares(int[] nums) {
		var sq = new int[nums.Length];
		
		for(var i =0; i < nums.Length; i++)
		{
			sq[i] = nums[i] * nums[i];
		}
		
		Array.Sort(sq);
		return sq;
    }
}

#region Хорошие алгоритмы-победители

// Ну разумеется у меня это пока не решение практически: готовая функция сортировки

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