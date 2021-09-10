<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1470. Shuffle the Array
// https://leetcode.com/problems/shuffle-the-array/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public int[] Shuffle(int[] nums, int n)
    {
        var result = new int[2 * n];

        var i1 = 0;
        var i2 = n;

        for (int i = 0; i < 2 * n; i++)
            result[i] = i % 2 == 0 ? nums[i1++] : nums[i2++];

        return result;
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1
{
    public int[] Shuffle(int[] nums, int n)
    {
        var result = new int[2 * n];

        for (int i = 0; i < n; i++)
        {
            result[2 * i] = nums[i];
            result[2 * i + 1] = nums[n + i];
        }

        return result;
    }
}


/*
    Time: O(N)
    Space: O(N)
*/
public class Solution2
{
    public int[] Shuffle(int[] nums, int n)
    {
        return nums.Take(n).Zip(nums.Skip(n).Take(n))
                           .Select(x => new int[] { x.Item1, x.Item2 })
                           .SelectMany(x => x)
                           .ToArray();
    }
}


/*
    Time: O(N)
    Space: O(N)
*/
public class Solution3
{
    public int[] Shuffle(int[] nums, int n)
    {
        return nums.Select((x, i) => (i: i < n ? 2 * i : 2 * (i - n) + 1, x))
                   .OrderBy(x => x.i)
                   .Select(x => x.x)
                   .ToArray();
    }
}

[Test]
[TestCase(new int[] { 2, 5, 1, 3, 4, 7 }, 3, new int[] { 2, 3, 5, 4, 1, 7 })]
[TestCase(new int[] { 1, 2, 3, 4, 4, 3, 2, 1 }, 4, new int[] { 1, 4, 2, 3, 3, 2, 4, 1 })]
[TestCase(new int[] { 1, 1, 2, 2 }, 2, new int[] { 1, 2, 1, 2 })]
public void SolutionTests(int[] nums, int n, int[] expected)
{
    var actual = new Solution2().Shuffle(nums, n);
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