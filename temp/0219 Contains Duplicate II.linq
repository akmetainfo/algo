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
[TestCase(new[] { 1, 2, 3, 1 }, 3, true)]
[TestCase(new[] { 1, 0, 1, 1 }, 1, true)]
[TestCase(new[] { 1, 2, 3, 1, 2, 3 }, 2, false)]
public void FindDiagonalOrder(int[] nums, int k, bool expected)
{
	var actual = new Solution().ContainsNearbyDuplicate(nums,k);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/problems/contains-duplicate-ii/
#region Условие задачи
/*

Given an array of integers and an integer k, find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the absolute difference between i and j is at most k.

Example 1:

Input: nums = [1,2,3,1], k = 3
Output: true

Example 2:

Input: nums = [1,0,1,1], k = 1
Output: true

Example 3:

Input: nums = [1,2,3,1,2,3], k = 2
Output: false

*/

#endregion

// Approachs:
// 1. Travers all nums O(N) adding visited to HashSet<(keyvalue)> (pair = (nums[i], i)
// 2. Two-pointer??
// 3. Naiv?
public class Solution
{
	// Naiv approach, time O(N * K)
	public bool ContainsNearbyDuplicate(int[] nums, int k)
	{
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = i + 1; j < nums.Length && j - i <= k; j++)
			{
				if (nums[i] == nums[j])
					return true;
			}
		}
		return false;
	}
}

#region Хорошие алгоритмы-победители

// 

// Consise HashSet approach, но я не понимаю как работает
public bool ContainsNearbyDuplicate(int[] nums, int k)
{
	if (nums == null || nums.Length == 0 || k <= 0)
		return false;

	var length = nums.Length;

	var prefix = new HashSet<int>();

	for (int i = 0; i < length; i++)
	{
		var current = nums[i];

		if (prefix.Contains(current))
		{
			return true;
		}

		prefix.Add(current);

		if (i - k >= 0)
		{
			prefix.Remove(nums[i - k]);
		}
	}

	return false;
}

// Dictionary approach, straightforward
// Я пытался написать с Dictionary и упёрся в то, что элементов может быть несколько и надо все перебирать: но вот достаточно хранить только последнее вхождение!
public bool ContainsNearbyDuplicate1(int[] nums, int k)
{
	var dict = new Dictionary<int, int>();

	for (int i = 0; i < nums.Length; i++)
	{
		// for first occurance
		if (!dict.ContainsKey(nums[i]))
		{
			dict.Add(nums[i], i);
		}
		else
		{
			// already present in dict
			// check for at the most k
			if ((i - dict[nums[i]]) <= k)
				return true;

			// update with new position
			dict[nums[i]] = i;
		}
	}
	return false;
}

// Dictionary approach, pretty version (see straightforward first)
public bool ContainsNearbyDuplicate2(int[] nums, int k)
{
	var dict = new Dictionary<int, int>();

	for (var i = 0; i < nums.Length; i++)
	{
		if (dict.ContainsKey(nums[i]) && i - dict[nums[i]] <= k) return true;

		dict[nums[i]] = i;
	}

	return false;
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