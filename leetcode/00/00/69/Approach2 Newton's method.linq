<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 69. Sqrt(x)
// https://leetcode.com/problems/sqrtx/

/*
    Time: O() see links below
    Space: O(1)
    Source: https://www.geeksforgeeks.org/find-root-of-a-number-using-newtons-method/
    
    https://stackoverflow.com/q/5005753/5752652
    https://stackoverflow.com/q/55888265/5752652
*/
public class Solution
{
    public int MySqrt(int x)
    {
        if (x == 0)
            return 0;
        
        double approx = 0.5 * x;
        double betterapprox = 0.0;
        
        while (true)
        {
            betterapprox = 0.5 * (approx + x / approx);
            if (approx - betterapprox < 0.001)
            {
                break;
            }
            approx = betterapprox;
        }
        
        return (int)betterapprox;
    }
}


/*
    Time: O(?)
    Space: O(1)
*/
public class Solution1
{
    public int MySqrt(int x)
    {
        if(x == 0)
            return 0;
            
        double x0 = x;
        double delta = 0.9;
        double x1 = NextAssumption(x0, x);
        while (Math.Abs(x1 - x0) > delta)
        {
            x0 = x1;
            x1 = NextAssumption(x0, x);
        }
        return (int)x1;
    }
    
    private double NextAssumption(double x0, int a)
    {
        return 0.5 * x0 + a / (2 * x0);
    }
}

/*
    Time: O(?)
    Space: O(1)
*/
public class Solution2
{
    public int MySqrt(int x)
    {
        double x0 = x;
        double delta = 0.9;
        while (Math.Abs(x0 * x0 - x) > delta)
        {
            x0 = 0.5 * x0 + x / (2 * x0);
        }
        return (int)x0;
    }
}

[Test]
[TestCase(0, 0)]
[TestCase(2, 1)]
[TestCase(3, 1)]
[TestCase(4, 2)]
[TestCase(8, 2)]
[TestCase(2147302921, 46339)]
[TestCase(2147395599, 46339)]
[TestCase(2147483647, 46340)]
[TestCase(9, 3)]
[TestCase(100, 10)]
public void SolutionTests(int x, int expected)
{
    var actual = new Solution().MySqrt(x);
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