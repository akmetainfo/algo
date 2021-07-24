<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 88. Merge Sorted Array
// https://leetcode.com/problems/merge-sorted-array/

/*
    Time: O(m + n)
    Space: O(1)
*/
public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var i = m - 1;
        var j = n - 1;
        var index = m + n - 1; // don't use nums1.Length - 1 becouse edge cases when more zero space than m + n

        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[index] = nums1[i];
                i--;
            }
            else
            {
                nums1[index] = nums2[j];
                j--;
            }

            index--;
        }

        // No need to handle i >= 0 case. If it's the case, the remaining numbers are already in nums1.
        while (j >= 0)
        {
            nums1[index] = nums2[j];
            index--;
            j--;
        }
    }
}


/*
    Time: O(m + n)
    Space: O(1)
*/
public class Solution1
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var i = m - 1;
        var j = n - 1;
        var index = m + n - 1; // don't use nums1.Length - 1 becouse edge cases when more zero space than m + n

        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
                nums1[index--] = nums1[i--];
            else
                nums1[index--] = nums2[j--];
        }

        // No need to handle i >= 0 case. If it's the case, the remaining numbers are already in nums1.
        while (j >= 0)
        {
            nums1[index--] = nums2[j--];
        }
    }
}

[Test]
[TestCase(new int[] { 0, 0, 0, 0, 0 }, 0, new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4, 5 })]
[TestCase(new int[] { 0 }, 0, new int[] { 1 }, 1, new int[] { 1 })]
[TestCase(new int[] { 1, 101, 0 }, 2, new int[] { }, 0, new int[] { 1, 101, 0 })]
[TestCase(new int[] { 101, 102, 103, 0 }, 3, new int[] { 1 }, 1, new int[] { 1, 101, 102, 103 })]
[TestCase(new int[] { 1, 101, 102, 103, 0 }, 4, new int[] { 1 }, 1, new int[] { 1, 1, 101, 102, 103 })]
[TestCase(new int[] { 101, 102, 103, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 2, 5, 6, 101, 102, 103 })]
[TestCase(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 102, 105, 106 }, 3, new int[] { 1, 2, 3, 102, 105, 106 })]
[TestCase(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 })]
public void SolutionTests(int[] nums1, int m, int[] nums2, int n, int[] expected)
{
    new Solution().Merge(nums1, m, nums2, n);
    Assert.That(nums1, Is.EqualTo(expected));
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