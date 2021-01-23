<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1295. Find Numbers with Even Number of Digits
// https://leetcode.com/problems/find-numbers-with-even-number-of-digits/

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution
{
    public int FindNumbers(int[] nums)
    {
        var result = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            if(DigitsCount(nums[i]) % 2 == 0)
            {
                result++;
            }
        }
        
        return result;
    }
    
    private static int DigitsCount(int num)
    {
        int count = 0;

        while (num > 0)
        {
            num /= 10;
            count++;
        }
        
        return count;
    }
}

[Test]
[TestCase(new int[] { 12, 345, 2, 6, 7896 }, 2)]
[TestCase(new int[] { 555, 901, 482, 1771 }, 1)]
[TestCase(new int[] { 1 }, 0)]
[TestCase(new int[] { 11 }, 1)]
[TestCase(new int[] { 1, 2, 3 }, 0)]
[TestCase(new int[] { 11, 22, 33 }, 3)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().FindNumbers(nums);
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