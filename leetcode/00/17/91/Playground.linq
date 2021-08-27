<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1791. Find Center of Star Graph
// https://leetcode.com/problems/find-center-of-star-graph/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int FindCenter(int[][] edges)
    {
        throw new NotImplementedException();
    }
}


private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[][]
        {
            new[] {1,2},
            new[] {2,3},
            new[] {4,2},
        },
        2
    };
    yield return new object[]
    {
        new int[][]
        {
            new[] {1,2},
            new[] {5,1},
            new[] {1,3},
            new[] {1,4},
        },
        1
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int[][] edges, int expected)
{
    var actual = new Solution().FindCenter(edges);
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