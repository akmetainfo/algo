<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1413. Minimum Value to Get Positive Step by Step Sum
// https://leetcode.com/problems/minimum-value-to-get-positive-step-by-step-sum/

/*
    Time: O(N) two pass solution
    Space: O(N)
*/
public class Solution
{
    public int MinStartValue(int[] nums)
    {
        var pref = new int[nums.Length + 1];
        
        for(var i = 0; i < nums.Length; i++)
            pref[i+1] = pref[i] + nums[i];
            
        var min = pref[0];
        for(var i = 1; i < pref.Length; i++)
            if(pref[i] < min)
                min = pref[i];
                
        var result = 1 - min;
        
        return result > 1 ? result : 1;
    }
}

[Test]
[TestCase(new int[] { -3,2,-3,4,2 }, 5 )]
[TestCase(new int[] { 1,2 }, 1 )]
[TestCase(new int[] { 1,-2,-3 }, 5 )]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().MinStartValue(nums);
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