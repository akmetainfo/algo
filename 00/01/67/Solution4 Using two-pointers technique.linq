<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 167. Two Sum II - Input array is sorted
// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution
{
    /*
    create two pointer, left and right, pointing to first and last element of array
    in the cycle while left is not equals to right
        check if the sum of elements (pointing by left and right) is equals to target.
            if so, exit returning left + 1 and right + 1 position
        else if the sum is greater than target so decrease right pointer
        else if the sum is less than target so increase left pointer
    if we exit from the cycle throw new exception.
    */
    public int[] TwoSum(int[] numbers, int target)
    {
        var left = 0;
        var right = numbers.Length - 1;
        while(left != right)
        {
            var sum = numbers[left] + numbers[right];
            if(sum == target)
                return new int[] { left + 1, right + 1 };
            if(sum > target)
                right--;
            if(sum < target)
                left++;
        }
        throw new ArgumentOutOfRangeException("check the inputs! no solution available!");
    }
}

[Test]
[TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 2 })]
[TestCase(new int[] { 2, 3, 4 }, 6, new int[] { 1, 3 })]
[TestCase(new int[] { -1, 0 }, -1, new int[] { 1, 2 })]
public void SolutionTests(int[] nums, int target, int[] expected)
{
    var actual = new Solution().TwoSum(nums, target);
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