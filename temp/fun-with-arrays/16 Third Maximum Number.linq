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
//[TestCase(new int[] { 42 }, 42)]
//[TestCase(new int[] { 1, 2 }, 2)]
//[TestCase(new int[] { 2, 1 }, 2)]
//[TestCase(new int[] { 3, 2, 1 }, 1)]
//[TestCase(new int[] { 5, 2, 2 }, 5)]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 4)]
public void RemoveElement(int[] nums, int expected)
{
	var actual = new Solution().ThirdMax(nums);
	//nums.Dump();
	Assert.That(expected, Is.EqualTo(actual));
}

// https://leetcode.com/explore/item/3231
#region Условие задачи
/*
Given a non-empty array of integers, return the third maximum number in this array. If it does not exist, return the maximum number. The time complexity must be in O(n).

Example 1:

Input: [3, 2, 1]

Output: 1

Explanation: The third maximum is 1.

Example 2:

Input: [1, 2]

Output: 2

Explanation: The third maximum does not exist, so the maximum (2) is returned instead.

Example 3:

Input: [2, 2, 3, 1]

Output: 1

Explanation: Note that the third maximum here means the third maximum distinct number.
Both numbers with value 2 are both considered as second maximum.

*/

#endregion

public class Solution
{
    public int ThirdMax(int[] nums)
	{
		if (nums.Length == 1)
			return nums[0];
		
		if (nums.Length == 2)
			return Math.Max(nums[0], nums[1]);

		int a3 = 0;
		int a2 = 0;
		int a1 = nums[0];
		int lenght = 1;
		
		for(var index = 1; index < nums.Length; index++)
		{
			// a1 is filled
			
			if(lenght == 1)
			{
				if(nums[index] > a1)
				{
					a2 = nums[index];
					lenght = 2;
				}
				else if (nums[index] < a1)
				{
					a2 = a1;
					a1 = nums[index];
					lenght = 2;
				}
				continue;
			}

			// a1 and a2 are filled

			if (lenght == 2)
			{
				if (nums[index] > a2)
				{
					a3 = nums[index];
					lenght = 3;
				}
				else if (nums[index] > a1 && nums[index] < a2)
				{
					a3 = a2;
					a2 = nums[index];
					lenght = 3;
				}
				else if (nums[index] < a1)
				{
					a3 = a2;
					a2 = a1;
					a1 = nums[index];
					lenght = 3;
				}
				continue;
			}
			
			// a1, a2, a3 are filled

			if(nums[index] > a3)
			{
				a1 = a2;
				a2 = a3;
				a3 = nums[index];
			}
			else if (nums[index] < a3 && nums[index] > a2)
			{
				a1 = a2;
				a2 = nums[index];
			}
			else if (nums[index] < a2 && nums[index] > a1)
			{
				a1 = nums[index];
			}
		}

		$"summary: a3={a3}, a2={a2}, a1={a1}".Dump();
		
		if(lenght == 1)
			return a1;
			
		if(lenght == 3)
			return a1;
			
		if(lenght == 2)
			return a2;

		return a1;
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще ровно на пике нормального колокола

// Вот ещё решение из моей группы, красивее записано:
public int ThirdMax1(int[] nums)
{
	//if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
	//else if (nums.Length == 1) return nums[0];
	int? first = nums[0], second = null, third = null;
	for (int i = 1; i < nums.Length; i++)
	{
		if (nums[i] == first || nums[i] == second || nums[i] == third) continue;
		if (first <= nums[i])
		{
			third = second;
			second = first;
			first = nums[i];
		}
		else if (second <= nums[i] || second == null)
		{
			third = second;
			second = nums[i];
		}
		else if (third <= nums[i] || third == null) third = nums[i];
	}
	return third.HasValue ? third.Value : first.Value;
}

public int ThirdMax2(int[] nums)
{
	if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
	else if (nums.Length == 1) return nums[0];
	int? first = nums[0], second = null, third = null;

	for (int i = 1; i < nums.Length; i++)
	{
		if (nums[i] == first || nums[i] == second || nums[i] == third) continue;
		if (first <= nums[i])
		{
			third = second;
			second = first;
			first = nums[i];
		}
		else if (second <= nums[i] || second == null)
		{
			third = second;
			second = nums[i];
		}
		else if (third <= nums[i] || third == null) third = nums[i];
	}
	return third.HasValue ? third.Value : first.Value;
}

public int ThirdMax3(int[] nums)
{

	// handle input less than 3
	if (nums.Length == 1)
	{
		return nums[0];
	}

	// handle input less than 3
	if (nums.Length == 2)
	{
		return Math.Max(nums[0], nums[1]);
	}

	int thirdMax = Int32.MinValue,
		secndMax = Int32.MinValue,
		firstMax = Int32.MinValue;
	bool minExists = false;


	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] == Int32.MinValue)
		{
			minExists = true;
		}

		if (nums[i] == firstMax
		   || nums[i] == secndMax
		   || nums[i] == thirdMax)
		{
			continue;
		}

		if (nums[i] > firstMax)
		{
			thirdMax = secndMax;
			secndMax = firstMax;
			firstMax = nums[i];
		}
		else if (nums[i] > secndMax)
		{
			thirdMax = secndMax;
			secndMax = nums[i];
		}
		else if (nums[i] > thirdMax)
		{
			thirdMax = nums[i];
		}
	}

	return (thirdMax != secndMax
			&& (minExists
				|| thirdMax > Int32.MinValue
			   )
			)
			?
			thirdMax
			:
			firstMax;
}

public int ThirdMax4(int[] nums)
{
	Int64 firstMax = Int64.MinValue;
	Int64 secondMax = Int64.MinValue;
	Int64 thirdMax = Int64.MinValue;
	foreach (var num in nums)
	{
		if (num > firstMax)
		{
			thirdMax = secondMax;
			secondMax = firstMax;
			firstMax = num;
		}
		else if (num > secondMax && num < firstMax)
		{
			thirdMax = secondMax;
			secondMax = num;
		}
		else if (num > thirdMax && num < secondMax)
		{
			thirdMax = num;
		}
	}

	return (int)(secondMax == Int64.MinValue || thirdMax == Int64.MinValue ? firstMax : thirdMax);
}

// Типа победитель
public int ThirdMax5(int[] nums)
{
	int? first = null;
	int? second = null;
	int? third = null;

	foreach (var n in nums)
	{
		if (n == first || n == second || n == third) continue;

		if (first is null || first.Value < n)
		{
			(third, second, first) = (second, first, n);
		}
		else if (second is null || second.Value < n)
		{
			(third, second) = (second, n);
		}
		else if (third is null || third.Value < n)
		{
			third = n;
		}
	}

	return third.HasValue ? third.Value : first.Value;
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