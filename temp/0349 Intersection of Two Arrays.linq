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
[TestCase(new[] { 1, 2, 2, 1 }, new[] { 2, 2 }, new[] { 2 })]
[TestCase(new[] { 4, 9, 5 }, new[] { 9, 4, 9, 8, 4 }, new[] { 9, 4 })]
[TestCase(new[] { 1, 2, 2, 1 }, new[] { 2, 2 }, new[] { 2 })]
public void FindDiagonalOrder(int[] nums1, int[] nums2, int[] expected)
{
	var actual = new Solution().Intersection(nums1, nums2);
	Assert.That(actual, Is.EquivalentTo(expected));
}

// https://leetcode.com/problems/intersection-of-two-arrays/
#region Условие задачи
/*

Given two arrays, write a function to compute their intersection.

Example 1:

Input: nums1 = [1,2,2,1], nums2 = [2,2]
Output: [2]

Example 2:

Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
Output: [9,4]

Note:

    Each element in the result must be unique.
    The result can be in any order.


*/

#endregion

public class Solution
{
	// Неплохо, сам написал сам.
	// Учесть что можно было итерировать только меньший из hs1 и hs2
	public int[] Intersection(int[] nums1, int[] nums2)
	{
		var result = new HashSet<int>();
		
		if(nums1.Length == 0 && nums2.Length == 0)
			return result.ToArray();
		
		var hs1 = new HashSet<int>(nums1);
		var hs2 = new HashSet<int>(nums2);
		
		foreach (var element in hs1)
		{
			if(hs2.Contains(element))
				result.Add(element);
		}

		foreach (var element in hs2)
		{
			if (hs1.Contains(element))
				result.Add(element);
		}

		return result.ToArray();
	}
}

#region Solution

/*

Approach 1: Two Sets

Intuition

The naive approach would be to iterate along the first array nums1 and to check for each value if this value in nums2 or not. If yes - add the value to output. Such an approach would result in a pretty bad O(n×m)\mathcal{O}(n \times m)O(n×m) time complexity, where n and m are arrays' lengths.

    To solve the problem in linear time, let's use the structure set, which provides in/contains operation in O(1)\mathcal{O}(1)O(1) time in average case.

The idea is to convert both arrays into sets, and then iterate over the smallest set checking the presence of each element in the larger set. Time complexity of this approach is O(n+m)\mathcal{O}(n + m)O(n+m) in the average case.
Current
1 / 6

Implementation

Complexity Analysis

    Time complexity : O(n+m)\mathcal{O}(n + m)O(n+m), where n and m are arrays' lengths. O(n)\mathcal{O}(n)O(n) time is used to convert nums1 into set, O(m)\mathcal{O}(m)O(m) time is used to convert nums2, and contains/in operations are O(1)\mathcal{O}(1)O(1) in the average case.

    Space complexity : O(m+n)\mathcal{O}(m + n)O(m+n) in the worst case when all elements in the arrays are different.

Approach 2: Built-in Set Intersection

Intuition

There are built-in intersection facilities, which provide O(n+m)\mathcal{O}(n + m)O(n+m) time complexity in the average case and O(n×m)\mathcal{O}(n \times m)O(n×m) time complexity in the worst case.

    In Python it's intersection operator, in Java - retainAll() function.

Implementation

Complexity Analysis

    Time complexity : O(n+m)\mathcal{O}(n + m)O(n+m) in the average case and O(n×m)\mathcal{O}(n \times m)O(n×m) in the worst case when load factor is high enough.

    Space complexity : O(n+m)\mathcal{O}(n + m)O(n+m) in the worst case when all elements in the arrays are different.


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