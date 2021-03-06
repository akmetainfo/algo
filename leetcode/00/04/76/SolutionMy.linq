<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 476. Number Complement
// https://leetcode.com/problems/number-complement/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int FindComplement(int num)
    {
        return NearestTwo(num) - num - 1;
    }

    private int NearestTwo(int target)
    {
        var left = 0;
        var right = 32;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            var val = (long)Math.Pow(2, mid);

            if (val == (long)target)
                return (int)Math.Pow(2, mid + 1);

            if (val < (long)target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        return (int)Math.Pow(2, left);
    }
}

public class Solution1
{
    // This works, but very slowly for case 2147483647 - Time Limit Exceeded
    public int FindComplement(int num)
    {
        var nearestTwo = 2;

        while (nearestTwo <= num)
            nearestTwo *= 2;

        return nearestTwo - num - 1;
    }
}

[Test]
[TestCase(1, 0)]
[TestCase(2, 1)]
[TestCase(3, 0)]
[TestCase(4, 3)]
[TestCase(5, 2)]
[TestCase(2147483647, 0)]
public void SolutionTests(int num, int expected)
{
    var actual = new Solution().FindComplement(num);
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