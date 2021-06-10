<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 03 C# Binary search in sorted array

/*
    Time: O(log n)
    Space: O(1)
*/
// This algoritm is not supported specific position for left/rightmost searches when dups
// There's why no unit tests for duplicates
public class Solution
{
    public int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            
            if(nums[mid] == target)
                return mid;
            
            if(nums[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}

/*
    Time: O(log n)
    Space: O(1)
*/
public class Solution2
{
    public int Search(int[] nums, int target)
    {
        if(nums.Length == 0)
            return -1;

        var left = 0;
        var right = nums.Length - 1;
        
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            
            if(nums[mid] == target)
                return mid;
            
            if(nums[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        
        if(nums[left] == target)
            return left;

        return -1;
    }
}

/*
    Time: O(log n)
    Space: O(1)
*/
// This algoritm is an alternative form
// No `if == `, but the while will executed more than at prev algoritm - see wikipedia
// Also it returns the rightmost element ALWAYS, if array contains duplicate
public class Solution1
{
    public int Search(int[] nums, int target)
    {
        if(nums.Length == 0)
            return -1;
            
        var left = 0;
        var right = nums.Length - 1;
        
        while (left != right)
        {
            var mid = (int)Math.Ceiling(left + (right - left) / 2.0d);
            
            if(nums[mid] > target)
                right = mid - 1;
            else
                left = mid;
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
[TestCase(new int[] { 7, 8 }, 6, -1)]
[TestCase(new int[] { 7, 8 }, 7, 0)]
[TestCase(new int[] { 7, 8 }, 8, 1)]
[TestCase(new int[] { 7, 8 }, 9, -1)]
public void SolutionTests(int[] nums, int target, int expected)
{
    var actual = new Solution2().Search(nums, target);
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