<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1920. Build Array from Permutation
// https://leetcode.com/problems/build-array-from-permutation/

/*
    Time: O(N)
    Space: O(1)
    
    You have to transform each array element using a = r + bq formula. where q > r and b is not divisible by q.
    r holds the prev num and bq holds the answer.
*/
public class Solution
{
    public int[] BuildArray(int[] nums)
    {
        int q = nums.Length;

        for (int i = 0; i < q; i++)
        {
            var r = nums[i];
            var b = nums[nums[i]] % q;
            nums[i] = q * b + r;
        }

        for (int i = 0; i < q; i++)
            nums[i] = nums[i] / q;

        return nums;
    }
}
/*
    Afternotes:
    
    https://leetcode.com/problems/build-array-from-permutation/discuss/1315926/Python-O(n)-Time-O(1)-Space-w-Full-Explanation
    
    We must keep nums[i] intact because if, for example, a later position in the array, say j, has a value nums[j] = i, but we've overwrote the value at i (nums[i]) with nums[nums[i]] already, then we're out of luck.

    To accomplish this task, we're going to use the fact that if we have a number of the form a = qb + r, where b and r are not multiples of q and r < q, then we can extract b and r with the following:

        b = a // q (where // is integer division) - we know that qb when divided by q will give us b, however we still would need to get rid of the r // q. From our requirements though, r < q, so r // q will always be 0, thus b = (qb//q) + (r//q) = b + 0 = b
        r = a % q - we know that qb is a multiple of q, thus is divided by it cleanly and we know that r < q, so r is not a multiple of q, therefore the remainder when dividing a = qb + r by q is just r

    We need to find a way to transform every element of nums into the form a = qb + r.

    At every i, nums[nums[i]] is going to be our b and the original value, nums[i] is our r. Now we just need a q that satisfies the r < q, for all the possible r values (all nums[i]). Luckily, we have such a q already, as our array values are indices into the same array. q = len(nums) is always guaranteed to be greater than all nums[i] because each index is always within the bounds of the array, from 0 to len(nums) - 1.    
    
    https://leetcode.com/problems/build-array-from-permutation/discuss/1315480/Java-or-O(1)-Space-O(n)-Time
    
*/



[Test]
[TestCase(new int[] { 0, 2, 1, 5, 3, 4 }, new int[] { 0, 1, 2, 4, 5, 3 })]
[TestCase(new int[] { 5, 0, 1, 2, 3, 4 }, new int[] { 4, 5, 0, 1, 2, 3 })]
public void SolutionTests(int[] nums, int[] expected)
{
    var actual = new Solution().BuildArray(nums);
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