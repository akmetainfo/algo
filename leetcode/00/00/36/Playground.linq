<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 36. Valid Sudoku
// https://leetcode.com/problems/valid-sudoku/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        throw new NotImplementedException();
    }
}

private static IEnumerable<MyCase[]> TestCases()
{
    yield return new MyCase[]
    {
        new MyCase {
            Board = new char[][] {
                new char[] { '5','3','.','.','7','.','.','.','.' },
                new char[] { '6','.','.','1','9','5','.','.','.'},
                new char[] { '.','9','8','.','.','.','.','6','.'},
                new char[] { '8','.','.','.','6','.','.','.','3'},
                new char[] { '4','.','.','8','.','3','.','.','1'},
                new char[] { '7','.','.','.','2','.','.','.','6'},
                new char[] { '.','6','.','.','.','.','2','8','.'},
                new char[] { '.','.','.','4','1','9','.','.','5' },
                new char[] { '.','.','.','.','8','.','.','7','9' },
            },
            Expected = true,
        },
    };
    yield return new MyCase[]
    {
        new MyCase {
            Board = new char[][] {
                new char[] { '8','3','.','.','7','.','.','.','.' },
                new char[] { '6','.','.','1','9','5','.','.','.' },
                new char[] { '.','9','8','.','.','.','.','6','.' },
                new char[] { '8','.','.','.','6','.','.','.','3' },
                new char[] { '4','.','.','8','.','3','.','.','1' },
                new char[] { '7','.','.','.','2','.','.','.','6' },
                new char[] { '.','6','.','.','.','.','2','8','.' },
                new char[] { '.','.','.','4','1','9','.','.','5' },
                new char[] { '.','.','.','.','8','.','.','7','9' },
            },
            Expected = false,
        },
    };
    yield return new MyCase[]
    {
        new MyCase {
            Board = new char[][] {
                new char[] { '.','.','.','.','5','.','.','1','.' },
                new char[] { '.','4','.','3','.','.','.','.','.' },
                new char[] { '.','.','.','.','.','3','.','.','1' },
                new char[] { '8','.','.','.','.','.','.','2','.' },
                new char[] { '.','.','2','.','7','.','.','.','.' },
                new char[] { '.','1','5','.','.','.','.','.','.' },
                new char[] { '.','.','.','.','.','2','.','.','.' },
                new char[] { '.','2','.','9','.','.','.','.','.' },
                new char[] { '.','.','4','.','.','.','.','.','.' },
            },
            Expected = false,
        },
    };
    yield return new MyCase[]
    {
        new MyCase {
            Board = new char[][] {
                new char[] { '.','8','7','6','5','4','3','2','1' },
                new char[] { '2','.','.','.','.','.','.','.','.' },
                new char[] { '3','.','.','.','.','.','.','.','.' },
                new char[] { '4','.','.','.','.','.','.','.','.'},
                new char[] { '5','.','.','.','.','.','.','.','.' },
                new char[] { '6','.','.','.','.','.','.','.','.' },
                new char[] { '7','.','.','.','.','.','.','.','.' },
                new char[] { '8','.','.','.','.','.','.','.','.' },
                new char[] { '9','.','.','.','.','.','.','.','.' },
            },
            Expected = true,
        },
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(MyCase c)
{
    var actual = new Solution().IsValidSudoku(c.Board);
    Assert.That(actual, Is.EqualTo(c.Expected));
}

public class MyCase
{
    public char[][] Board { get; set; }
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