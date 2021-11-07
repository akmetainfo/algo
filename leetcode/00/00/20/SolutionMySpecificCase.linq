<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// Based on:
// 20. Valid Parentheses
// https://leetcode.com/problems/valid-parentheses/

/*
    Time: O(n)
    Space: O(1)
    
    если нам нужно посчитать правильность скобок одного типа, то можно даже не стек использовать, а просто хранить число открытых скобок и увеличивать/уменьшать
*/
public class Solution
{
    public bool IsValid(string s)
    {
        if (s.Length == 0)
            return true;

        if (s.Length % 2 > 0)
            return false;
            
        var count = 0;
            
        foreach (var element in s)
        {
            switch (element)
            {
                case '(':
                    count++;
                    break;

                case ')':
                    if (count == 0)
                        return false;
                    count--;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(element));
            }
        }

        return count == 0;
    }
}

[Test]
[TestCase("", true)]
[TestCase("(", false)]
[TestCase("()", true)]
[TestCase("()()", true)]
[TestCase("(()())", true)]
[TestCase("((", false)]
[TestCase("()(", false)]
[TestCase(")", false)]
[TestCase("())", false)]
public void SolutionTests(string s, bool expected)
{
    var actual = new Solution().IsValid(s);
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