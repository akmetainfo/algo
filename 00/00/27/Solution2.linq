<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 27. Remove Element
// https://leetcode.com/problems/remove-element/

/*
    Time: O(n) Both i and n traverse at most n steps. In this approach, the number of assignment operations is equal to the number of elements to remove. So it is more efficient if elements to remove are rare.
    Space: O(1)
*/
public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        int i = 0;
        int n = nums.Length;
        while (i < n)
        {
            if (nums[i] == val)
            {
                nums[i] = nums[n - 1];
                // reduce array size by one
                n--;
            }
            else
            {
                i++;
            }
        }
        return n;
    }
}

[Test]
[TestCase(new int[] { 3, 2, 2, 3 }, 3, new int[] { 2, 2 }, 2)]
[TestCase(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, new int[] { 0, 1, 4, 0, 3 }, 5)]
public void SolutionTests(int[] nums, int val, int[] expectedArr, int expectedResult)
{
    var result = new Solution().RemoveElement(nums, val);
    Assert.That(result, Is.EqualTo(expectedResult));
    Assert.That(nums.Take(expectedResult), Is.EquivalentTo(expectedArr));
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