<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 52. N-Queens II
// https://leetcode.com/problems/n-queens-ii/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int TotalNQueens(int n)
    {
        var result = 0;
        Handle(ref result, GetEmptyBoard(n), 0, 0, n);
        return result;
    }
    
    private void Handle(ref int result, int[] board, int currentCell, int queens, int max)
    {
        //board.Dump();
        if(queens == max)
        {
            result++;
            return;
        }

        if(currentCell != max * max)
        {
            board[currentCell] = 1;
            if(IsValid(board, max))
            {
                Handle(ref result, board, currentCell + 1, queens + 1, max);
            }
            
            board[currentCell] = 0;
            Handle(ref result, board, currentCell + 1, queens, max);            
        }
    }
    
    private int[] GetEmptyBoard(int n)
    {
        return new int[n * n];
    }
    
    private bool IsValid(int[] board, int max)
    {
        var chess = Convert(board, max);
        if(chess.Count() < 2)
            return true;
        for(var i = 0; i < chess.Count(); i++)
        {
            for(var j = i+1; j < chess.Count(); j++)
            {
                var currentQueen = chess[i];
                var nextQueen = chess[j];
                if(Beat(currentQueen, nextQueen))
                    return false;
            }
        }
        return true;
    }
    
    private bool Beat((int, int) current, (int, int) next)
    {
        if(current.Item1 == next.Item1)
            return true;
            
        if(current.Item2 == next.Item2)
            return true;
            
        var deltaX = Math.Abs(current.Item1 - next.Item1);
        var deltaY = Math.Abs(current.Item2 - next.Item2);
        
        if(deltaX == deltaY)
            return true;
            
        return false;
    }
    
    private List<(int, int)> Convert(int[] board, int max)
    {
        var result = new List<(int, int)>();
        var position = 0;
        for(var i = 0; i < max; i++)
        {
            for(var j = 0; j < max; j++)
            {   
                if(board[position] == 1)
                     result.Add((i, j));
                position++;
            }
        }
        return result;
    }
}

[Test]
[TestCase(1, 1)]
[TestCase(2, 0)]
[TestCase(3, 0)]
[TestCase(4, 2)]
[TestCase(5, 10)]
[TestCase(6, 4)]
[TestCase(7, 40)]
[TestCase(8, 92)]
[TestCase(9, 352)]
public void SolutionTests(int n, int expected)
{
    var actual = new Solution().TotalNQueens(n);
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