<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 62. Unique Paths
// https://leetcode.com/problems/unique-paths/

/*
    Time: O(N)
    Space: O(1)
    
*/
public class Solution
{
    public int UniquePaths(int m, int n)
    {
        ulong result = 1;
        for (int i = n; i <= (m + n - 2); i++)
        {
            result *= (ulong)i;
            result /= (ulong)(i - n + 1);
        }
        return (int)result;
    }
}


/*
    Time: O(N) where N = m + n
    Space: O(1)
*/
public class Solution2
{
    public int UniquePaths(int m, int n)
    {
        double result = 1;
        for (int i = 2; i <= (m + n - 2); i++) {
            result *= i;
            
            if(i <= n - 1)
                result /= i;
                
            if(i <= m - 1)
                result /= i;
        }
        return (int)Math.Round(result);
    }
}

/*
    Time: O(log n) because of calculating factorial
    Space: O(1)
*/
public class Solution1
{
    // inspired by athdon at twitch
    // explanation here: https://leetcode.com/problems/unique-paths/discuss/637666/Python-Math-with-explanation
    // todo: avoid ulong overflowing in csharp
    public int UniquePaths(int m, int n)
    {
        var result = Factorial(n + m - 2) / (Factorial(n - 1)  *  Factorial(m - 1));
        return  (int) result;
    }

    private static ulong Factorial(int n)
    {
        ulong result = 1;
        for(var i = 1; i <= n; i++)
        {
            result *= (ulong)i;
        }
        return result;
    }
}

[Test]
[TestCase(3, 7, 28)]
[TestCase(3, 2, 3)]
[TestCase(3, 3, 6)]
[TestCase(5, 7, 210)]
[TestCase(10, 10, 48620)]
[TestCase(23, 12, 193536720)] // actual is 0 because of ulong overflow
public void SolutionTests(int m, int n, int expected)
{
    var actual = new Solution().UniquePaths(m, n);
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