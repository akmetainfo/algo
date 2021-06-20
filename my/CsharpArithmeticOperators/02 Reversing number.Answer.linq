<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 02. Reversing Number

/*
    Time: O(log n)
    Space: O(1)
*/
public class Solution
{
    public long ReverseInt(int num)
    {
        if(num == int.MinValue)
            throw new ArgumentOutOfRangeException("You can't pass int.MinValue");
            
        if(num < 0)
            return -ReverseInt(-num);
            
        long result = 0;
        
        while(num > 0)
        {
            result = result * 10 + (num % 10);
            num /= 10;
        }
        
        return result;
    }
}

[Test]
[TestCase(0, 0)]
[TestCase(1, 1)]
[TestCase(2, 2)]
[TestCase(3, 3)]
[TestCase(9, 9)]
[TestCase(10, 1)]
[TestCase(42, 24)]
[TestCase(99, 99)]
[TestCase(100, 1)]
[TestCase(123, 321)]
[TestCase(1979, 9791)]
[TestCase(int.MaxValue, 7463847412 )]
[TestCase(-1, -1)]
[TestCase(-2, -2)]
[TestCase(-3, -3)]
[TestCase(-9, -9)]
[TestCase(-10, -1)]
[TestCase(-42, -24)]
[TestCase(-99, -99)]
[TestCase(-100, -1)]
[TestCase(-123, -321)]
[TestCase(-1979, -9791)]
//[TestCase(int.MinValue, -8463847412)] // can works only when num is long, not int OR hardcoded answer
public void SolutionTests(int num, long expected)
{
    var actual = new Solution().ReverseInt(num);
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