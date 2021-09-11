<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1313. Decompress Run-Length Encoded List
// https://leetcode.com/problems/decompress-run-length-encoded-list/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public int[] DecompressRLElist(int[] nums)
    {
        var size = 0;
        for(var i = 0; i < nums.Length; i+=2)
            size += nums[i];
            
        var result = new int[size];
        var pos = 0;
        
        for(var i = 0; i < nums.Length; i+=2)
        {
            var freq = nums[i];
            var num = nums[i+1];
            
            for(var j = 0; j < freq; j++)
                result[pos + j] = num;
                
            pos += freq;
        }
        
        return result.ToArray();
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution2
{
    public int[] DecompressRLElist(int[] nums)
    {
        var result = new List<int>();
        
        for(var i = 0; i < nums.Length; i+=2)
        {
            var freq = nums[i];
            var num = nums[i+1];
            
            result.AddRange(Enumerable.Repeat(num, freq));
        }
        
        return result.ToArray();
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1
{
    public int[] DecompressRLElist(int[] nums)
    {
        var result = new List<int>();
        
        for(var i = 0; i < nums.Length; i+=2)
        {
            var freq = nums[i];
            var num = nums[i+1];
            
            for(var j = 0; j < freq; j++)
            {
                result.Add(num);
            }
        }
        
        return result.ToArray();
    }
}

[Test]
[TestCase(new int[] { 1,2,3,4 }, new int[] { 2,4,4,4 })]
[TestCase(new int[] { 1,1,2,3 }, new int[] { 1,3,3 })]
public void SolutionTests(int[] nums, int[] expected)
{
    var actual = new Solution().DecompressRLElist(nums);
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