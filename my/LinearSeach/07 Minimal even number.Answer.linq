<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 07 Minimal even number

/*
Given non-empty array of integer find minimal even number.
If there is no even number return -1.
*/

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution
{
    public int MinEventNumber(int[] nums)
    {
        var found = false;
        var min = -1;
        for(var i = 0; i < nums.Length; i++)
        {
            if(found)
            {
                if(nums[i] % 2 == 0 && nums[i] < min)
                {
                    min = nums[i];
                }
            }
            else
            {
                if(nums[i] % 2 == 0)
                {
                    found = true;
                    min = nums[i];
                }
            }
        }
        return min;
    }
}


/*
    Time: O(n)
    Space: O(1)
*/
public class Solution1
{
    public int MinEventNumber(int[] nums)
    {
        var found = false;
        var min = -1;
        for(var i = 0; i < nums.Length; i++)
        {
            if(nums[i] % 2 != 0)
                continue;
                
            if(found && nums[i] < min)
                min = nums[i];
                
            if(!found)
            {
                found = true;
                min = nums[i];
            }
        }
        return min;
    }
}

[Test]
[TestCase(new int[] { 7 }, -1)]
[TestCase(new int[] { 8 }, 8)]
[TestCase(new int[] { 5, 7 }, -1)]
[TestCase(new int[] { 7, 8 }, 8)]
[TestCase(new int[] { 6, 8 }, 6)]
[TestCase(new int[] { 6, 7, 8 }, 6)]
[TestCase(new int[] { 7, 8, 6 }, 6)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution1().MinEventNumber(nums);
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