<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 412. Fizz Buzz
// https://leetcode.com/problems/fizz-buzz/

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution
{
    public IList<string> FizzBuzz(int n)
    {
        var result = new List<string>();

        for (int num = 1; num <= n; num++)
        {
            var divisibleBy3 = num % 3 == 0;
            var divisibleBy5 = num % 5 == 0;

            var numAnsStr = string.Empty;

            if (divisibleBy3)
            {
                numAnsStr += "Fizz";
            }

            if (divisibleBy5)
            {
                numAnsStr += "Buzz";
            }

            if (numAnsStr.Equals(string.Empty))
            {
                numAnsStr += num.ToString();
            }

            result.Add(numAnsStr);
        }

        return result;
    }
}

[Test]
[TestCase(3, new string[] { "1", "2", "Fizz" })]
[TestCase(15, new string[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" })]
public void SolutionTests(int n, string[] expected)
{
    var result = new Solution().FizzBuzz(n);
    Assert.That(expected, Is.EqualTo(result));
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