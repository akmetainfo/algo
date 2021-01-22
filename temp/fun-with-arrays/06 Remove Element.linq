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
[TestCase(new int[] { 3, 2, 2, 3 }, 3, new int[] { 2, 2 }, 2)]
[TestCase(new int[] { 0,1,2,2,3,0,4,2 }, 2, new int[] { 0,1,4,0,3 }, 5)]
public void RemoveElement(int[] nums, int val, int[] expectedArr, int expectedResult)
{
	var result = new Solution().RemoveElement(nums, val);
	//nums.Dump();
	//$"actual={result}".Dump();
	Assert.That(expectedResult, Is.EqualTo(result));
	Assert.That(expectedArr, Is.EquivalentTo(nums.Take(expectedResult)));
}

// https://leetcode.com/explore/item/3247
#region Условие задачи
/*

Given an array nums and a value val, remove all instances of that value in-place and return the new length.

Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

The order of elements can be changed. It doesn't matter what you leave beyond the new length.

Clarification:

Confused why the returned value is an integer but your answer is an array?

Note that the input array is passed in by reference, which means a modification to the input array will be known to the caller as well.

Internally you can think of this:

// nums is passed in by reference. (i.e., without making a copy)
int len = removeElement(nums, val);

// any modification to nums in your function would be known by the caller.
// using the length returned by your function, it prints the first len elements.
for (int i = 0; i < len; i++) {
    print(nums[i]);
}

 

Example 1:

Input: nums = [3,2,2,3], val = 3
Output: 2, nums = [2,2]
Explanation: Your function should return length = 2, with the first two elements of nums being 2.
It doesn't matter what you leave beyond the returned length. For example if you return 2 with nums = [2,2,3,3] or nums = [2,2,0,0], your answer will be accepted.

Example 2:

Input: nums = [0,1,2,2,3,0,4,2], val = 2
Output: 5, nums = [0,1,4,0,3]
Explanation: Your function should return length = 5, with the first five elements of nums containing 0, 1, 3, 0, and 4. Note that the order of those five elements can be arbitrary. It doesn't matter what values are set beyond the returned length.

 

Constraints:

    0 <= nums.length <= 100
    0 <= nums[i] <= 50
    0 <= val <= 100

Hint1:
The problem statement clearly asks us to modify the array in-place and it also says that the element beyond the new length of the array can be anything. Given an element, we need to remove all the occurrences of it from the array. We don't technically need to remove that element per-say, right?

Hint2:
We can move all the occurrences of this element to the end of the array. Use two pointers! 

Hint3:
Yet another direction of thought is to consider the elements to be removed as non-existent. In a single pass, if we keep copying the visible elements in-place, that should also solve this problem for us.


*/

#endregion

public class Solution
{
	public int RemoveElement(int[] nums, int val)
	{
		var result = nums.Length - 1;

		for(var i = result; i >= 0; i--)
		{
			if(nums[i] == val)
			{
				if(i != result)
				{
					nums[i] = nums[result];
				}
				
				result--;
			}
		}
		
		return result + 1;
	}

	public int RemoveElementWithoutOptimizations(int[] nums, int val)
	{
		var result = nums.Length - 1;

		for (var i = result; i >= 0; i--)
		{
			$"Point[00]. i={i} nums[i]={nums[i]} result={result} nums[result]={nums[result]}".Dump();
			if (nums[i] == val)
			{
				if (i == result)
				{
					"Point[01]. Last element - just removing by decreasing result".Dump();
					nums[i] = 0;
				}
				else
				{
					"Point[02]. it's in middle = swap it to the end".Dump();
					nums[i] = nums[result];
					nums[result] = 0;
				}
				result--;
			}
			else
			{
				"Point[03]. Skipping".Dump();
			}
			//nums.Dump();
		}
		return result + 1;
	}
}

#region Хорошие алгоритмы-победители

// Пример быстрее моего оптимизированного
public int RemoveElement1(int[] nums, int val)
{
	int l = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] != val)
		{
			nums[l] = nums[i];
			l++;
		}
	}
	return l;
}

// Гм. Это победитель. Видимо потому что быстрее за счёт массива из одного элемента?
public int RemoveElement2(int[] nums, int val)
{
	int j = nums.Length - 1;
	int i = 0;

	if (nums.Length == 1)
	{
		if (nums[0] == val)
			return i;
		else
			return 1;
	}

	for (; i <= j; i++)
	{
		if (nums[i] == val)
		{
			while (j > i && nums[j] == val)
				j--;

			if (i == j)
			{
				break;
			}

			nums[i] += nums[j];
			nums[j] = nums[i] - nums[j];
			nums[i] -= nums[j];
			j--;
		}
	}

	return i;
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