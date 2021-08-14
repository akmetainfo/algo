<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1413. Minimum Value to Get Positive Step by Step Sum
// https://leetcode.com/problems/minimum-value-to-get-positive-step-by-step-sum/

/*
    Time: O()
    Space: O(1)
*/
public class Solution
{
    public int MinStartValue(int[] nums)
    {
        var result = 1;
        
        while(true)
        {
            var failure = false;
            var sum = result;
            for(var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if(sum < 1)
                {
                    failure = true;
                    break;
                }
            }
            if(failure)
            {
                result++;
            }
            else
            {
                break;
            }
        }
        
        return result;
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