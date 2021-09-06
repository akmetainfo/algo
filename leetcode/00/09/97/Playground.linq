<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 997. Find the Town Judge
// https://leetcode.com/problems/find-the-town-judge/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int FindJudge(int n, int[][] trust)
    {
        throw new NotImplementedException();
    }
}


private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        2, 
        new int[][]
        {
            new[] {1,2},
        },
        2
    };
    yield return new object[]
    {
        3, 
        new int[][]
        {
            new[] {1,3},
            new[] {2,3},
        },
        3
    };
    yield return new object[]
    {
        3, 
        new int[][]
        {
            new[] {1,2},
            new[] {2,3},
        },
        -1
    };
    yield return new object[]
    {
        4, 
        new int[][]
        {
            new[] {1,3},
            new[] {1,4},
            new[] {2,3},
            new[] {2,4},
            new[] {4,3},
        },
        3
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int n, int[][] trust, int expected)
{
    var actual = new Solution().FindJudge(n, trust);
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