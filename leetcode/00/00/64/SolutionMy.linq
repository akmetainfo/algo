<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 64. Minimum Path Sum
// https://leetcode.com/problems/minimum-path-sum/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    private static int MaxPath = 0;
    
    public int MinPathSum(int[][] grid)
    {
        var result = new int[100]; //new int[grid.Length]; // Number of possible Paths!
        
        UniquePaths(grid, ref result, MaxPath, 0, 0, grid.Length - 1, grid[0].Length - 1);
        
        result.Dump();
        
        return result.Min();
    }
    
    private static void UniquePaths(int[][] grid, ref int[] result, int currentPathNum, int x, int y, int targetX, int targetY)
    {
        $"x={x}, y={y} X={targetX}, Y={targetY} == grid[x][y] = {grid[x][y]}".Dump();
        // TODO: How to add grid[x][y] to all paths which includes this cell?
        for(var i = 0; i < currentPathNum; i++)
        {
            result[i] += grid[x][y];
            //result[currentPathNum] += grid[x][y];
        }
        
        if(x == targetX && y == targetY)
        {
            return;
        }
        
        if(x < targetX)
        {
            UniquePaths(grid, ref result, NextPathNumber(), x + 1, y, targetX, targetY);
        }
        
        if(y < targetY)
        {
            UniquePaths(grid, ref result, NextPathNumber(), x, y + 1, targetX, targetY);
        }
    }
    
    private static int NextPathNumber()
    {
        MaxPath += 1;
        return MaxPath;
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[][] {
            new int[] {42}, 
        },
        42,
    };
    yield return new object[]
    {
        new int[][] {
            new int[] {1,3,1}, 
            new int[] {1,5,1},
            new int[] {4,2,1},
        },
        7,
    };
    yield return new object[]
    {
        new int[][] {
            new int[] {5,0,1,1,2,1,0,1,3,6,3,0,7,3,3,3,1},
            new int[] {1,4,1,8,5,5,5,6,8,7,0,4,3,9,9,6,0},
            new int[] {2,8,3,3,1,6,1,4,9,0,9,2,3,3,3,8,4},
            new int[] {3,5,1,9,3,0,8,3,4,3,4,6,9,6,8,9,9},
            new int[] {3,0,7,4,6,6,4,6,8,8,9,3,8,3,9,3,4},
            new int[] {8,8,6,8,3,3,1,7,9,3,3,9,2,4,3,5,1},
            new int[] {7,1,0,4,7,8,4,6,4,2,1,3,7,8,3,5,4},
            new int[] {3,0,9,6,7,8,9,2,0,4,6,3,9,7,2,0,7},
            new int[] {8,0,8,2,6,4,4,0,9,3,8,4,0,4,7,0,4},
            new int[] {3,7,4,5,9,4,9,7,9,8,7,4,0,4,2,0,4},
            new int[] {5,9,0,1,9,1,5,9,5,5,3,4,6,9,8,5,6},
            new int[] {5,7,2,4,4,4,2,1,8,4,8,0,5,4,7,4,7},
            new int[] {9,5,8,6,4,4,3,9,8,1,1,8,7,7,3,6,9},
            new int[] {7,2,3,1,6,3,6,6,6,3,2,3,9,9,4,4,8},
        },
        83,
    };    
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int[][] grid, int expected)
{
    var actual = new Solution().MinPathSum(grid);
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