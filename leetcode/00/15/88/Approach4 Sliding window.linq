<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1588. Sum of All Odd Length Subarrays
// https://leetcode.com/problems/sum-of-all-odd-length-subarrays/

/*
    Time: O(?) maybe N^3
    Space: O(1)
    
    https://leetcode.com/problems/sum-of-all-odd-length-subarrays/discuss/967629/C-Sliding-Window
*/
public class Solution
{
    public int SumOddLengthSubarrays(int[] arr)
    {
        int oddStart = arr.Length;
        int oddTotal = 0;
        if(arr.Length % 2 == 0) //check to see if the array's length is positive
            oddStart = arr.Length-1; //if it is take the length - 1 to find the odd starting point
			
        for(int i = oddStart; i > 0; i-=2)
        {
            oddTotal+= getTotal(oddStart, arr);
            oddStart-=2;
        }
        return oddTotal;
    }
    
    public int getTotal(int oddValue, int[] arr)
    {
        int head = arr.Length - oddValue;
        int tail = arr.Length-1;
        int total = 0;
        while(head >= 0)
        {
            for(int i = head; i <= tail; i++)
            {
                total += arr[i];
            }
            head--;
            tail--;
        }
        return total; 
    }
}

[Test]
[TestCase(new int[] { 1,4,2,5,3 }, 58)]
[TestCase(new int[] { 1,2 }, 3)]
[TestCase(new int[] { 10,11,12 }, 66)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().SumOddLengthSubarrays(nums);
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