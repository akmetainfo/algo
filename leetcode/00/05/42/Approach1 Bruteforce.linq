<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 542. 01 Matrix
// https://leetcode.com/problems/01-matrix/

/*
    Time: O(N^2) where N = mat.x * mat.y
    Space: O(1)
*/
public class Solution
{
    public int[][] UpdateMatrix(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        var result = new int[rows][];
        for (var i = 0; i < rows; i++)
            result[i] = new int[cols];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (matrix[i][j] == 0)
                    continue;

                result[i][j] = int.MaxValue;
                for (int k = 0; k < rows; k++)
                {
                    for (int l = 0; l < cols; l++)
                    {
                        if (matrix[k][l] == 0)
                        {
                            int dist_01 = Math.Abs(k - i) + Math.Abs(l - j);
                            result[i][j] = Math.Min(result[i][j], dist_01);
                        }
                    }
                }
            }
        }

        return result;
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[][] {
            new int[] {0,0,0},
            new int[] {0,1,0},
            new int[] {0,0,0},
        },
        new int[][] {
            new int[] {0,0,0},
            new int[] {0,1,0},
            new int[] {0,0,0},
        },
    };
    yield return new object[]
    {
        new int[][] {
            new int[] {0,0,0},
            new int[] {0,1,0},
            new int[] {1,1,1},
        },
        new int[][] {
            new int[] {0,0,0},
            new int[] {0,1,0},
            new int[] {1,2,1},
        },
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int[][] matrix, int[][] expected)
{
    var actual = new Solution().UpdateMatrix(matrix);
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