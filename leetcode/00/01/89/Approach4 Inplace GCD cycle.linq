<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 189. Rotate Array
// https://leetcode.com/problems/rotate-array/

/*
    Time: O(N) N = nums.Length * d
    Space: O()
*/
public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        k %= nums.Length;
        
        if (k == 0 || nums.Length < 2)
            return;

        var cycles = GCD(nums.Length, k);
        
        for (int i = 0; i < cycles; i++)
        {
            var prev = nums[i];
            for (int j = 0; j < nums.Length / cycles; j++)
            {
                var idx = (i + (j + 1) * k) % nums.Length;
                (nums[idx], prev) = (prev, nums[idx]);
            }
        }
    }

    private static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}

/*
    Time: O()
    Space: O()
    
https://www.geeksforgeeks.org/array-rotation/
Note: This algo rotates left, not right!
Instead of moving one by one, divide the array in different sets where number of sets is equal to GCD of n and d and move the elements within sets.
*/
public class Solution1
{
    public void Rotate(int[] nums, int d)
    {
        int i, j, k, temp;
        /* To handle if d >= n */
        d = d % nums.Length;
        for (i = 0; i < GCD(d, nums.Length); i++)
        {
            /* move i-th values of blocks */
            temp = nums[i];
            j = i;
            while (true)
            {
                k = j + d;
                if (k >= nums.Length)
                    k = k - nums.Length;
                if (k == i)
                    break;
                nums[j] = nums[k];
                j = k;
            }
            nums[j] = temp;
        }
    }

    private static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}

[Test]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
[TestCase(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 })]
public void SolutionTests(int[] nums, int k, int[] expected)
{
    new Solution().Rotate(nums, k);
    Assert.That(nums, Is.EquivalentTo(expected));
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