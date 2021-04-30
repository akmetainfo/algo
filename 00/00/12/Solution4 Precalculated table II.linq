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
    public string IntToRoman(int num)
    {
        var roman = new Dictionary<int, string>()
        {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"},
        };

        var sb = new StringBuilder();

        foreach (var item in roman)
        {
            while (num >= item.Key)
            {
                sb.Append(item.Value);
                num -= item.Key;
            }
        }

        return sb.ToString();
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