<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 03 Search second max element

/*
Given array of N integer (N>1) find second max element and its index.

Second max is max after removing FIRST ONE occurence of max element.
E.g. for {3,2,3} answer is 3.

If there's more than one second max return last occurrence.
*/

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution
{
    public int[] SecondMaxElement(int[] nums)
    {
        var max1index = nums[0] >= nums[1] ? 0 : 1;
        var max2index = nums[0] >= nums[1] ? 1 : 0;
        var max1 = nums[max1index];
        var max2 = nums[max2index];
        
        for(var i = 2; i < nums.Length; i++)
        {
            if(nums[i] >= max1)
            {
                max2 = max1;
                max2index = max1index;
                max1 = nums[i];
                max1index = i;
            }
            else if (nums[i] >= max2)
            {
                max2 = nums[i];
                max2index = i;
            }
        }
        
        return new int[] { max2, max2index };
    }
}

[Test]
[TestCase(new int[] { 7, -3 }, new[] { -3, 1 })]
[TestCase(new int[] { 7, 7 }, new[] { 7, 1 })]
[TestCase(new int[] { 7, 8 }, new[] { 7, 0 })]
[TestCase(new int[] { 7, 7, 7 }, new[] { 7, 2 })]
[TestCase(new int[] { 1, -4, 2, 0, 3 }, new[] { 2, 2 })]
public void SolutionTests(int[] nums, int[] expected)
{
    var actual = new Solution().SecondMaxElement(nums);
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