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
[TestCase(new int[] { 1, 4, 3, 2 }, 4)]
[TestCase(new int[] { 6, 2, 6, 5, 1, 2 }, 9)]
public void AddBinary(int[] nums, int expected)
{
	var actual = new Solution().ArrayPairSum(nums);
	Assert.That(actual, Is.EqualTo(expected));
}


// https://leetcode.com/explore/item/1154
#region Условие задачи
/*

Given an integer array nums of 2n integers, group these integers into n pairs (a1, b1), (a2, b2), ..., (an, bn) such that the sum of min(ai, bi) for all i is maximized. Return the maximized sum.

 

Example 1:

Input: nums = [1,4,3,2]
Output: 4
Explanation: All possible pairings (ignoring the ordering of elements) are:
1. (1, 4), (2, 3) -> min(1, 4) + min(2, 3) = 1 + 2 = 3
2. (1, 3), (2, 4) -> min(1, 3) + min(2, 4) = 1 + 2 = 3
3. (1, 2), (3, 4) -> min(1, 2) + min(3, 4) = 1 + 3 = 4
So the maximum possible sum is 4.

Example 2:

Input: nums = [6,2,6,5,1,2]
Output: 9
Explanation: The optimal pairing is (2, 1), (2, 5), (6, 6). min(2, 1) + min(2, 5) + min(6, 6) = 1 + 2 + 6 = 9.

 

Constraints:

    1 <= n <= 104
    nums.length == 2 * n
    -104 <= nums[i] <= 104

Hint #1
Obviously, brute force won't help here. Think of something else, take some example like 1,2,3,4.

Hint #2
How will you make pairs to get the result? There must be some pattern.

Hint #3
Did you observe that- Minimum element gets add into the result in sacrifice of maximum element.

Hint #4
Still won't able to find pairs? Sort the array and try to find the pattern.

*/

#endregion

public class Solution
{
	public int ArrayPairSum(int[] nums)
	{
		// Задача выглядит так: отсортировать все элементы по возрастанию, затем просуммировать элементы на местах 0, 2, 4, 6... 
		// попробуем, проходит ли такой алгоритм - да, вполне рабочий - теперь можно оптимизировать
		Array.Sort(nums);
		var result = 0;
		for (int i = 0; i < nums.Length; i = i + 2)
		{
			result += nums[i];
		}

		return result;
	}
}


#region Хорошие алгоритмы-победители

// Разумеется, решение не выдерживает никакой критики по скорости
// Но я посмотрел - все решение были такими же (непонятно только почему другие ответы считются лучше - опять видимо погрешности leetcode)

// Решение из моей группы:
public int ArrayPairSum1(int[] nums) {
    Array.Sort(nums);
    int sum=0;
    for(int i=0;i<nums.Length;i=i+2){
        if(i%2==0){
            sum+=nums[i];
        }
    }
    
    return sum;
}

// Типа чуть лучше
public int ArrayPairSum2(int[] nums)
{
	Array.Sort(nums);
	return Enumerable.Range(0, nums.Length / 2).Select(x => nums[2 * x]).Sum();
}

// Ещё лучше
public int ArrayPairSum3(int[] nums)
{
	Array.Sort(nums);
	var sum = 0;
	for (int i = 0; i < nums.Length; i += 2)
	{
		sum += nums[i];
	}

	return sum;
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