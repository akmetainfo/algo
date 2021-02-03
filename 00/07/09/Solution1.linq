<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 709. To Lower Case
// https://leetcode.com/problems/to-lower-case/

/*
    Time: O(n)
    Space: O(n)
*/
public class Solution
{
    public string ToLowerCase(string str)
    {
        var result = new StringBuilder();
        foreach (char c in str)
        {
            if (('A' <= c) && (c <= 'Z'))
            {
                result.Append((char)(c + 32));
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
}

[Test]
[TestCase("Hello", "hello")]
[TestCase("here", "here")]
[TestCase("LOVELY", "lovely")]
public void SolutionTests(string str, string expected)
{
    var result = new Solution().ToLowerCase(str);
    Assert.That(result, Is.EqualTo(expected));
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