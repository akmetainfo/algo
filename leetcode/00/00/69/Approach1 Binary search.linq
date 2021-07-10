<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 69. Sqrt(x)
// https://leetcode.com/problems/sqrtx/

/*
    Time: O(log n)
    Space: O(1)
*/
// classic binary search
public class Solution
{
    public int MySqrt(int x)
    {
        var left = 0;
        var right = x;
        
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            
            if((ulong) mid * (ulong)mid == (ulong)x)
                return mid;
            
            if((ulong) mid * (ulong)mid < (ulong)x)
                left = mid + 1;
            else
                right = mid - 1;
        }
        
        if((ulong)left * (ulong)left >(ulong)x)
            return left - 1;

        return left; // or throw an exception - this is not possble
    }
}


/*
    Time: O(log n)
    Space: O(1)
*/
// classic binary search
public class Solution1
{
    public int MySqrt(int x)
    {
        var left = 0;
        var right = x;
        
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            
            if((ulong) mid * (ulong)mid == (ulong)x)
                return mid;
            
            if((ulong) mid * (ulong)mid < (ulong)x)
                left = mid + 1;
            else
                right = mid - 1;
        }
        
        return left - 1;
    }
}

/*
    Time: O(log n)
    Space: O(1)
*/
// classic leftmost search with exit checks
public class Solution2
{
    public int MySqrt(int x)
    {
        int left = 0;
        int right = x;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if ((ulong)x > (ulong)mid * (ulong)mid)
                left = mid + 1;
            else
                right = mid;
        }

        if((ulong)left * (ulong)left == (ulong)x)
            return left;
            
        return left-1;
    }
}


/*
    Time: O(log n)
    Space: O(1)
*/
// classic rightmost search with exit checks
public class Solution3
{
    public int MySqrt(int x)
    {
        var left = 0;
        var right = x;
        
        while (left < right)
        {
            var mid = 1 + left + (right - left) / 2;
            
            if((long)mid*(long)mid > (long)x)
                right = mid - 1;
            else
                left = mid;
        }

        return left;
    }
}

[Test]
[TestCase(0, 0)]
[TestCase(2, 1)]
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