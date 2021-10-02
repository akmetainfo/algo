<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 542. 01 Matrix
// https://leetcode.com/problems/01-matrix/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        if (grid == null || grid[0].Length == 0)
            return 0;

        int m = grid.Length, n = grid[0].Length;
        int fresh = 0;

        Queue<(int, int)> queue = new Queue<(int, int)>();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                    fresh++;
                else if (grid[i][j] == 2)
                    queue.Enqueue((i, j));
            }
        }

        if (fresh == 0)
            return 0;

        int time = 0;
        int[,] dir = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
        while (queue.Count > 0)
        {
            time++;
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var curr = queue.Dequeue();
                for (int j = 0; j < 4; j++)
                {
                    int newRow = curr.Item1 + dir[j, 0];
                    int newCol = curr.Item2 + dir[j, 1];

                    if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && grid[newRow][newCol] == 1)
                    {
                        grid[newRow][newCol] = 2;
                        queue.Enqueue((newRow, newCol));
                        fresh--;
                    }
                }
            }
        }

        return fresh == 0 ? time - 1 : -1;
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[][] {
            new int[] {2,1,1},
            new int[] {1,1,0},
            new int[] {0,1,1},
        },
        4,
    };
    yield return new object[]
    {
        new int[][] {
            new int[] {2,1,1},
            new int[] {0,1,1},
            new int[] {1,0,1},
        },
        -1,
    };
    yield return new object[]
    {
        new int[][] {
            new int[] {0,2},
        },
        0,
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int[][] grid, int expected)
{
    var actual = new Solution().OrangesRotting(grid);
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