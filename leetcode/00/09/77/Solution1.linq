<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 977. Squares of a Sorted Array
// https://leetcode.com/problems/squares-of-a-sorted-array/

/*
    Time: O(n * log n), so one-time pass with two-pointer is better.
    Space: O(1)
*/
public class Solution
{
    // In-place technique
    public int[] SortedSquares2(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            nums[i] = nums[i] * nums[i];
        }

        Array.Sort(nums);
        return nums;
    }
}

/*
    Time: O(n * log n), so one-time pass with two-pointer is better.
    Space: O(n) due to the output array
*/
public class Solution1
{
    // creating a new array
    public int[] SortedSquares(int[] nums)
    {
        var result = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = nums[i] * nums[i];
        }

        Array.Sort(result);
        return result;
    }
}

[Test]
[TestCase(new int[] { -4, -1, 0, 3, 10 }, new int[] { 0, 1, 9, 16, 100 })]
[TestCase(new int[] { -7, -3, 2, 3, 11 }, new int[] { 4, 9, 9, 49, 121 })]
[TestCase(new int[] { -5, -3, -2, -1 }, new int[] { 1, 4, 9, 25 })]
public void SolutionTests(int[] nums, int[] expected)
{
    var actual = new Solution().SortedSquares(nums);
    Assert.That(actual, Is.EqualTo(expected));
}

#region unit tests runner

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