<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 01 Find last occurence

/*
Write a function to search target in nums.
If target exists, then return index of last occurrence. Otherwise, return -1.
*/

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution
{
    public int LastOccurence(int[] nums, int target)
    {
        var result = -1;
        for(var i = 0; i < nums.Length; i++)
        {
            if(nums[i] == target)
                result = i;
        }
        return result;
    }
}

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution1
{
    public int LastOccurence(int[] nums, int target)
    {
        var result = -1;
        for(var i = nums.Length - 1; i >=0; i--)
        {
            if(nums[i] == target)
            {
                result = i;
                break;
            }
        }
        return result;
    }
}

[Test]
[TestCase(new int[] { }, 42, -1)]
[TestCase(new int[] { 7 }, 1, -1)]
[TestCase(new int[] { 7 }, 7, 0)]
[TestCase(new int[] { 7 }, 9, -1)]
[TestCase(new int[] { 1, -4, 2, 0, 2, 3 }, 2, 4)]
public void SolutionTests(int[] nums, int target, int expected)
{
    var actual = new Solution().LastOccurence(nums, target);
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