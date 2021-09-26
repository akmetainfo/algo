<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 283. Move Zeroes
// https://leetcode.com/problems/move-zeroes/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        var j = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                (nums[j], nums[i]) = (nums[i], nums[j]);
                j++;
            }
        }
    }
}

[Test]
[TestCase(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
[TestCase(new int[] { 0 }, new int[] { 0 })]
public void SolutionTests(int[] nums, int[] expected)
{
    new Solution().MoveZeroes(nums);
    Assert.That(nums, Is.EquivalentTo(expected));
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