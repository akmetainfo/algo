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
[TestCase(101, new int[] { 100 }, 0)]
[TestCase(101, new int[] { 101 }, 1)]
[TestCase(7, new int[] { 2, 3, 1, 2, 4, 3 }, 2)]
[TestCase(11, new int[] { 1, 2, 3, 4, 5 }, 3)]
[TestCase(2, new int[] { 0, 0, 0, 0, 1, 1, 0, 0, }, 2)]
[TestCase(2, new int[] { 0, 0, 0, 0, 1, 0, 1, 0, }, 3)]
[TestCase(2, new int[] { 0, 0, 0, 0, 1, 0, 0, 1, 0, }, 4)]
public void TwoSum(int s, int[] nums, int expected)
{
	var actual = new Solution().MinSubArrayLen(s, nums);
	Assert.That(actual, Is.EqualTo(expected));
}


// https://leetcode.com/explore/item/1299
#region Условие задачи
/*

Given an array of n positive integers and a positive integer s, find the minimal length of a contiguous subarray of which the sum ≥ s. If there isn't one, return 0 instead.

Example: 

Input: s = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: the subarray [4,3] has the minimal length under the problem constraint.

Follow up:
If you have figured out the O(n) solution, try coding another solution of which the time complexity is O(n log n). 


*/

#endregion

public class Solution
{
	public int MinSubArrayLen(int s, int[] nums)
	{
		if(nums.Length == 0)
			return 0;

		// Ответ всегда будет в интервале от 0 до nums.Length
		// Сделаем первый проход всего массива считая сумму и выйдем по достижении любого из условий:
		// а) сумма сравнялась/превысилиа s - очевидно, что в этом случае мы знаем что ответ уже не ноль и его можно улучшить (значит запомним и пойдём улучшать)
		// б) дошли до конца, но всей накопленной не хватило до s. В этом случае стоит вернуть 0 - ничего поделать нельзя.
		
		var trivialSum = 0;
		var i = 0;
		while(i < nums.Length)
		{
			trivialSum += nums[i];
			if (trivialSum >= s)
			{
				break;
			}
			i++;
		}

		// Ловить нечего
		if (i == nums.Length && trivialSum < s)
		{
			return 0;
		}

		// Это идеальный ответ, поэтому стоит ускорить выход
		if (i == 0)
		{
			return i + 1;
		}
		
		// Какой-то ответ есть, но является ли он минимальным? Попробуем его улучшить.

		var length = i + 1;
		var index = 1;

		while (index < nums.Length)
		{
			trivialSum = 0;
			i = index;
			while(i < nums.Length)
			{
				trivialSum += nums[i];
				if (trivialSum >= s || i - index == length)
				{
					break;
				}
				i++;
			}
			
			if(trivialSum >= s && i - index + 1 < length)
			{
				length = i - index + 1;
			}

			index++;
		}
		
		// Окей, улучшить не удалось - просто вернём

		return length;
	}
}


#region Хорошие алгоритмы-победители

// Мой алгоритм настолько плохо, что не поместился в график

// Из начала нормального распределения
public int MinSubArrayLen1(int s, int[] nums)
{

	if (nums == null || nums.Length == 0)
		return 0;

	int start = 0;
	int end = 0;
	int knownLen = 0;

	int sum = 0;

	while (end < nums.Length && start <= end)
	{
		if (sum < s)
		{
			sum += nums[end];

		}

		if (sum >= s)
		{
			knownLen = knownLen == 0 ? (end - start + 1) : Math.Min(knownLen, end - start + 1);

			sum -= nums[start];
			start++;
		}

		if (sum < s)
		{
			end++;
		}
	}

	return knownLen;
}

