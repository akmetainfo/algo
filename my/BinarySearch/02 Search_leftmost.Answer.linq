<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 03 C# Search leftmost element in sorted array

/*
    Time: O(log n)
    Space: O(1)
*/

public class Solution
{
    public int Search_leftmost(int[] nums, int target)
    {
        if (nums.Length == 0)
            return -1;

        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }
        
        if(nums[left] == target)
            return left;

        return -1;
    }
}

[Test]
[TestCase(new int[] { }, 42, -1)]
[TestCase(new int[] { 7 }, 1, -1)]
[TestCase(new int[] { 7 }, 7, 0)]
[TestCase(new int[] { 7 }, 9, -1)]
[TestCase(new int[] { 5, 7 }, 1, -1)]
[TestCase(new int[] { 5, 7 }, 5, 0)]
[TestCase(new int[] { 5, 7 }, 7, 1)]
[TestCase(new int[] { 5, 7 }, 9, -1)]
[TestCase(new int[] { 1, 2, 3, 3, 4 }, 0, -1)]
[TestCase(new int[] { 1, 2, 3, 3, 4 }, 2, 1)]
[TestCase(new int[] { 1, 2, 3, 3, 4 }, 3, 2)]
[TestCase(new int[] { 1, 2, 3, 3, 4 }, 4, 4)]
[TestCase(new int[] { 1, 2, 3, 3, 4 }, 5, -1)]
[TestCase(new int[] { 2, 5, 7, 9, 11 }, 1, -1)]
[TestCase(new int[] { 2, 5, 7, 9, 11 }, 5, 1)]
[TestCase(new int[] { 2, 5, 7, 9, 11 }, 12, -1)]
[TestCase(new int[] { 7, 11, 42 }, 50, -1)]
public void SolutionTests(int[] nums, int target, int expected)
{
    var actual = new Solution().Search_leftmost(nums, target);
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