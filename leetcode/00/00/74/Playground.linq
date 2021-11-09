<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 74. Search a 2D Matrix
// https://leetcode.com/problems/search-a-2d-matrix/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        throw new NotImplementedException();
    }
}

private static IEnumerable<MyCase[]> TestCases()
{
    yield return new MyCase[]
    {
        new MyCase {
            Matrix = new int[][] {
                new int[] { 1,3,5,7 },
                new int[] { 10,11,16,20 },
                new int[] { 23,30,34,60 },
            },
            Target = 3,
            Expected = true,
        },
    };
    yield return new MyCase[]
    {
        new MyCase {
            Matrix = new int[][] {
                new int[] { 1,3,5,7 },
                new int[] { 10,11,16,20 },
                new int[] { 23,30,34,60 },
            },
            Target = 13,
            Expected = false,
        },
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(MyCase c)
{
    var actual = new Solution().SearchMatrix(c.Matrix, c.Target);
    Assert.That(actual, Is.EqualTo(c.Expected));
}

public class MyCase
{
    public int[][] Matrix { get; set; }
    public int Target { get; set; }
    public bool Expected { get; set; }
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