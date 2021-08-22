<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1588. Sum of All Odd Length Subarrays
// https://leetcode.com/problems/sum-of-all-odd-length-subarrays/

/*
    Time: O(N)
    Space: O(1)
*/
/*
https://leetcode.com/problems/sum-of-all-odd-length-subarrays/discuss/857063/C-O(n)-solution

Iterate the input array, for each number arr[i], count how many odd-length subarrys have it. The result will be sum of count * arr[i].

Take [1, 4, 2, 5, 3] as an example.

    1 appears in [1], [1, 4, 2], [1, 4, 2, 5, 3], so result should add 3 * 1.
    4 appears in [4], [4, 2, 5], [1, 4, 2], [1, 4, 2, 5, 3], so result should add 4 * 4.
    2 appears in [2], [2, 5, 3], [4, 2, 5], [1, 4, 2], [1, 4, 2, 5, 3], so result should add 5 * 2.
    5 apperas in [5], [2, 5, 3], [4, 2, 5], [1, 4, 2, 5, 3], so result should add 4 * 5
    3 apperas in [3], [2, 5, 3], [1, 4, 2, 5, 3], so the result should add 3 * 3

For number arr[i], there are i numbers on its left side and (n - i - 1) numbers on its right side.

In other words, beside arr[i], we choose 0, 1, ..., i numbers on the left side and choose 0, 1,..., (n - i - 1) numbers on the right side to form an array that has arr[i].
There will be (i + 1) * (n - i) arrays will have arr[i].
So the number of odd-length array will be [(i + 1) * (n - i) + 1] / 2.
*/
public class Solution
{
    public int SumOddLengthSubarrays(int[] arr)
    {
        var result = 0;
        
        for(int i = 0; i < arr.Length; i++)
        {
            int left = i + 1;
            int right = arr.Length - i;
            
            result += (left * right + 1) / 2 * arr[i];
        }
        
        return result;
    }
}

[Test]
[TestCase(new int[] { 1,4,2,5,3 }, 58)]
[TestCase(new int[] { 1,2 }, 3)]
[TestCase(new int[] { 10,11,12 }, 66)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().SumOddLengthSubarrays(nums);
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