<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 62. Unique Paths
// https://leetcode.com/problems/unique-paths/

/*
    Time: O()
    Space: O()
    
    // inspired by athdon at twitch
    // explanation here: https://leetcode.com/problems/unique-paths/discuss/637666/Python-Math-with-explanation
    // todo: avoid ulong overflowing in csharp
*/
public class Solution
{
    public int UniquePaths(int m, int n)
    {
        ulong a = (ulong)Factorial(n + m - 2);
        ulong b = (ulong)Factorial(n - 1);
        ulong c = (ulong)Factorial(m - 1);
        return  (int) ( (a / (b *  c)));
    }

    public ulong Factorial(int f)
    {
        if(f == 0)
            return 1;
        else
            return (ulong)f * Factorial(f-1); 
    }
}

[Test]
[TestCase(3, 7, 28)]
[TestCase(3, 2, 3)]
[TestCase(3, 3, 6)]
[TestCase(10, 10, 48620)]
//[TestCase(23, 12, 193536720)] ulong overflow!
public void SolutionTests(int m, int n, int expected)
{
    var actual = new Solution().UniquePaths(m, n);
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