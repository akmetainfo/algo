<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 566. Reshape the Matrix
// https://leetcode.com/problems/reshape-the-matrix/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        throw new NotImplementedException();
    }
}

private static IEnumerable<MyCase[]> TestCases()
{
    yield return new MyCase[]
    {
        new MyCase {
            Mat = new int[][] {
                new int[] { 1, 2 },
                new int[] { 3, 4 },
            },
            R = 1,
            C = 4,
            Expected = new int[][] {
                new int[] { 1,2,3,4 },
            },
        },
    };
    yield return new MyCase[]
    {
        new MyCase {
            Mat = new int[][] {
                new int[] { 1, 2 },
                new int[] { 3, 4 },
            },
            R = 2,
            C = 4,
            Expected = new int[][] {
                new int[] { 1, 2 },
                new int[] { 3, 4 },
            },
        },
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(MyCase c)
{
    var actual = new Solution().MatrixReshape(c.Mat, c.R, c.C);
    Assert.That(actual, Is.EqualTo(c.Expected));
}

public class MyCase
{
    public int[][] Mat { get; set; }
    public int R { get; set; }
    public int C { get; set; }
    public int[][] Expected { get; set; }
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