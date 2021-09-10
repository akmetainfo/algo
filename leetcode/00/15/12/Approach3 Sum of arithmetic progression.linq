<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1512. Number of Good Pairs
// https://leetcode.com/problems/number-of-good-pairs/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public int NumIdenticalPairs(int[] nums)
    {
        return nums.GroupBy(x => x)
                   .Select(x => x.Count())
                   .Sum(x => (x - 1) * x / 2);
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1
{
    public int NumIdenticalPairs(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!dict.ContainsKey(num))
                dict.Add(num, 0);

            dict[num]++;
        }

        var result = 0;

        foreach (var n in dict.Values)
            result += (n - 1) * n / 2;

        return result;
    }
}

[Test]
[TestCase(new int[] { 1, 2, 3, 1, 1, 3 }, 4)]
[TestCase(new int[] { 1, 1, 1, 1 }, 6)]
[TestCase(new int[] { 1, 2, 3 }, 0)]
[TestCase(new int[] { 4, 4, 2, 2 }, 2)]
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