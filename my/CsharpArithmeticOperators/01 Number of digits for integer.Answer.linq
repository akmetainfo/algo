<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 01. Number of digits for integer

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int Digits(int num)
    {
        var result = 0;
        
        while(num > 0)
        {
            num = num / 10;
            result++;
        }
        
        return result;
    }
}

[Test]
[TestCase(0, 0)]
[TestCase(1, 1)]
[TestCase(2, 1)]
[TestCase(3, 1)]
[TestCase(9, 1)]
[TestCase(10, 2)]
[TestCase(42, 2)]
[TestCase(99, 2)]
[TestCase(100, 3)]
[TestCase(123, 3)]
[TestCase(1979, 4)]
public void SolutionTests(int num, int expected)
{
    var actual = new Solution().Digits(num);
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