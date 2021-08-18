<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 724. Find Pivot Index
// https://leetcode.com/problems/find-pivot-index/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution
{
    public int PivotIndex(int[] nums)
    {
        var sum = 0;
        var leftSum = 0;
        
        for(var i = 0; i < nums.Length; i++)
            sum += nums[i];
        
        for(var i = 0; i < nums.Length; i++)
        {
            leftSum += nums[i];
            
            var rightSum = sum - leftSum + nums[i];
            
            if(leftSum == rightSum)
                return i;
        }
        
        return -1;
    }
}


/*
    Time: O(N)
    Space: O(1)
*/
public class Solution1
{
    public int PivotIndex(int[] nums)
    {
        var sum = 0;
        var leftSum = 0;
        
        for(var i = 0; i < nums.Length; i++)
            sum += nums[i];
        
        for(var i = 0; i < nums.Length; i++)
        {
            var rightSum = sum - leftSum - nums[i];
            
            if(leftSum == rightSum)
                return i;
            
            leftSum += nums[i];
        }
        
        return -1;
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution2
{
    public int PivotIndex(int[] nums)
    {
        var pref = new int[nums.Length + 1];
        
        var sum = 0;
        
        for(var i = 0; i < nums.Length; i++)
        {
            pref[i+1] = pref[i] + nums[i];
            sum += nums[i];
        }
        
        var leftSum = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            var rightSum = sum - pref[i + 1];
            
            if(leftSum == rightSum)
                return i;
            
            leftSum += nums[i];
        }
        
        return -1;
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution3
{
    public int PivotIndex(int[] nums)
    {
        var pref = new int[nums.Length + 1];
        
        for(var i = 0; i < nums.Length; i++)
        {
            pref[i+1] = pref[i] + nums[i];
        }
        
        for(var i = 0; i < nums.Length; i++)
        {
            var leftSum = pref[i] - pref[0];
            var rightSum = pref[nums.Length] - pref[i + 1];
            
            if(leftSum == rightSum)
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