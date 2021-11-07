<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 350. Intersection of Two Arrays II
// https://leetcode.com/problems/intersection-of-two-arrays-ii/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new int[] { 1,2,2,1 }, new int[] { 2, 2 }, new int[] { 2, 2 })]
[TestCase(new int[] { 4,9,5 }, new int[] { 9,4,9,8,4 }, new int[] { 4, 9 })]
public void SolutionTests(int[] nums1, int[] nums2, int[] expected)
{
    var actual = new Solution().Intersect(nums1, nums2);
    Assert.That(actual, Is.EquivalentTo(expected));
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