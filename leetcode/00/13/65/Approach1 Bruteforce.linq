<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1365. How Many Numbers Are Smaller Than the Current Number
// https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/

/*
    Time: O(N^2)
    Space: O(N)
*/
public class Solution
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        var result = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            var count = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j && nums[j] < nums[i])
                    count++;
            }
            result[i] = count;
        }

        return result;
    }
}

[Test]
[TestCase(new int[] { 8, 1, 2, 2, 3 }, new int[] { 4, 0, 1, 1, 3 })]
[TestCase(new int[] { 6, 5, 4, 8 }, new int[] { 2, 1, 0, 3 })]
[TestCase(new int[] { 7, 7, 7, 7 }, new int[] { 0, 0, 0, 0 })]
public void SolutionTests(int[] arr, int[] expected)
{
    var actual = new Solution().SmallerNumbersThanCurrent(arr);
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