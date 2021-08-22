<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 561. Array Partition I
// https://leetcode.com/problems/array-partition-i/


/*
    Time: O(n)
    Space: O(1), because hist length depends from constant, not from nums.Length
*/
public class Solution
{
    public int ArrayPairSum(int[] nums)
    {
        var min = nums.Min();
        var max = nums.Max();

        var hist = new short[Math.Abs(min) + 1 + max];
        
        foreach (var num in nums)
            hist[num - min]++;

        var result = 0;
        var firstInPair = true;
        for (int i = 0; i < hist.Length; i++)
        {
            while (hist[i] > 0)
            {
                if (firstInPair)
                    result += i + min;

                firstInPair = !firstInPair;
                hist[i]--;
            }
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
    public int ArrayPairSum(int[] nums)
    {
        var min = nums.Min();
        var max = nums.Max();
        
        var hist = new int[Math.Abs(min) + 1 + max];
        foreach(var num in nums)
            hist[num - min]++;
            
        var result = 0;
        var firstInPair = true;
        
        for(var i = 0; i < hist.Length; i++)
        {
            var count = hist[i];
            
            if(count == 0)
                continue;
            
            result += firstInPair
                ? (i + min) * ( (count + 1) / 2)
                : (i + min) * ( count / 2);
                
            firstInPair = firstInPair == (count % 2 == 0);
        }
        
        return result;
    }
}

[Test]
[TestCase(new int[] { 1,4,3,2 }, 4)]
[TestCase(new int[] { 6,2,6,5,1,2 }, 9)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution1().ArrayPairSum(nums);
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