<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 12. Integer to Roman
// https://leetcode.com/problems/integer-to-roman/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    // Idea from https://habr.com/en/company/jugru/blog/553028/
    // With pipelines
    public string IntToRoman(int num)
    {
        Func<string, string> replace(string oldValue, string newValue) => input => input.Replace(oldValue, newValue);

        return new string('I', num)
            .Pipe(replace("IIIII", "V"))
            .Pipe(replace("VV", "X"))
            .Pipe(replace("XXXXX", "L"))
            .Pipe(replace("LL", "C"))
            .Pipe(replace("CCCCC", "D"))
            .Pipe(replace("DD", "M"))
            .Pipe(replace("VIIII", "IX")) // 9
            .Pipe(replace("IIII", "IV")) // 4
            .Pipe(replace("LXXXX", "XC")) // 90
            .Pipe(replace("XXXX", "XL")) // 40
            .Pipe(replace("DCCCC", "CM")) // 900
            .Pipe(replace("CCCC", "CD")); // 400
    }
}

public static class PipeExtension
{
    public static T Pipe<T>(this T obj, Func<T, T> f)
    {
        return f(obj);
    }
}

/*
    Time: O()
    Space: O()
*/
public class Solution1
{
    // Idea from https://habr.com/en/company/jugru/blog/553028/
    // Without pipelines
    public string IntToRoman(int num)
    {
        string result = new string('I', num);
        
        result = result.Replace("IIIII", "V");
        result = result.Replace("VV", "X");
        result = result.Replace("XXXXX", "L");
        result = result.Replace("LL", "C");
        result = result.Replace("CCCCC", "D");
        result = result.Replace("DD", "M");

        result = result.Replace("VIIII", "IX"); // 9
        result = result.Replace("IIII", "IV"); // 4
        result = result.Replace("LXXXX", "XC");  // 90
        result = result.Replace("XXXX", "XL"); // 40
        result = result.Replace("DCCCC", "CM");  // 900
        result = result.Replace("CCCC", "CD");  // 400
        
        return result;
    }
}

[Test]
[TestCase(1, "I")]
[TestCase(2, "II")]
[TestCase(3, "III")]
[TestCase(4, "IV")]
[TestCase(5, "V")]
[TestCase(6, "VI")]
[TestCase(7, "VII")]
[TestCase(8, "VIII")]
[TestCase(9, "IX")]
[TestCase(10, "X")]
[TestCase(40, "XL")]
[TestCase(50, "L")]
[TestCase(58, "LVIII")]
[TestCase(100, "C")]
[TestCase(500, "D")]
[TestCase(1000, "M")]
[TestCase(1994, "MCMXCIV")]
public void SolutionTests(int num, string expected)
{
    var actual = new Solution().IntToRoman(num);
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