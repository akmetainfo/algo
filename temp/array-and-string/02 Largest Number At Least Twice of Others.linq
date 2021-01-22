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
[TestCase(new int[] { 3, 6, 1, 0 }, 1)]
[TestCase(new int[] { 1, 2, 3, 4 }, -1)]
[TestCase(new int[] { 0, 0, 0, 1 }, 3)]
[TestCase(new int[] { 1 }, 0)]
public void RemoveElement(int[] nums, int expected)
{
	var actual = new Solution().DominantIndex(nums);
	//nums.Dump();
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/explore/item/1147
#region Условие задачи
/*

In a given integer array nums, there is always exactly one largest element.

Find whether the largest element in the array is at least twice as much as every other number in the array.

If it is, return the index of the largest element, otherwise return -1.

Example 1:

Input: nums = [3, 6, 1, 0]
Output: 1
Explanation: 6 is the largest integer, and for every other number in the array x,
6 is more than twice as big as x.  The index of value 6 is 1, so we return 1.
 

Example 2:

Input: nums = [1, 2, 3, 4]
Output: -1
Explanation: 4 isn't at least as big as twice the value of 3, so we return -1.
 

Note:

	nums will have a length in the range [1, 50].
	Every nums[i] will be an integer in the range [0, 99].


*/

#endregion

public class Solution
{
	public int DominantIndex(int[] nums)
	{
		if(nums.Length == 1)
			return 0;

		var maxMax = 0;
		var preMax = 0;
		var maxMaxIndex = 0;
		//var preMaxIndex = 0;
		
		for(var i = 0; i < nums.Length; i++)
		{
			if(nums[i] > maxMax)
			{
				preMax = maxMax;
				//preMaxIndex = maxMaxIndex;
				maxMax = nums[i];
				maxMaxIndex = i;
			}
			else if(nums[i] > preMax)
			{
				preMax = nums[i];
				//preMaxIndex = i;
			}
			//$"maxMax={maxMax}, index={maxMaxIndex}".Dump();
			//$"preMax={preMax}, index={preMaxIndex}".Dump();
		}
		
		if(maxMax == 0)
			return -1;
			
		if(maxMax >= 2 * preMax)
		{
			return maxMaxIndex;
		}

		return -1;
	}
}

#region Хорошие алгоритмы-победители

// Мой ответ практически среди лучших по скорости

// Ответ из моей группы
public class Solution1
{
	int[] nums;

	public int DominantIndex(int[] nums)
	{
		if (nums.Length == 1) return 0;

		this.nums = nums;

		var max = new int[2] { 0, 1 };
		if (nums[0] < nums[1])
		{
			max[0] = 1;
			max[1] = 0;
		};

		for (int i = 2; i < nums.Length; ++i)
		{
			if (nums[max[0]] < nums[i])
			{
				max[1] = max[0];
				max[0] = i;
			}
			else if (nums[max[1]] < nums[i])
			{
				max[1] = i;
			}
		}

		return nums[max[0]] >= nums[max[1]] * 2 ? max[0] : -1;
	}
}

// Ответ лучше моего и заслуженно:
// ф) max ставится на начало массива а pre - на минус первый. Вот этот заступ на -1 по сравнению с моим "нулевой и первый элемент" изящен
// б) не хранится индекс предыдущего, а я не подумал закомментировать 
public int DominantIndex1(int[] nums)
{
	if (nums.Length == 1)
		return 0;

	var max = 0;
	var prev = -1;
	for (int i = 1; i < nums.Length; i++)
	{
		if (nums[i] >= nums[max])
		{
			prev = max;
			max = i;
		}
		else if (prev == -1 || nums[i] > nums[prev])
		{
			prev = i;
		}
	}

	return nums[max] - nums[prev] >= nums[prev] ? max : -1;
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