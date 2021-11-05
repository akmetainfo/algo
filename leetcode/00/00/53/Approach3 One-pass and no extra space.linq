<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 53. Maximum Subarray
// https://leetcode.com/problems/maximum-subarray/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        var sum = 0;
        var result = nums[0];
        for(var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            
            if(sum > result)
                result = sum;
            
            if(sum < 0)
                sum = 0;
        }
        return result;
    }
}

[Test]
[TestCase(new int[] { -2,1,-3,4,-1,2,1,-5,4 }, 6)]
[TestCase(new int[] { 1 }, 1)]
[TestCase(new int[] { 5,4,-1,7,8 }, 23)]
[TestCase(new int[] { -2, -1 }, -1)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().MaxSubArray(nums);
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