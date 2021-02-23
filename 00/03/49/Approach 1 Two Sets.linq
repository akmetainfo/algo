<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 349. Intersection of Two Arrays
// https://leetcode.com/problems/intersection-of-two-arrays/

/*
    Time: O(n + m)  where n and m are arrays' lengths.
    Space: O(n + m) in the worst case when all elements in the arrays are different. 
*/
public class Solution
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var set = new HashSet<int>(nums1);
        var result = new HashSet<int>();
        
        foreach (var num in nums2)
        {
            if (set.Remove(num))
                result.Add(num);
        }
                
        return result.ToArray();
    }
}

public class Solution1
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var set1 = new HashSet<int>(nums1);

        var result = new HashSet<int>();

        foreach (var item in nums2)
        {
            if (set1.Contains(item))
                result.Add(item);
        }

        return result.ToArray();
    }
}

[Test]
[TestCase(new[] { 1, 2, 2, 1 }, new[] { 2, 2 }, new[] { 2 })]
[TestCase(new[] { 4, 9, 5 }, new[] { 9, 4, 9, 8, 4 }, new[] { 9, 4 })]
[TestCase(new[] { 1, 2, 2, 1 }, new[] { 2, 2 }, new[] { 2 })]
public void SolutionTests(int[] nums1, int[] nums2, int[] expected)
{
    var actual = new Solution().Intersection(nums1, nums2);
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