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
    Space: O(1) because dictionary size depends from constant, not nums.Length
*/
public class Solution1
{
    public int ArrayPairSum(int[] nums)
    {
        var min = nums[0];
        var max = nums[0];
        var map = new Dictionary<int, int>();
        for (int i=0; i<nums.Length; i++)
        {
            if (map.ContainsKey(nums[i]))
            {
                map[nums[i]]++;
            }
            else
            {
                map.Add(nums[i], 1);
                if (nums[i] < min)
                    min = nums[i];
                if (nums[i] > max)
                    max = nums[i];
            }
        }
        
        var sum = 0;
        var carry = false;
        for (int i = min; i<=max; i++)
        {
            int count;
            var found = map.TryGetValue(i, out count);
            if (!found)
                continue;
                
            if (carry)
                count--;
            sum += i * (count / 2);
            carry = (count % 2 != 0);
            if (carry)
                sum += i;
        }
        return sum;        
    }
}

[Test]
[TestCase(new int[] { 1,4,3,2 }, 4)]
[TestCase(new int[] { 6,2,6,5,1,2 }, 9)]
public void SolutionTests(int[] nums, int expected)
{
    var actual = new Solution().ArrayPairSum(nums);
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