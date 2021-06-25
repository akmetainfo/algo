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
[TestCase(new int[] { 10 }, false)]
[TestCase(new int[] { 0, 1 }, false)]
[TestCase(new int[] { 0, 1, 2 }, false)]
[TestCase(new int[] { 3,5,5 }, false)]
[TestCase(new int[] { 0, 3, 2, 1 }, true)]
[TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, false)]
[TestCase(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, false)]
public void CheckIfExist(int[] nums, bool expected)
{
	var result = new Solution().ValidMountainArray(nums);
	Assert.That(result, Is.EqualTo(expected));
}

// https://leetcode.com/explore/item/3251
#region Условие задачи
/*
Given an array of integers arr, return true if and only if it is a valid mountain array.

Recall that arr is a mountain array if and only if:

    arr.length >= 3
    There exists some i with 0 < i < arr.length - 1 such that:
        arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
        arr[i] > arr[i + 1] > ... > arr[arr.length - 1]

 

Example 1:

Input: arr = [2,1]
Output: false

Example 2:

Input: arr = [3,5,5]
Output: false

Example 3:

Input: arr = [0,3,2,1]
Output: true

 

Constraints:

    1 <= arr.length <= 104
    0 <= arr[i] <= 104

Hint #1
It's very easy to keep track of a monotonically increasing or decreasing ordering of elements. You just need to be able to determine the start of the valley in the mountain and from that point onwards, it should be a valley i.e. no mini-hills after that. Use this information in regards to the values in the array and you will be able to come up with a straightforward solution.

*/

#endregion


public class Solution
{
	public bool ValidMountainArray(int[] arr)
	{
		if (arr.Length < 3)
			return false;

		var i = 0;
		
		bool hasIncrease = false;

		//"UP".Dump();
		var current = arr[0];
		while (i < arr.Length - 1)
		{
			//$"i={i} arr[i]={arr[i]} arr[i+1]={arr[i + 1]}".Dump();
			if (arr[i] == arr[i + 1])
				return false;

			if (arr[i] > arr[i + 1])
				break;

			hasIncrease = true;
			i++;
		}

		if (!hasIncrease)
			return false;

		if (i == arr.Length - 1)
			return false; // no down

		//$"DOWN from {i}".Dump();
		while (i < arr.Length - 1)
		{
			//$"i={i} arr[i]={arr[i]} arr[i+1]={arr[i + 1]}".Dump();
			if (arr[i] <= arr[i + 1])
				return false;

			i++;
		}

		if (i == arr.Length - 1)
			return true;

		return false;
	}

	public bool ValidMountainArrayNonMinimized(int[] arr)
	{
		if (arr.Length < 3)
			return false;

		var i = 0;

		"UP".Dump();
		var current = arr[0];
		while (i < arr.Length -1)
		{
			$"i={i} arr[i]={arr[i]} arr[i+1]={arr[i + 1]}".Dump();
			if (arr[i] == arr[i + 1])
				return false;

			if (arr[i] > arr[i + 1])
				break;

			i++;
		}

		if (i == arr.Length -1)
			return false; // no down

		$"DOWN from {i}".Dump();
		while (i < arr.Length - 1)
		{
			$"i={i} arr[i]={arr[i]} arr[i+1]={arr[i + 1]}".Dump();
			if (arr[i] <= arr[i + 1])
				return false;

			i++;
		}

		if (i == arr.Length - 1)
			return true;

		return false;
	}
}

#region Хорошие алгоритмы-победители

// Мой результат один из лучших, приятно

// Результат из моей группы
public bool ValidMountainArray1(int[] arr)
{
	if (arr.Length < 3)
	{
		return false;
	}

	int i = 0;

	while (i < arr.Length - 1 && arr[i] < arr[i + 1])
	{
		i++;
	}

	if (i == 0 || i == arr.Length - 1)
	{
		// not increasing, continue increasing
		return false;
	}

	while (i < arr.Length - 1 && arr[i] > arr[i + 1])
	{
		i++;
	}

	return i == arr.Length - 1;
}

// Winner
public bool ValidMountainArray2(int[] arr)
{
	if (arr.Length < 3) return false;
	if (arr[0] >= arr[1]) return false;
	var goingUp = true;
	for (var i = 2; i < arr.Length; i++)
	{
		if (arr[i - 1] == arr[i]) return false;

		if (goingUp)
		{
			if (arr[i - 1] > arr[i]) goingUp = false;
		}
		else
		{
			if (arr[i - 1] < arr[i]) return false;
		}
	}

	return !goingUp;
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