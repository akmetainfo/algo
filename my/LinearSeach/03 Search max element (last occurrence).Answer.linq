<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 03 Search max element (last occurrence)

/*
Given non-empty array find max element and its index.
If there more than one max element, return last occurrence.
*/

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution
{
    public int[] MaxElement(int[] nums)
    {
        var index = 0;
        var max = nums[index];
        for(var i = 1; i < nums.Length; i++)
        {
            if(nums[i] >= max)
            {
                max = nums[i];
                index = i;
            }
        }
        return new[] { max, index };
    }
}

[Test]
[TestCase(new int[] { 7 }, new[] { 7, 0 })]
[TestCase(new int[] { 7, -3 }, new[] { 7, 0 })]
[TestCase(new int[] { 7, 7 }, new[] { 7, 1 })]
[TestCase(new int[] { 7, 8 }, new[] { 8, 1 })]
[TestCase(new int[] { 1, -4, 2, 0, 2, 3 }, new[] { 3, 5 })]
public void SolutionTests(int[] nums, int[] expected)
{
    var actual = new Solution().MaxElement(nums);
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