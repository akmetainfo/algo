<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1512. Number of Good Pairs
// https://leetcode.com/problems/number-of-good-pairs/

/*
    Time: O(N^2)
    Space: O(1)
*/
public class Solution
{
    public int NumIdenticalPairs(int[] nums)
    {
        var result = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if(nums[i] == nums[j])
                    result++;
            }
        }
        
        return result;
    }
}

[Test]
[TestCase(new int[] { 1, 2, 3, 1, 1, 3 }, 4)]
[TestCase(new int[] { 1, 1, 1, 1 }, 6)]
[TestCase(new int[] { 1, 2, 3 }, 0)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().NumIdenticalPairs(nums);
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