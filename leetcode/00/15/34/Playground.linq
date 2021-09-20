<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1534. Count Good Triplets
// https://leetcode.com/problems/count-good-triplets/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        throw new NotImplementedException();
    }
}

// bruteforce
public class Solution1
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        var result = 0;
        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = i + 1; j < arr.Length; j++)
            {
                for (var k = j + 1; k < arr.Length; k++)
                {
                    if (Math.Abs(arr[i] - arr[j]) <= a && Math.Abs(arr[j] - arr[k]) <= b && Math.Abs(arr[i] - arr[k]) <= c)
                        result++;
                }
            }
        }
        return result;
    }
}

public class Solution2
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        int result = 0, length = arr.Length;

        for (int i = 0; i < length; i++)
            for (int j = i + 1; j < length; j++)
            {
                if (Math.Abs(arr[i] - arr[j]) > a)
                    continue;
                for (int k = j + 1; k < length; k++)
                    if (Math.Abs(arr[j] - arr[k]) <= b
                       && Math.Abs(arr[i] - arr[k]) <= c)
                        result++;
            }

        return result;
    }
}

// An improved brute force
// https://leetcode.com/problems/count-good-triplets/discuss/1057091/Fast-C-solution-beats-98.35-of-c.-An-improved-brute-force
// Instead of using Math.abs to compare arr[k] with arr[i] and arr[j], for all couples (i,j) calculate the lower and higher bounds of the domain arr[k] should lie in. Then compare arr[k] without using the resource consuming Math.Abs()
public class Solution3
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        int result = 0;
        int mink;
        int maxk;

        for (var i = 0; i < arr.Length - 2; ++i)
            for (var j = i + 1; j + 1 < arr.Length; ++j)
                if (Math.Abs(arr[i] - arr[j]) <= a)
                {
                    mink = Math.Max(arr[i] - c, arr[j] - b);
                    maxk = Math.Min(arr[i] + c, arr[j] + b);
                    for (var k = j + 1; k < arr.Length; ++k)
                        if (arr[k] >= mink && arr[k] <= maxk)
                            ++result;
                }

        return result;
    }
}

[Test]
[TestCase(new int[] { 3, 0, 1, 1, 9, 7 }, 7, 2, 3, 4)]
[TestCase(new int[] { 1, 1, 2, 2, 3 }, 0, 0, 1, 0)]
public void SolutionTests(int[] nums, int a, int b, int c, int expected)
{
    var actual = new Solution3().CountGoodTriplets(nums, a, b, c);
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