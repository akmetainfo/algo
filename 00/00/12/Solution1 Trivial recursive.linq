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
        if (num >= 1000) return "M" + IntToRoman(num - 1000);
        if (num >= 900) return "CM" + IntToRoman(num - 900);
        if (num >= 500) return "D" + IntToRoman(num - 500);
        if (num >= 400) return "CD" + IntToRoman(num - 400);
        if (num >= 100) return "C" + IntToRoman(num - 100);
        if (num >= 90) return "XC" + IntToRoman(num - 90);
        if (num >= 50) return "L" + IntToRoman(num - 50);
        if (num >= 40) return "XL" + IntToRoman(num - 40);
        if (num >= 10) return "X" + IntToRoman(num - 10);
        if (num >= 9) return "IX" + IntToRoman(num - 9);
        if (num >= 5) return "V" + IntToRoman(num - 5);
        if (num >= 4) return "IV" + IntToRoman(num - 4);
        if (num >= 1) return "I" + IntToRoman(num - 1);

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
public void SolutionTests(int num,string expected)
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