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
    public string IntToRoman(int num)
    {
        var sb = new StringBuilder(10);
        
        while (num > 0)
        {
            sb.Append(nextRoman(ref num));
        }
        
        return sb.ToString();
    }

    public static string nextRoman(ref int num)
    {
        if (num - 1000 >= 0) { num -= 1000; return "M"; }
        if (num - 900 >= 0) { num -= 900; return "CM"; }
        if (num - 500 >= 0) { num -= 500; return "D"; }
        if (num - 400 >= 0) { num -= 400; return "CD"; }
        if (num - 100 >= 0) { num -= 100; return "C"; }
        if (num - 90 >= 0) { num -= 90; return "XC"; }
        if (num - 50 >= 0) { num -= 50; return "L"; }
        if (num - 40 >= 0) { num -= 40; return "XL"; }
        if (num - 10 >= 0) { num -= 10; return "X"; }
        if (num - 9 >= 0) { num -= 9; return "IX"; }
        if (num - 5 >= 0) { num -= 5; return "V"; }
        if (num - 4 >= 0) { num -= 4; return "IV"; }
        if (num - 1 >= 0) { num -= 1; return "I"; }
        return "";
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