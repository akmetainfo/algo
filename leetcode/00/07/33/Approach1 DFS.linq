<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 733. Flood Fill
// https://leetcode.com/problems/flood-fill/

/*
    Time: O(N) where N is the number of pixels in the image. We might process every pixel.
    Space: O(N) the size of the implicit call stack when calling dfs.
*/
public class Solution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        var color = image[sr][sc];

        if (color != newColor)
            DFS(image, sr, sc, color, newColor);

        return image;
    }

    private void DFS(int[][] image, int r, int c, int color, int newColor)
    {
        if (image[r][c] != color)
            return;

        image[r][c] = newColor;

        if (r >= 1)
            DFS(image, r - 1, c, color, newColor);

        if (c >= 1)
            DFS(image, r, c - 1, color, newColor);

        if (r + 1 < image.Length)
            DFS(image, r + 1, c, color, newColor);

        if (c + 1 < image[0].Length)
            DFS(image, r, c + 1, color, newColor);
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[][] {
            new int[] {1,1,1},
            new int[] {1,1,0},
            new int[] {1,0,1},
        },
        1,
        1,
        2,
        new int[][] {
            new int[] {2,2,2},
            new int[] {2,2,0},
            new int[] {2,0,1},
        },
    };
    yield return new object[]
    {
        new int[][] {
            new int[] {0,0,0},
            new int[] {0,0,0},
        },
        0,
        0,
        2,
        new int[][] {
            new int[] {2,2,2},
            new int[] {2,2,2},
        },
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]

public void SolutionTests(int[][] image, int sr, int sc, int newColor, int[][] expected)
{
    var actual = new Solution().FloodFill(image, sr, sc, newColor);
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