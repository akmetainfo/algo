<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 26. Remove Duplicates from Sorted Array
// https://leetcode.com/problems/remove-duplicates-from-sorted-array/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new int[] { }, new int[] { }, 0)]
[TestCase(new int[] { 10 }, new int[] { 10 }, 1)]
[TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 2)]
[TestCase(new int[] { 1, 1 }, new int[] { 1 }, 1)]
[TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 3)]
[TestCase(new int[] { 1, 1, 1 }, new int[] { 1 }, 1)]
[TestCase(new int[] { 1, 1, 2 }, new int[] { 1, 2 }, 2)]
[TestCase(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new int[] { 0, 1, 2, 3, 4 }, 5)]
public void SolutionTests(int[] nums, int[] expectedArr, int expectedResult)
{
    var result = new Solution().RemoveDuplicates(nums);
    Assert.That(result, Is.EqualTo(expectedResult));
    Assert.That(nums.Take(expectedResult), Is.EquivalentTo(expectedArr));
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