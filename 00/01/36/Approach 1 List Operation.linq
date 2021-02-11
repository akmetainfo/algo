<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 136. Single Number
// https://leetcode.com/problems/single-number/

/*
    Time: O(n^2) We iterate through nums, taking O(n) time. We search the whole list to find whether there is duplicate number, taking O(n) time. Because search is in the for loop, so we have to multiply both time complexities which is O(n^2).
    Space: O(n) We need a list of size n to contain elements in nums.
*/
public class Solution
{
    public int SingleNumber(int[] nums)
    {
        var no_duplicate_list = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!no_duplicate_list.Contains(nums[i]))
                no_duplicate_list.Add(nums[i]);
            else
                no_duplicate_list.Remove(nums[i]);
        }
        
        return no_duplicate_list[0];
    }
}

[Test]
[TestCase(new[] { 2, 2, 1 }, 1)]
[TestCase(new[] { 4, 1, 2, 1, 2 }, 4)]
[TestCase(new[] { 1 }, 1)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().SingleNumber(nums);
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