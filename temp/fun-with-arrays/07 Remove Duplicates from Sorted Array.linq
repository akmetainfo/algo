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
[TestCase(new int[] { 10 }, new int[] { 10 }, 1)]
[TestCase(new int[] { 1, 2 }, new int[] { 1,2 }, 2)]
[TestCase(new int[] { 1, 1 }, new int[] { 1 }, 1)]
[TestCase(new int[] { 1, 2, 3 }, new int[] { 1,2,3 }, 3)]
[TestCase(new int[] { 1, 1, 1 }, new int[] { 1 }, 1)]
[TestCase(new int[] { 1, 1, 2 }, new int[] { 1, 2 }, 2)]
[TestCase(new int[] { 0,0,1,1,1,2,2,3,3,4 }, new int[] { 0,1,2,3,4 }, 5)]
public void RemoveElement(int[] nums, int[] expectedArr, int expectedResult)
{
	var result = new Solution().RemoveDuplicates(nums);
	//$"actual={result}".Dump();
	//nums.Take(result).Dump();
	Assert.That(expectedResult, Is.EqualTo(result));
	Assert.That(expectedArr, Is.EquivalentTo(nums.Take(expectedResult)));
}

// https://leetcode.com/explore/item/3248
#region Условие задачи
/*
Given a sorted array nums, remove the duplicates in-place such that each element appears only once and returns the new length.

Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

Clarification:

Confused why the returned value is an integer but your answer is an array?

Note that the input array is passed in by reference, which means a modification to the input array will be known to the caller as well.

Internally you can think of this:

// nums is passed in by reference. (i.e., without making a copy)
int len = removeDuplicates(nums);

// any modification to nums in your function would be known by the caller.
// using the length returned by your function, it prints the first len elements.
for (int i = 0; i < len; i++) {
    print(nums[i]);
}

 

Example 1:

Input: nums = [1,1,2]
Output: 2, nums = [1,2]
Explanation: Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively. It doesn't matter what you leave beyond the returned length.

Example 2:

Input: nums = [0,0,1,1,1,2,2,3,3,4]
Output: 5, nums = [0,1,2,3,4]
Explanation: Your function should return length = 5, with the first five elements of nums being modified to 0, 1, 2, 3, and 4 respectively. It doesn't matter what values are set beyond the returned length.

 

Constraints:

    0 <= nums.length <= 3 * 104
    -104 <= nums[i] <= 104
    nums is sorted in ascending order.



Hint1:
In this problem, the key point to focus on is the input array being sorted. As far as duplicate elements are concerned, what is their positioning in the array when the given array is sorted? Look at the image above for the answer. If we know the position of one of the elements, do we also know the positioning of all the duplicate elements? 

Hint2:
We need to modify the array in-place and the size of the final array would potentially be smaller than the size of the input array. So, we ought to use a two-pointer approach here. One, that would keep track of the current element in the original array and another one for just the unique elements.

Hint3:
Essentially, once an element is encountered, you simply need to bypass its duplicates and move on to the next unique element.

*/

#endregion

public class Solution
{
	public int RemoveDuplicates(int[] nums)
	{
		var result = nums.Length;
		
		if(nums.Length == 1)
			return result;
		
		for(var i = 0; i < result -1; i++)
		{
			int dupCount = 0;

			while(i + dupCount < result && nums[i] == nums[i + dupCount])
			{
				dupCount++;
			}

			//$"i={i}, result = {result} dupCount={dupCount}".Dump();
			
			if (dupCount < 2)
			{
				//"Case 1. No dups for this digit".Dump();
				continue;
			}
			
			if(i + dupCount == result)
			{
				//$"series to the end of array - just truncate. Return={result - dupCount}".Dump();
				return result - dupCount + 1;
			}

			//"Case 2. Dups".Dump();
			Shift(nums, i, dupCount);
			
			result = result - dupCount +1;

			//nums.Dump();
		}

		return result;
	}

	private static void Shift(int[] nums, int from, int diff)
	{
		int i = 1;
		while (from + i + diff - 1 < nums.Length)
		{
			nums[from + i] = nums[from + i + diff - 1];
			i++;
		}
	}

	public int RemoveDuplicatesSource(int[] nums)
	{
		var result = nums.Length;

		if (nums.Length == 1)
			return result;

		for (var i = 0; i < result - 1; i++)
		{
			int dupCount = 0;

			while (i + dupCount < result && nums[i] == nums[i + dupCount])
			{
				dupCount++;
			}

			$"i={i}, result = {result} dupCount={dupCount}".Dump();

			if (dupCount < 2)
			{
				//"Case 1. No dups for this digit".Dump();
				continue;
			}

			if (i + dupCount == result)
			{
				//$"series to the end of array - just truncate. Return={result - dupCount}".Dump();
				return result - dupCount + 1;
			}

			"Case 2. Dups".Dump();
			Shift(nums, i, dupCount);

			result = result - dupCount + 1;

			//nums.Dump();
		}

		return result;
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще где-то в жопе мира по скорости да и памяти

// Это нормаль, чуть хуже
public int RemoveDuplicates1(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return 0;
	}

	int i = 0, j = 0;
	while (i < nums.Length)
	{
		int cur = nums[i];
		while (i + 1 < nums.Length && nums[i + 1] == cur)
		{
			i++;
		}

		nums[j++] = nums[i++];
	}

	return j;
}

// Тоже у пика нормального распределения, но лучше предыдущего
public int RemoveDuplicates2(int[] nums)
{
	var len = nums.Length;
	int finalLen = len;
	int i = 0;
	int j = 0;
	int? val = null;
	while (i < len)
	{
		if (val == null)
		{
			val = nums[i];
			j += 1;
		}
		else if (nums[i] == val)
		{
			finalLen -= 1;
		}
		else
		{
			val = nums[i];
			nums[j] = nums[i];
			j += 1;
		}
		i += 1;
	}

	return finalLen;
}

// Ещё лучше
public int RemoveDuplicates3(int[] nums)
{
	if (nums.Length == 0) return 0;
	int index = 0;

	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] != nums[index])
		{
			nums[++index] = nums[i];
		}
	}
	return ++index;
}

// И ещё
public int RemoveDuplicates4(int[] nums)
{
	if (nums.Length == 0)
	{
		return 0;
	}
	int j = 0;
	for (int i = 1; i < nums.Length; i++)
	{
		if (nums[i] != nums[j])
		{
			j++;
			nums[j] = nums[i];
		}
	}
	return j + 1;
}

// Почти лучший
public int RemoveDuplicates5(int[] nums)
{
	var retval = 0;
	if (nums == null || nums.Length == 0) return retval;

	for (int m = 1; m < nums.Length; m++)
	{
		if (nums[m] == nums[m - 1])
		{
			continue;
		}
		else
		{
			retval++;
			nums[retval] = nums[m];
		}
	}

	return retval + 1;
}

// Типа победитель
public int RemoveDuplicates(int[] nums)
{
	if (nums.Length == 0) return 0;
	int l = 1;
	for (int i = 0; i < nums.Length - 1; i++)
	{
		if (nums[i] == nums[i + 1])
		{
			continue;

		}
		else
		{
			nums[l] = nums[i + 1];
			l++;
		}

	}
	return l;
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