// Это вершина нормального распределения
public int MinSubArrayLen2(int s, int[] nums)
{
	var windowStart = 0;
	var windowSum = 0;
	var minResult = 9999;
	var result = 0;
	for (var windowEnd = 0; windowEnd < nums.Length; windowEnd++)
	{
		windowSum += nums[windowEnd];
		result++;
		while (windowSum >= s)
		{
			minResult = Math.Min(result, minResult);
			windowSum -= nums[windowStart];
			result--;
			windowStart++;
		}
	}

	return minResult == 9999 ? 0 : minResult;
}

// Лучше
public int MinSubArrayLen3(int s, int[] nums)
{
	int result = int.MaxValue;

	int ptr1 = 0;
	int ptr2 = 0;

	int sum = 0;

	while (ptr2 < nums.Length)
	{
		sum += nums[ptr2];
		while (sum >= s)
		{
			result = Math.Min(result, ptr2 - ptr1 + 1);
			sum -= nums[ptr1++];
		}

		ptr2++;

	}

	return (result == int.MaxValue) ? 0 : result;
}

// Лучше
public int MinSubArrayLen4(int s, int[] nums, bool debug = false)
{

	int start = 0;
	int end = 0;
	int tempSum = 0;
	int minSubArr = int.MaxValue;

	while (end < nums.Length)
	{

		if (debug)
		{
			Console.WriteLine("1 \t start: " + start + "\t end: " + end + "\t tempSum: " + tempSum);
			Console.WriteLine("min: " + minSubArr);
		}
		while (tempSum < s && end < nums.Length)
		{
			tempSum += nums[end];
			end++;
		}
		// tempSum >= 2
		if (tempSum >= s)
		{
			//  minSubArr = Math.Min(minSubArr, end-start);

			//       Console.WriteLine("start: " + start + "\t end: " + end + "\t tempSum: " + tempSum);
			while (tempSum >= s && start < end)
			{
				if (debug)
					Console.WriteLine("2 \t start: " + start + "\t end: " + end + "\t tempSum: " + tempSum);
				minSubArr = Math.Min(minSubArr, end - start);
				if (debug)
					Console.WriteLine("min: " + minSubArr);
				tempSum -= nums[start];
				start++;
			}
			if (debug)
				Console.WriteLine("3 \t start: " + start + "\t end: " + end + "\t tempSum: " + tempSum);
		}
		// end++;
	}

	return minSubArr == int.MaxValue ? 0 : minSubArr;
}

// Лучше
public int MinSubArrayLen5(int s, int[] nums)
{
	var windowStart = 0;
	var windowSum = 0;
	var minResult = int.MaxValue;
	var result = 0;
	for (var windowEnd = 0; windowEnd < nums.Length; windowEnd++)
	{
		windowSum += nums[windowEnd];
		result++;
		while (windowSum >= s)
		{
			minResult = Math.Min(result, minResult);
			windowSum -= nums[windowStart];
			result--;
			windowStart++;
		}
	}

	return minResult == int.MaxValue ? 0 : minResult;
}

// Ещё лучше
public int MinSubArrayLen6(int s, int[] nums)
{

	if (nums.Length == 0)
	{
		return 0;
	}

	int first = 0;
	// int last = 1;
	int len = 1;
	int minLen = 0;
	int sum = nums[first];

	if (sum >= s)
	{
		return len;
	}

	for (int last = 1; last < nums.Length; last++)
	{
		sum += nums[last];

		while (sum >= s)
		{
			len = last + 1 - first;
			if (len < minLen || minLen == 0)
			{
				minLen = len;
			}

			sum -= nums[first];
			first++;
		}
	}

	return minLen;
}

// Победитель
public int MinSubArrayLen7(int s, int[] a)
{
	if (a == null || a.Length == 0)
		return 0;

	int i = 0, j = 0, sum = 0, min = int.MaxValue;

	while (j < a.Length)
	{
		sum += a[j++];

		while (sum >= s)
		{
			min = Math.Min(min, j - i);
			sum -= a[i++];
		}
	}

	return min == int.MaxValue ? 0 : min;
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