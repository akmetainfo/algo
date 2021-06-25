<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 13. Roman to Integer
// https://leetcode.com/problems/roman-to-integer/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int RomanToInt(string s)
    {
        var result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int curr = Convert(s[i]);
            if (i == s.Length - 1)
            {
                result += curr;
            }
            else
            {
                var next = Convert(s[i + 1]);
                if (curr < next)
                    result -= curr;
                else
                    result += curr;
            }
        }

        return result;
    }

    private static int Convert(char v)
    {
        switch (@v)
        {
            case 'I':
                return 1;
            case 'V':
                return 5;
            case 'X':
                return 10;
            case 'L':
                return 50;
            case 'C':
                return 100;
            case 'D':
                return 500;
            case 'M':
                return 1000;
            default:
                throw new ArgumentOutOfRangeException(nameof(v));
        }
    }
}

public class Solution1
{
    public int RomanToInt(string s)
    {
        if (s.Length == 1)
            return Convert(s[0]);

        var result = 0;

        var curr = Convert(s[0]);

        for (int i = 0; i < s.Length - 1; i++)
        {
            var next = Convert(s[i + 1]);

            if (curr < next)
                result -= curr;
            else
                result += curr;

            curr = next;
        }

        result += Convert(s[s.Length - 1]);

        return result;
    }

    private static int Convert(char v)
    {
        switch (@v)
        {
            case 'I':
                return 1;
            case 'V':
                return 5;
            case 'X':
                return 10;
            case 'L':
                return 50;
            case 'C':
                return 100;
            case 'D':
                return 500;
            case 'M':
                return 1000;
            default:
                throw new ArgumentOutOfRangeException(nameof(v));
        }
    }
}

[Test]
[TestCase("I", 1)]
[TestCase("II", 2)]
[TestCase("III", 3)]
[TestCase("IV", 4)]
[TestCase("V", 5)]
[TestCase("VI", 6)]
[TestCase("VII", 7)]
[TestCase("VIII", 8)]
[TestCase("IX", 9)]
[TestCase("X", 10)]
[TestCase("XL", 40)]
[TestCase("L", 50)]
[TestCase("LVIII", 58)]
[TestCase("C", 100)]
[TestCase("D", 500)]
[TestCase("M", 1000)]
[TestCase("MCMXCIV", 1994)]
public void SolutionTests(string s, int expected)
{
    var actual = new Solution().RomanToInt(s);
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