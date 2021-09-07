<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1608. Special Array With X Elements Greater Than or Equal X
// https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/

/*
    Time: O(N^2)
    Space: O(1)
*/
public class Solution
{
    public int SpecialArray(int[] nums)
    {
        for(var x = nums.Length; x >= 0; x--)
        {
            var count = 0;
            for(var i = 0; i < nums.Length; i++)
                if(nums[i] >= x)
                    count++;
                    
            if(x == count)
                return count;
        }
        
        return -1;
    }
}

/*
    Time: O(N^2)
    Space: O(1)
*/
public class Solution1
{
    public int SpecialArray(int[] nums)
    {
        for(var x = nums.Length; x >= 0; x--)
        {
            var count = 0;
            for(var i = 0; i < nums.Length; i++)
                if(nums[i] >= x)
                    count++;
                    
            if(x == count)
                return count;
        }
        
        return -1;
    }
}

[Test]
[TestCase(new int[] { 3, 5 }, 2)]
[TestCase(new int[] { 0, 0 }, -1)]
[TestCase(new int[] { 0,4,3,0,4 }, 3)]
[TestCase(new int[] { 3,6,7,7,0 }, -1)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().SpecialArray(nums);
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