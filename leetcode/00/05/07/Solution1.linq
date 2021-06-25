<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 507. Perfect Number
// https://leetcode.com/problems/perfect-number/

/*
    Time: O(sqrt n)
    Space: O(1)
*/
public class Solution
{
    public bool CheckPerfectNumber(int num)
    {
        var sum = 0;
        for (var i = 1; i *i <= num; i++)
        {
            if (num % i == 0)
            {
                sum += i;
                if (i * i != num)
                    sum += num / i;
            }
        }
        return sum - num == num;
    }
}

[Test]
[TestCase(28, true)]
[TestCase(6, true)]
[TestCase(496, true)]
[TestCase(8128, true)]
[TestCase(2, false)]
public void SolutionTests(int num, bool expected)
{
    var actual = new Solution().CheckPerfectNumber(num);
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