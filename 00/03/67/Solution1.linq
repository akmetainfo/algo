<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 367. Valid Perfect Square
// https://leetcode.com/problems/valid-perfect-square/

/*
    Time: O(log n)
    Space: O(1)
*/
public class Solution
{
    // classic binary search, simplest form
    public bool IsPerfectSquare(int num)
    {
        var left = 1;
        var right = num / 2;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            ulong sq = (ulong)mid * (ulong)mid;

            if (sq == (ulong)num)
                return true;

            if (sq < (ulong)num)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return false;
    }
    
    // we reduces the upper border from num to num/2
    // but we need to check edge case (for 1)
    public bool IsPerfectSquare2(int num)
    {
        if (num == 1)
            return true;

        var left = 1;
        var right = num / 2; // 2 * x < x ^ 2 when x > 2

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            ulong sq = (ulong)mid * (ulong)mid;

            if (sq == (ulong)num)
                return true;

            if (sq < (ulong)num)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return false;
    }    
}

[Test]
[TestCase(2147483647, false)] // No 'Time Limit exceeded' for this approache!
[TestCase(1, true)]
[TestCase(2, false)]
[TestCase(3, false)]
[TestCase(4, true)]
[TestCase(5, false)]
[TestCase(6, false)]
[TestCase(7, false)]
[TestCase(8, false)]
[TestCase(9, true)]
[TestCase(14, false)]
[TestCase(16, true)]
[TestCase(808201, true)]
public void SolutionTests(int nums, bool expected)
{
    var actual = new Solution().IsPerfectSquare(nums);
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