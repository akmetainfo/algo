<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1. Two Sum
// https://leetcode.com/problems/two-sum/

/*
    Time: O(n) We traverse the list containing nnn elements exactly twice. Since the hash table reduces the look up time to O(1), the time complexity is O(n).
    Space: O(n) The extra space required depends on the number of items stored in the hash table, which stores exactly n elements. 
*/
public class Solution
{
    // Maybe its not the full equivalent for java style solution because
    // C# Dictionaries and Java Hashmaps behave differently:
    // C# doesn't allow for attempt to add duplicate keys, whereas Java does
    // https://leetcode.com/problems/two-sum/discuss/578502/C-O(n)-solution
    // https://docs.oracle.com/javase/8/docs/api/java/util/HashMap.html
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        
        for(var i = 0; i < nums.Length; i++)
        {
            if(!dict.ContainsKey(nums[i]))
                dict.Add(nums[i], i);
        }
        
        for(var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if(dict.ContainsKey(complement) && i != dict[complement])
                return new int[] { dict[complement], i };
        }
        
        throw new Exception();
    }
}

[Test]
[TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
[TestCase(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
[TestCase(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
[TestCase(new int[] { 3, 2, 2, 4 }, 6, new int[] { 1, 3 })]
[TestCase(new int[] { 2, 2, 3, 3 }, 6, new int[] { 2, 3 })]
public void SolutionTests(int[] nums, int target, int[] expected)
{
    var actual = new Solution().TwoSum(nums, target);
    Assert.That(actual, Is.EquivalentTo(expected));
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