<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1608. Special Array With X Elements Greater Than or Equal X
// https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/

/*
    Time: O(n log n) because of sorting
    Space: O(1)
*/
public class Solution
{
    public int SpecialArray(int[] nums)
    {
        Array.Sort(nums);

        var result = 0; // here is nums.Min() which is always non-negative by problem's description

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            if (nums[i] == result)
                return -1;
            if (nums[i] < result)
                return result;
            result++;
        }

        return result;
    }
}

/*
    Time: O(n log n) because binary search costs O(log n) and within loop we calculate target costs O(N)
    Space: O(1)
*/
public class Solution4
{
    public int SpecialArray(int[] nums)
    {
        var left = 0;
        var right = nums.Length;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var target = nums.Count(x => x >= mid);

            if (mid == target)
                return mid;

            if (mid < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}

/*
    Time: O(N^2)
    Space: O(N)
*/
public class Solution3
{
    public int SpecialArray(int[] nums)
    {
        var freq = new int[nums.Length + 1];

        for (var i = 0; i <= nums.Length; i++)
        {
            for (var j = 0; j < nums.Length; j++)
                if (nums[j] >= i)
                    freq[i]++;
        }

        for (var i = nums.Length; i >= 0; i--)
        {
            if (i == freq[i])
                return i;
        }

        return -1;
    }
}

/*
    Time: O(N^2)
    Space: O(1)
*/
public class Solution2
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