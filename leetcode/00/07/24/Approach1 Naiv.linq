<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 724. Find Pivot Index
// https://leetcode.com/problems/find-pivot-index/

/*
    Time: O(N^2)
    Space: O(1)
*/
public class Solution
{
    public int PivotIndex(int[] nums)
    {
		var leftSum = 0;

		for (var i = 0; i < nums.Length; i++)
		{
			leftSum += nums[i];
			
			var rightSum = 0;
			for(var j = i; j < nums.Length; j++)
			{
				rightSum += nums[j];
			}
            
			if(leftSum == rightSum)
				return i;
		}
		
		return -1;
    }
}

/*
    Time: O(N^2)
    Space: O(1)
    
    Time Limit
*/
public class Solution1
{
    public int PivotIndex(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            var sumLeft = nums.Take(i).Sum();
            var sumRight = nums.Skip(i + 1).Sum();
            if (sumLeft == sumRight)
                return i;
        }

        return -1;
    }
}

[Test]
[TestCase(new int[] { 1,7,3,6,5,6 }, 3)]
[TestCase(new int[] { 1,2,3 }, -1)]
[TestCase(new int[] { 2,1,-1 }, 0)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().PivotIndex(nums);
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