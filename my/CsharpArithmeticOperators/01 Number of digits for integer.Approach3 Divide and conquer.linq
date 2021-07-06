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
// Divide and conquer: https://stackoverflow.com/q/1306727
public class Solution
{
    public int Digits(int num)
    {
        if(num == int.MinValue)
            return 10;
            
        if(num<0)
            return Digits(-num);
            
        if (num < 100000) {
            // 5 or less
            if (num < 100){
                // 1 or 2
                if (num < 10)
                    return 1;
                else
                    return 2;
            } else {
                // 3 or 4 or 5
                if (num < 1000)
                    return 3;
                else {
                    // 4 or 5
                    if (num < 10000)
                        return 4;
                    else
                        return 5;
                }
            }
        } else {
            // 6 or more
            if (num < 10000000) {
                // 6 or 7
                if (num < 1000000)
                    return 6;
                else
                    return 7;
            } else {
                // 8 to 10
                if (num < 100000000)
                    return 8;
                else {
                    // 9 or 10
                    if (num < 1000000000)
                        return 9;
                    else
                        return 10;
                }
            }
        }
    }
}

[Test]
[TestCase(0, 1)]
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
[TestCase(-2147483648, 10)]
[TestCase(2147483647, 10)]
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