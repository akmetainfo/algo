<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 561. Array Partition I
// https://leetcode.com/problems/array-partition-i/

/*
    Time: O(n log n) because of using sorting
    Space: O(1)
*/
/*
Proof：
If the array only has two elements, return the minimum。
Else, there are any two groups (ap, bp)，(aq, bq) that satisfies ap <= bp and aq <= bq.
Now we assume that aq < bp, apparently (ap, aq) (bp, bq) are more appropriate than (ap, bp) (aq, bq) because ap+bp > ap + aq.
So we conclude that ap <= bp <= aq <= bq, which requires that the array is in order.
At last we get the elements indexed even and calculate the summary of them.
*/
public class Solution
{
    public int ArrayPairSum(int[] nums)
    {
        Array.Sort(nums);

        var result = 0;
        
        for (var i = 0; i < nums.Length; i += 2)
            result += nums[i];

        return result;
    }
}

[Test]
[TestCase(new int[] { 1,4,3,2 }, 4)]
[TestCase(new int[] { 6,2,6,5,1,2 }, 9)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().ArrayPairSum(nums);
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