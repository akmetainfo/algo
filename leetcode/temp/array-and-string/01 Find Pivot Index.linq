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
[TestCase(new int[] { 1, 7, 3, 6, 5, 6 }, 3)]
//[TestCase(new int[] { 1, 2, 3 }, -1)]
[TestCase(new int[] { -1, -1, -1, 0, 1, 1 }, 0)]
public void RemoveElement(int[] nums, int expected)
{
	var actual = new Solution().PivotIndex(nums);
	//nums.Dump();
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/explore/item/1144
#region Условие задачи
/*

Given an array of integers nums, write a method that returns the "pivot" index of this array.

We define the pivot index as the index where the sum of all the numbers to the left of the index is equal to the sum of all the numbers to the right of the index.

If no such index exists, we should return -1. If there are multiple pivot indexes, you should return the left-most pivot index.

 

Example 1:

Input: nums = [1,7,3,6,5,6]
Output: 3
Explanation:
The sum of the numbers to the left of index 3 (nums[3] = 6) is equal to the sum of numbers to the right of index 3.
Also, 3 is the first index where this occurs.

Example 2:

Input: nums = [1,2,3]
Output: -1
Explanation:
There is no index that satisfies the conditions in the problem statement.

 

Constraints:

    The length of nums will be in the range [0, 10000].
    Each element nums[i] will be an integer in the range [-1000, 1000].

Hint #1

We can precompute prefix sums P[i] = nums[0] + nums[1] + ... + nums[i-1]. Then for each index, the left sum is P[i], and the right sum is P[P.length - 1] - P[i] - nums[i].

*/

#endregion

public class Solution
{
	// Я понял о чём это условие было: о том, что SumLeft + num[i] + SumRight всегда дадут Total (надо просто нарисовать отрезок и поделить его на три части: left, num[i], right.
	public int PivotIndex(int[] nums)
	{
		if(nums.Length < 3)
			return -1;
			
		var leftSum = 0;

		for (var i = 0; i < nums.Length; i++)
		{
			if(i > 0)
				leftSum = leftSum + nums[i - 1];
			
			var rightSum = 0;
			for(var j = i + 1; j < nums.Length; j++)
			{
				rightSum = rightSum + nums[j];
			}
			if(leftSum == rightSum)
				return i;

			//Console.WriteLine($"i={i} nums[i]={nums[i]} -> leftSum={leftSum} rightSum={rightSum}");
		}
		
		return -1;
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще где-то в жопе мира по скорости

// Очень плохой вариант, но с него по факту начинается нормальное распределение
// Кроме того, он правильно учитывает подсказку: считает сразу всю сумму, а потом сравнивает левую и правую часть
public int PivotIndex1(int[] nums)
{
	int total = nums.Sum();
	int acc = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if (acc == (total - (acc + nums[i])))
			return i;

		acc += nums[i];
	}

	return -1;
}

// Получше. Сумма считается не стандартной функцией, но ведь и не от всех элементов, выкидывается первый
public int PivotIndex2(int[] nums)
{
	if (nums.Length == 0)
	{
		return -1;
	}

	var pivot = 0;
	var sumLeft = 0;
	var sumRight = 0;

	for (int i = pivot + 1; i < nums.Length; i++)
	{
		sumRight += nums[i];
	}

	while (pivot < nums.Length - 1)
	{
		if (sumLeft == sumRight)
		{
			return pivot;
		}

		sumLeft += nums[pivot];
		sumRight -= nums[pivot + 1];
		pivot++;
	}

	if (sumLeft == sumRight)
	{
		return pivot;
	}

	return -1;
}

// Ещё лучше. Мы дошли до вершины нормального распределения ответов, чуть справа.
public int PivotIndex3(int[] nums)
{
	int sum = 0;
	foreach (int n in nums)
	{
		sum += n;
	}
	int left_sum = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if (left_sum == sum - left_sum - nums[i]) return i;
		left_sum += nums[i];
	}
	return -1;
}

// Ещё лучше. Мы дошли до вершины, но уже чуть левее.
public int PivotIndex4(int[] nums)
{
	int sum = 0, leftsum = 0;
	foreach (int x in nums) sum += x;
	for (int i = 0; i < nums.Length; ++i)
	{
		if (leftsum == sum - leftsum - nums[i]) return i;
		leftsum += nums[i];
	}
	return -1;
}

// Пошли победители
public int PivotIndex5(int[] nums)
{
	int total = 0;

	foreach (var num in nums)
	{
		total += num;
	}

	int leftTotal = 0;
	for (int index = 0; index < nums.Length; index++)
	{
		int pivotValue = nums[index];

		if (leftTotal == total - leftTotal - pivotValue)
		{
			return index;
		}

		leftTotal += nums[index];
	}

	return -1;
}

// Ещё лучше
public int PivotIndex6(int[] nums)
{
	if (nums.Length == 0)
	{
		return -1;
	}
	var sumsLeft = new int[nums.Length];
	sumsLeft[0] = nums[0];
	for (var i = 1; i < sumsLeft.Length; i++)
	{
		sumsLeft[i] = nums[i] + sumsLeft[i - 1];
	}
	var sumsRight = new int[nums.Length];
	sumsRight[sumsRight.Length - 1] = nums[nums.Length - 1];
	for (var i = sumsRight.Length - 2; i >= 0; i--)
	{
		sumsRight[i] = nums[i] + sumsRight[i + 1];
	}
	for (var i = 0; i < nums.Length; i++)
	{
		if (sumsLeft[i] == sumsRight[i])
		{
			return i;
		}
	}
	return -1;
}

// Типа лучший
public int PivotIndex7(int[] nums)
{
	int sum = 0;
	foreach (var num in nums)
		sum += num;
	int leftSum = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if (leftSum == sum - leftSum - nums[i])
			return i;
		leftSum += nums[i];
	}
	return -1;
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