<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1588. Sum of All Odd Length Subarrays
// https://leetcode.com/problems/sum-of-all-odd-length-subarrays/

/*
    Time: O(N^3)
    Space: O(1)
*/
public class Solution
{
    public int SumOddLengthSubarrays(int[] arr)
    {
        var result = 0;
        
        for(var i = 1; i <= arr.Length; i += 2)
            for(var j = 0; j <= arr.Length - i; j++)
                for(var m = 0; m < i; m++)
                    result += arr[j+m];
        
        return result;
    }
}

/*
    Time: O(N^3)
    Space: O(1)
*/
public class Solution1
{
    public int SumOddLengthSubarrays(int[] arr)
    {
        var result = 0;
        
        for(var i = 1; i <= arr.Length; i += 2)
        {
            for(var j = 0; j < arr.Length; j++)
            {
                if(j + i > arr.Length)
                    continue;
                    
                for(var m = 0; m < i; m++)
                    result += arr[j+m];
            }
        }
        
        return result;
    }
}


/*
    Time: O(N^3)
    Space: O(1)
    
    Same as above, just debug version
*/
public class Solution2
{
    public int SumOddLengthSubarrays(int[] arr)
    {
        var result = 0;
        
        for(var i = 1; i <= arr.Length; i += 2)
        {
            $"===={i}====".Dump();
            for(var j = 0; j < arr.Length; j++)
            {
                //  |---------| Length = 5
                //  |0 1 2 3 4|
                //  |1 4 2 5 3| 
                //  |    J    | i = 3
                if(j + i > arr.Length)
                    continue;
                var temp = new List<int>();
                for(var m = 0; m < i; m++)
                {
                    result += arr[j+m];
                    temp.Add(arr[j+m]);
                }
                string.Join(", ", temp).Dump();
            }
        }
        
        return result;
    }
}

[Test]
[TestCase(new int[] { 1,4,2,5,3 }, 58)]
[TestCase(new int[] { 1,2 }, 3)]
[TestCase(new int[] { 10,11,12 }, 66)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution1().SumOddLengthSubarrays(nums);
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