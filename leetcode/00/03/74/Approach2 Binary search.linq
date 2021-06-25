<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 374. Guess Number Higher or Lower
// https://leetcode.com/problems/guess-number-higher-or-lower/

/*
    Time: O(log 2 n). Binary Search is used.
    Space: O(1). No extra space is used. 
*/
public class Solution : GuessGame
{
    public int GuessNumber(int n)
    {
        int left = 1;
        int rigth = n;
        
        while (left <= rigth)
        {
            int mid = left + (rigth - left) / 2;
            
            int res = guess(mid);
            
            if (res == 0)
                return mid;
            
            if (res < 0)
                rigth = mid - 1;
            else
                left = mid + 1;
        }
        
        return -1;
    }
}

[Test]
[TestCase(10, 6)]
[TestCase(1, 1)]
[TestCase(2, 1)]
[TestCase(2, 2)]
public void SolutionTests(int n, int pick)
{
    var solution = new Solution();
    solution.SetupPick(pick);
    var actual = solution.GuessNumber(n);
    Assert.That(actual, Is.EqualTo(pick));
}

public class GuessGame
{
    private int _pick;

    public void SetupPick(int pick)
    {
        this._pick = pick;
    }

    public int guess(int num)
    {
        if (this._pick < num) return -1;
        if (this._pick > num) return 1;

        return 0;
    }
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