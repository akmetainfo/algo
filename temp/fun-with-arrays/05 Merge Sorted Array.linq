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
[TestCase(new int[] { 0,0,0,0,0 }, 0, new int[] { 1,2,3,4,5 }, 5, new int[] { 1,2,3,4,5 })] // A6
[TestCase(new int[] { 0 }, 0, new int[] {1 }, 1, new int[] { 1 })] // A5
[TestCase(new int[] { 1, 101,0 }, 2, new int[] { }, 0, new int[] {1,101,0})] // A0
[TestCase(new int[] { 101,102,103,0 }, 3, new int[] { 1 }, 1, new int[] {1,101,102,103})] // A1
[TestCase(new int[] { 1, 101, 102, 103, 0 }, 4, new int[] { 1 }, 1, new int[] { 1, 1, 101, 102, 103 })] // A2
[TestCase(new int[] { 1,2,3,5,6,0,0 }, 5, new int[] { 4 }, 1, new int[] {1,2,3,4,5,6,0})] // A3
[TestCase(new int[] { 1,2,3,0,0 }, 3, new int[] { 4 }, 1, new int[] {1,2,3,4,0})] // A4
[TestCase(new int[] { 101,102,103,0,0,0 }, 3, new int[] { 2,5,6 }, 3, new int[] {2,5,6,101,102,103})]
[TestCase(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 102, 105, 106 }, 3, new int[] { 1, 2, 3, 102, 105, 106 })]
[TestCase(new int[] { 1,2,3,0,0,0,0 }, 3, new int[] { 2,5,6 }, 3, new int[] {1,2,2,3,5,6,0})]
[TestCase(new int[] { 10, 20, 30, 0, 0, 0, 0 }, 3, new int[] { 11, 22, 33 }, 3, new int[] { 10, 11, 20, 22, 30, 33, 0 })]
public void MargeSortedArray(int[] nums1, int m, int[] nums2, int n, int[] expected)
{
	new Solution().Merge(nums1, m, nums2, n);
	//nums1.Dump();
	Assert.That(expected, Is.EqualTo(nums1));
}

// https://leetcode.com/explore/item/3253
#region Условие задачи
/*

Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.

Note:

    The number of elements initialized in nums1 and nums2 are m and n respectively.
    You may assume that nums1 has enough space (size that is equal to m + n) to hold additional elements from nums2.

Example:

Input:
nums1 = [1,2,3,0,0,0], m = 3
nums2 = [2,5,6],       n = 3

Output: [1,2,2,3,5,6]

Constraints:

    -10^9 <= nums1[i], nums2[i] <= 10^9
    nums1.length == m + n
    nums2.length == n

*/
#endregion
public class Solution
{
	public void Merge(int[] nums1, int m, int[] nums2, int n)
	{
		if(n == 0) // A0
			return;
			
		var nums2curr = 0;
		
		for (var i = 0; i < m + n; i++)
		{
			if(m == 0) // A5
			{
				nums1[i] = nums2[nums2curr];
				nums2curr++;

				continue;
			}
			
			if (nums2curr == n)
				break;
				
			if (nums1[i] >= nums2[nums2curr]) // A1, A2
			{
				Shift(nums1, i);
				nums1[i] = nums2[nums2curr];
				nums2curr++;
				
				continue;
			}
			
			if ( nums1[i+1] >= nums2[nums2curr]) // A3
			{
				Shift(nums1, i + 1);
				nums1[i+1] = nums2[nums2curr];
				nums2curr++;
				continue;
			}

			//nums1.Dump();
			if(i >= (m -1 + nums2curr))
			{
				//$"i={i}, nums2curr={nums2curr} -- m-1={m - 1}   nums1[i]={nums1[i]}  nums2[nums2curr]={nums2[nums2curr]}".Dump();
				//"gotcha".Dump();
				//nums1.Dump();
				nums1[i + 1] = nums2[nums2curr];
				nums2curr++;
			}
		}
	}

	private static void Shift(int[] source, int from)
	{
		for (var j = source.Length - 2; j >= from; j--)
		{
			source[j + 1] = source[j];
		}
	}
}

#region Хорошие алгоритмы-победители

public void MergeBetterThatMine(int[] nums1, int m, int[] nums2, int n)
{
	var mPoint = m - 1;
	var nPoint = n - 1;
	for (int i = m + n - 1; i >= 0; i--)
	{
		if (mPoint == -1)
			nums1[i] = nums2[nPoint--];
		else if (nPoint == -1)
			nums1[i] = nums1[mPoint--];
		else if (nums1[mPoint] > nums2[nPoint])
			nums1[i] = nums1[mPoint--];
		else
			nums1[i] = nums2[nPoint--];
	}
}

public void MergeMedium(int[] nums1, int m, int[] nums2, int n)
{
	var length = m + n;
	var i = m - 1;
	var j = n - 1;
	var last = m + n - 1;
	while (i >= 0 && j >= 0)
	{
		if (nums1[i] > nums2[j])
		{
			nums1[last] = nums1[i];
			last--;
			i--;
		}
		else
		{
			nums1[last] = nums2[j];
			last--;
			j--;
		}
	}

	while (j >= 0)
	{
		nums1[j] = nums2[j];
		j--;
	}
}

public void MergeBest(int[] nums1, int m, int[] nums2, int n)
{
	var i = m - 1;
	var j = n - 1;
	var y = m + n - 1;

	while (i >= 0 && j >= 0)
	{
		if (nums1[i] > nums2[j])
			nums1[y--] = nums1[i--];
		else
			nums1[y--] = nums2[j--];
	}

	while (i >= 0)
		nums1[y--] = nums1[i--];

	while (j >= 0)
		nums1[y--] = nums2[j--];
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