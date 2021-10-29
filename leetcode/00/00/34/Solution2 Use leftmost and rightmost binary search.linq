<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 34. Find First and Last Position of Element in Sorted Array
// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/

/*
    Time: O(log n)
    Space: O(1)
*/
public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        if(nums.Length == 0)
            return new[] {-1, -1};
    
        return new int[] { LeftmostBinarySearch(nums, target), RightmostBinarySearch(nums, target) };
    }
    
    private int LeftmostBinarySearch(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length -1;
        
        while(left<right)
        {
            var mid = left + (right - left) / 2;
            
            if(nums[mid]<target)
                left = mid + 1;
            else
                right = mid;
        }
        
        if(nums[left] == target)
            return left;
            
        return -1;
    }
    
    private int RightmostBinarySearch(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        
        while (left < right)
        {
            var mid = 1 + left + (right - left) / 2;
            
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
[TestCase(new int[] { 2, 2 }, 3, new int[] { -1, -1 })]
[TestCase(new int[] { 5, 7, 7, 8, 8, 10 }, 8, new int[] { 3, 4 })]
[TestCase(new int[] { 5, 7, 7, 8, 8, 10 }, 6, new int[] { -1, -1 })]
[TestCase(new int[] { }, 0, new int[] { -1, -1 })]
[TestCase(new int[] { 1 }, 1, new int[] { 0, 0 })]
public void SolutionTests(int[] nums, int target, int[] expected)
{
	var actual = new Solution().SearchRange(nums, target);
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