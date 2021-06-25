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
[TestCase(new int[] { 0,0 }, true)]
[TestCase(new int[] { 2, 5, 4 }, true)]
[TestCase(new int[] { -2,0,10,-19,4,6,-8 }, false)]
public void CheckIfExist(int[] nums, bool expected)
{
	var result = new Solution().CheckIfExist(nums);
	//$"actual={result}".Dump();
	//nums.Take(result).Dump();
	Assert.That(result, Is.EqualTo(expected));
}

// https://leetcode.com/explore/item/3250
#region Условие задачи
/*

Given an array arr of integers, check if there exists two integers N and M such that N is the double of M ( i.e. N = 2 * M).

More formally check if there exists two indices i and j such that :

    i != j
    0 <= i, j < arr.length
    arr[i] == 2 * arr[j]

 

Example 1:

Input: arr = [10,2,5,3]
Output: true
Explanation: N = 10 is the double of M = 5,that is, 10 = 2 * 5.

Example 2:

Input: arr = [7,1,14,11]
Output: true
Explanation: N = 14 is the double of M = 7,that is, 14 = 2 * 7.

Example 3:

Input: arr = [3,1,7,11]
Output: false
Explanation: In this case does not exist N and M, such that N = 2 * M.

 

Constraints:

    2 <= arr.length <= 500
    -10^3 <= arr[i] <= 10^3





Hint1:
Loop from i = 0 to arr.length, maintaining in a hashTable the array elements from [0, i - 1].

Hint2:
On each step of the loop check if we have seen the element 2 * arr[i] so far or arr[i] / 2 was seen if arr[i] % 2 == 0.

*/

#endregion

// see also https://habr.com/ru/post/421071/

public class Solution
{
	public bool CheckIfExist(int[] arr)
	{
		var hs = new HashSet<int>();
		
		var hasZero = false;
		
		for(var i = 0; i < arr.Length; i++)
		{
			if(arr[i] == 0)
			{
				if(hasZero)
					return true;
					
				hasZero = true;
				
				continue;
			}
			
			if(!hs.Contains(arr[i]))
			{
				hs.Add(arr[i]);
			}
			
			if(arr[i]!= 0 && hs.Contains(2*arr[i]))
				return true;

			if (arr[i] % 2 == 0 && hs.Contains((arr[i] / 2)))
				return true;
		}

		return false;
	}
}

#region Хорошие алгоритмы-победители

// Ну мой результат посередине - и это ладно, но почему я в группе с N квадрат????

// Лучше моего результата
public bool CheckIfExist1(int[] arr)
{
	Dictionary<int, int> dict = new Dictionary<int, int>();
	for (int i = 0; i < arr.Length; i++)
	{
		int val = arr[i];
		if (dict.ContainsKey(val * 2) || (dict.ContainsKey(val / 2) && val % 2 == 0))
			return true;
		dict[val] = 1;
	}
	return false;
}

// Ещё лучше
public bool CheckIfExist2(int[] arr)
{

	HashSet<double> num = new HashSet<double>();
	Array.Sort(arr);

	foreach (int n in arr)
	{
		if (n >= 0 && num.Contains((double)(n / 2.0))) return true;
		if (n < 0 && num.Contains((double)(n * 2.0))) return true;

		num.Add(n);
	}

	return false;

}

// Winner
// Смешно: он сразу запихнул arr в HashSet
public bool CheckIfExist3(int[] arr)
{
	HashSet<int> hs = new HashSet<int>(arr);
	int zeroCount = 0;
	for (int i = 0; i < arr.Length; i++)
	{
		if (arr[i] == 0)
		{
			if ((++zeroCount) > 1)
				return true;
			continue;
		}

		if (hs.Contains(2 * arr[i]))
			return true;
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