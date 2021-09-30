<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 695. Max Area of Island
// https://leetcode.com/problems/max-area-of-island/

/*
    Time: O(R * C) where R is the number of rows in the given grid, and C is the number of columns. We visit every square once.
    Space: O(R * C) the space used by seen to keep track of visited squares, and the space used by the call stack during our recursion.
*/
public class Solution
{
    int[][] grid;
    bool[][] seen;

    private int area(int r, int c)
    {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || seen[r][c] || grid[r][c] == 0)
            return 0;

        seen[r][c] = true;

        return (1 + area(r + 1, c) + area(r - 1, c) + area(r, c - 1) + area(r, c + 1));
    }

    public int MaxAreaOfIsland(int[][] grid)
    {
        this.grid = grid;
        seen = new bool[grid.Length][];
        for (int i = 0; i < grid.Length; i++)
        {
            seen[i] = new bool[grid[0].Length];

        }
        int ans = 0;
        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[0].Length; c++)
            {
                ans = Math.Max(ans, area(r, c));
            }
        }
        return ans;
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