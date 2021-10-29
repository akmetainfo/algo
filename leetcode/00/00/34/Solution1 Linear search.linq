<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 34. Find First and Last Position of Element in Sorted Array
// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        var result = new int[] {-1, -1};
        
        var i = 0;
        var j = nums.Length-1;
        while(i<nums.Length)
        {
            if(result[0] == -1 && nums[i] == target)
                result[0] = i;
                
            if(result[1] == -1 && nums[j] == target)
                result[1] = j;
                
            i++;
            j--;
        }
        return result;
    }
}

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution1
{
    public int[] SearchRange(int[] nums, int target)
    {
        var result = new[] {-1, -1};
        
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                if (result[0] == -1)
                {
                    result[0] = i;
                    result[1] = i;
                }
                else
                {
                    result[1] = i;
                }
            }
        }
        
        return result;
    }
}


/*
    Time: O(N)
    Space: O(1)
*/
public class Solution2
{
    public int[] SearchRange(int[] nums, int target)
    {
        var result = new int[] { -1, -1 };
        
        for(var i = 0; i < nums.Length; i++)
            if(nums[i] == target)
            {
                result[0] = i;
                break;
            }
            
        if(result[0] == -1)
            return result;
            
        for(var i = nums.Length - 1; i >= result[0]; i--)
            if(nums[i] == target)
            {
                result[1] = i;
                break;
            }
            
        return result;
    }
}
/*
    Time: O(N)
    Space: O(1)
*/
public class Solution3
{
    public int[] SearchRange(int[] nums, int target)
    {
        bool found = false;
        
        var i = 0;
        while(i < nums.Length)
        {
            if(nums[i] == target)
            {
                found = true;
                break;
            }
            i++;
        }
        
        if(!found)
            return new int[] { -1, -1 };
            
        var j = i;
        while(j < nums.Length)
        {
            if(nums[j] != target)
                break;
            
            j++;
        }
        
        return new int[] {i, j -1 };
    }
}

[Test]
[TestCase(new int[] { 2, 2 }, 3, new int[] { -1, -1 })]
[TestCase(new int[] { 5, 7, 7, 8, 8, 10 }, 8, new int[] { 3, 4 })]
[TestCase(new int[] { 5, 7, 7, 8, 8, 10 }, 6, new int[] { -1, -1 })]
[TestCase(new int[] { }, 0, new int[] { -1, -1 })]
[TestCase(new int[] { 1 }, 1, new int[] { 0, 0 })]
public void SolutionTests(int[] nums, int target, int[] expected)
{
	var actual = new Solution().SearchRange(nums, target);
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