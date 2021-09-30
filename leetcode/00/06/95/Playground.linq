<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 695. Max Area of Island
// https://leetcode.com/problems/max-area-of-island/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        throw new NotImplementedException();
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[][] {
            new int[] {0,0,1,0,0,0,0,1,0,0,0,0,0},
            new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
            new int[] {0,1,1,0,1,0,0,0,0,0,0,0,0},
            new int[] {0,1,0,0,1,1,0,0,1,0,1,0,0},
            new int[] {0,1,0,0,1,1,0,0,1,1,1,0,0},
            new int[] {0,0,0,0,0,0,0,0,0,0,1,0,0},
            new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
            new int[] {0,0,0,0,0,0,0,1,1,0,0,0,0},
        },
        6
    };
    yield return new object[]
    {
        new int[][] {
            new int[] {0,0,0,0,0,0,0,0},
        },
        0
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int[][] grid, int expected)
{
    var actual = new Solution().MaxAreaOfIsland(grid);
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