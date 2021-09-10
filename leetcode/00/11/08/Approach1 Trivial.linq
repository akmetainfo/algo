<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1108. Defanging an IP Address
// https://leetcode.com/problems/defanging-an-ip-address/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public string DefangIPaddr(string address)
    {
        var sb = new StringBuilder();

        foreach (var c in address)
        {
            if (char.IsDigit(c))
                sb.Append(c);
            else
                sb.Append("[.]");
        }
        
        return sb.ToString();
    }
}

[Test]
[TestCase("1.1.1.1", "1[.]1[.]1[.]1")]
[TestCase("255.100.50.0", "255[.]100[.]50[.]0")]
public void SolutionTests(string address, string expected)
{
    var actual = new Solution().DefangIPaddr(address);
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