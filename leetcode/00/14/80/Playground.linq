<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1480. Running Sum of 1d Array
// https://leetcode.com/problems/running-sum-of-1d-array/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int[] RunningSum(int[] nums)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new int[] { 1,2,3,4 }, new int[] { 1,3,6,10 })]
[TestCase(new int[] { 1,1,1,1,1 }, new int[] { 1,2,3,4,5 })]
[TestCase(new int[] { 3,1,2,10,1 }, new int[] { 3,4,6,16,17 })]
public void SolutionTests(int[] nums, int[] expected)
{
    var actual = new Solution().RunningSum(nums);
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