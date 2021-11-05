<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1266. Minimum Time Visiting All Points
// https://leetcode.com/problems/minimum-time-visiting-all-points/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution
{
    public int MinTimeToVisitAllPoints(int[][] points)
    {
        var result = 0;
        for(var i = 0; i < points.Length - 1; i++)
        {
            var currPoint = points[i];
            var currPointX = currPoint[0];
            var currPointY = currPoint[1];
            
            var nextPoint = points[i+1];
            var nextPointX = nextPoint[0];
            var nextPointY = nextPoint[1];
            
            var dx = Math.Abs(currPointX - nextPointX);
            var dy = Math.Abs(currPointY - nextPointY);
            
            result += Math.Max(dx, dy);
        }
        return result;
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[][] {
            new int[] { 1, 1 },
            new int[] { 3, 4 },
            new int[] { -1, 0 },
        },
        7,
    };
    yield return new object[]
    {
        new int[][] {
            new int[] { 3, 2 },
            new int[] { -2, 2 },
        },
        5,
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int[][] points, int expected)
{
    var actual = new Solution().MinTimeToVisitAllPoints(points);
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