<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 189. Rotate Array
// https://leetcode.com/problems/rotate-array/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        if (k == 0 || nums.Length < 2)
            return;

        var tmp = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
            tmp[(i + k) % nums.Length] = nums[i];

        for (int i = 0; i < nums.Length; i++)
            nums[i] = tmp[i];
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1
{
    public void Rotate(int[] nums, int k)
    {
        k %= nums.Length;

        var result = nums.ToArray();

        for (int i = 0; i < nums.Length; i++)
        {
            //var newPos = i - k >= 0 ? i - k : i - k + result.Length;
            var newPos = (i - k + result.Length) % result.Length;
            nums[i] = result[newPos];
        }
    }
}

[Test]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
[TestCase(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 })]
public void SolutionTests(int[] nums, int k, int[] expected)
{
    new Solution().Rotate(nums, k);
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