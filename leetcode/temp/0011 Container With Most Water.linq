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
[TestCase(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
[TestCase(new int[] { 1, 1 }, 1)]
[TestCase(new int[] { 4, 3, 2, 1, 4 }, 16)]
[TestCase(new int[] { 1, 2, 1 }, 2)]
public void FindDiagonalOrder(int[] height, int expected)
{
	var actual = new Solution().MaxArea(height);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/problems/container-with-most-water/
#region Условие задачи
/*

Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of the line i is at (i, ai) and (i, 0). Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.

Notice that you may not slant the container.

 

Example 1:

Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.

Example 2:

Input: height = [1,1]
Output: 1

Example 3:

Input: height = [4,3,2,1,4]
Output: 16

Example 4:

Input: height = [1,2,1]
Output: 2

 

Constraints:

    n == height.length
    2 <= n <= 3 * 104
    0 <= height[i] <= 3 * 104

*/

#endregion

public class Solution
{
	public int MaxArea(int[] height)
	{
		if(height.Length == 1)
			return 0;
			
		var max = 0;
		
		for (int i = 0; i < height.Length - 1; i++)
		{
			for (int j = i + 1; j < height.Length; j++)
			{
				var h = height[i] == height[j] ? height[i] : Math.Min(height[i], height[j]);
				
				var m = (j - i) * h;
				
				if(m > max)
				{
					max = m;
				}
			}
		}
		
		return max;
	}
}


#region Solutions

/*
Approach 1: Brute Force

Algorithm

In this case, we will simply consider the area for every possible pair of the lines and find out the maximum area out of those.

Complexity Analysis


	Time complexity : O(n2)O(n ^ 2)O(n2).Calculating area for all n(n−1)2\dfrac{ n(n - 1)}
{ 2}
2n(n−1)​ height pairs.
Space complexity : O(1)O(1)O(1).Constant extra space is used.

Approach 2: Two Pointer Approach

Algorithm

The intuition behind this approach is that the area formed between the lines will always be limited by the height of the shorter line.Further, the farther the lines, the more will be the area obtained.

We take two pointers, one at the beginning and one at the end of the array constituting the length of the lines. Futher, we maintain a variable maxarea\text{ maxarea}
maxarea to store the maximum area obtained till now.At every step, we find out the area formed between them, update maxarea\text{ maxarea}
maxarea and move the pointer pointing to the shorter line towards the other end by one step.

The algorithm can be better understood by looking at the example below:

1 8 6 2 5 4 8 3 7

Current
6 / 8

How this approach works?

Initially we consider the area constituting the exterior most lines.Now, to maximize the area, we need to consider the area between the lines of larger lengths. If we try to move the pointer at the longer line inwards, we won't gain any increase in area, since it is limited by the shorter line. But moving the shorter line's pointer could turn out to be beneficial, as per the same argument, despite the reduction in the width. This is done since a relatively longer line obtained by moving the shorter line's pointer might overcome the reduction in area caused by the width reduction.

For further clarification click here and for the proof click here.

Complexity Analysis


	Time complexity : O(n) O(n) O(n). Single pass.


	Space complexity : O(1)O(1)O(1).Constant space is used.

*/

#endregion

#region Хорошие алгоритмы-победители

//

public class Solution1
{
	public int MaxArea(int[] height)
	{
		var i = 0;
		var j = height.Length - 1;
		var result = 0;

		while (i < j)
		{
			result = Math.Max(result, Math.Min(height[i], height[j]) * (j - i));

			if (height[i] < height[j])
			{
				i++;
			}
			else
			{
				j--;
			}
		}

		return result;
	}
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