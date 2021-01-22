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
[TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 2 })]
[TestCase(new int[] { 2, 3, 4 }, 6, new int[] { 1, 3 })]
[TestCase(new int[] { -1, 0 }, -1, new int[] { 1, 2 })]
[TestCase(new int[] { 2, 25, 75 }, 100, new int[] { 2, 3 })]
public void TwoSum(int[] numbers, int target, int[] expected)
{
	var actual = new Solution().TwoSum(numbers, target);
	Assert.That(actual, Is.EqualTo(expected));
}


// https://leetcode.com/explore/item/1153
#region Условие задачи
/*

Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.

Note:

    Your returned answers (both index1 and index2) are not zero-based.
    You may assume that each input would have exactly one solution and you may not use the same element twice.

 

Example 1:

Input: numbers = [2,7,11,15], target = 9
Output: [1,2]
Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

Example 2:

Input: numbers = [2,3,4], target = 6
Output: [1,3]

Example 3:

Input: numbers = [-1,0], target = -1
Output: [1,2]

 

Constraints:

    2 <= nums.length <= 3 * 104
    -1000 <= nums[i] <= 1000
    nums is sorted in increasing order.
    -1000 <= target <= 1000



*/

#endregion

public class Solution
{
	public int[] TwoSum(int[] numbers, int target)
	{
		var min = 0;
		var max = 0;
		while(min < numbers.Length)
		{
			var needle = target - numbers[min];
			
			max = min + 1;
			while(max  < numbers.Length && numbers[max] != needle && numbers[max] < needle)
			{
				max++;
			}
			
			if(max != numbers.Length && numbers[min] + numbers[max] == target)
				return new int[] { min + 1, max + 1};;
			
			min++;
		}
		
		return null;
	}
}


#region Хорошие алгоритмы-победители

// Мой алгоритм вообще где-то в жопе мира, до подножия нормального распределения километр

// Лучше
public int[] TwoSum1(int[] numbers, int target)
{
	int left = 0, right = numbers.Length - 1;
	while (left < right)
	{
		var sum = numbers[left] + numbers[right];
		if (sum == target)
			return new int[] { left + 1, right + 1 };
		else if (sum > target)
			right--;
		else
			left++;
	}

	return new int[] { left + 1, right + 1 };
}

// Лучше
public int[] TwoSum2(int[] numbers, int target)
{
	int left = 0;
	int right = numbers.Length - 1;
	int[] result = new int[2];
	while (left < right)
	{
		if (numbers[left] + numbers[right] == target)
		{
			result[0] = left + 1;
			result[1] = right + 1;
			return result;
		}
		else if (numbers[left] + numbers[right] < target)
			left++;
		else
			right--;


	}
	return result;
}

// Лучше
public int[] TwoSum3(int[] numbers, int target)
{
	var dic = new Dictionary<int, int>();
	for (int i = 0; i < numbers.Length; i++)
	{
		int diff = target - numbers[i];
		if (dic.TryGetValue(diff, out int ind))
		{
			return new int[] { ind, i + 1 };
		}
		dic.Add(numbers[i], i + 1);
	}
	return null;
}

// Лучше
public int[] TwoSum4(int[] numbers, int target)
{

	int l = 0;
	int r = numbers.Length - 1;

	while (l < r)
	{
		if (numbers[l] + numbers[r] > target)
			r--;
		else if (numbers[l] + numbers[r] < target)
			l++;
		else
			break;
	}

	return new int[] { l + 1, r + 1 };
}

// Лучше
public int[] TwoSum5(int[] numbers, int target) {
    int l = 0, r = numbers.Length - 1;
    var res = new int[2];
    
    while(l < r){
        var sum = numbers[l] + numbers[r];
        if(sum == target){
            res[0] = l + 1;
            res[1] = r + 1;
            break;
        }else if(sum > target){
            r--;
        }else{
            l++;
        }
    }
    
    return res;
}
	
// Ещё лучше
public int[] TwoSum6(int[] numbers, int target)
{
	int start = 0, end = numbers.Length - 1;
	while (start + 1 < end)
	{
		int mid = start + (end - start) / 2;
		if (numbers[start] == (target - numbers[end]))
			return new int[] { start + 1, end + 1 };
		else if (numbers[start] < (target - numbers[end]))
		{
			start = (numbers[mid] < (target - numbers[end])) ? mid : start + 1;
		}
		else
		{
			end = (numbers[mid] > (target - numbers[start])) ? mid : end - 1;
		}
	}
	if (numbers[start] == (target - numbers[end]))
		return new int[] { start + 1, end + 1 };
	return new int[] { -1, -1 };
}

// Победитель
public int[] TwoSum7(int[] numbers, int target)
{
	int left = 0, right = numbers.Length - 1;

	while (left < right)
	{

		int m = left + (right - left) / 2;

		if (numbers[left] + numbers[right] == target)
		{
			return new int[] { left + 1, right + 1 };
		}

		if (numbers[left] + numbers[m] > target)
		{
			right = m;
		}
		if (numbers[left] + numbers[right] < target)
		{
			left += 1;
		}
		if (numbers[left] + numbers[right] > target)
		{
			right--;
		}
	}
	return null;
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