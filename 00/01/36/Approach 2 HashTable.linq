<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 136. Single Number
// https://leetcode.com/problems/single-number/

/*
    Time: O(n)
    Space: O(n)
*/
public class Solution
{
    public int SingleNumber(int[] nums)
    {
        var hash_table = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if(hash_table.ContainsKey(nums[i]))
                hash_table[nums[i]]++;
            else
                hash_table.Add(nums[i], 1);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (hash_table[nums[i]] == 1)
                return nums[i];
        }
        
        throw new Exception("invalid data");
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