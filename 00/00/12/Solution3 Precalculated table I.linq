<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 12. Integer to Roman
// https://leetcode.com/problems/integer-to-roman/

/*
    Time: O(log n)
    Space: O(1)
*/
public class Solution
{
    private static readonly string[][] table =
    {
        //       0    1     2      3     4    5     6      7       8     9
        new[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" },
        new[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" },
        new[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" },
        new[] { "", "M", "MM", "MMM" },
    };

    public string IntToRoman(int num)
    {
        var sb = new StringBuilder(15);
        var step = 0;
        while (num > 0)
        {
            var digit = num % 10;
            sb.Insert(0, table[step][digit]);
            num = num / 10;
            step++;
        }

        return sb.ToString();
    }
}

[Test]
[TestCase(1, "I")]
[TestCase(2, "II")]
[TestCase(5, "V")]
[TestCase(6, "VI")]
[TestCase(7, "VII")]
[TestCase(8, "VIII")]
[TestCase(10, "X")]
[TestCase(40, "XL")]
[TestCase(50, "L")]
[TestCase(100, "C")]
[TestCase(500, "D")]
[TestCase(1000, "M")]
[TestCase(3, "III")]
[TestCase(4, "IV")]
[TestCase(9, "IX")]
[TestCase(58, "LVIII")]
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