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
[TestCase(new int[] { 17, 18, 5, 4, 6, 1 }, new int[] { 18,6,6,6,1,-1 })]
public void CheckIfExist(int[] nums, int[] expected)
{
	var result = new Solution().ReplaceElements(nums);
	Assert.That(result, Is.EqualTo(expected));
}

// https://leetcode.com/explore/item/3259
#region Условие задачи
/*
Given an array arr, replace every element in that array with the greatest element among the elements to its right, and replace the last element with -1.

After doing so, return the array.
 

Example 1:

Input: arr = [17,18,5,4,6,1]
Output: [18,6,6,6,1,-1]
 

Constraints:

    1 <= arr.length <= 10^4
    1 <= arr[i] <= 10^5

Hint #1
Loop through the array starting from the end.

Hint #2
Keep the maximum value seen so far.

*/

#endregion

public class Solution
{
	public int[] ReplaceElements(int[] arr)
	{
		//$"Start. Arr.Length is {arr.Length}".Dump();
		var max = arr[arr.Length-1];
		arr[arr.Length-1] = -1;
		
		for(var i = arr.Length-2; i >= 0; i--)
		{
			//$"i={i} max = {max} arr[i]={arr[i]}".Dump();

			var current = arr[i];
			
			arr[i] = max;

			if(current > max)
			{
				max = current;
			}
			
		}
		//arr.Dump();
		
		return arr;
	}
}

#region Хорошие алгоритмы-победители

// Ну мой результат примерно пополам между вершиной колокола и лучшим решением

// Решение из моей группы

public int[] ReplaceElements1(int[] arr)
{
	if (arr.Length == 0) return arr;
	for (int i = 0; i < arr.Length;)
	{
		int maxVal = 0;
		int maxIndex = -1;
		for (int j = i + 1; j < arr.Length; j++)
		{
			if (arr[j] > maxVal)
			{
				maxVal = arr[j];
				maxIndex = j;
			}
		}
		if (maxIndex == -1)
		{
			i++;
			continue;
		}

		while (i < maxIndex)
		{
			arr[i] = maxVal;
			i++;

		}
	}
	arr[arr.Length - 1] = -1;
	return arr;
}

// Ещё лучше, есть победитель но в него не ткнуть
public int[] ReplaceElements2(int[] arr)
{

	int max = -1;

	for (int i = arr.Length - 1; i >= 0; i--)
	{
		int tmp = arr[i];
		arr[i] = max;
		max = Math.Max(max, tmp);
	}

	return arr;
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