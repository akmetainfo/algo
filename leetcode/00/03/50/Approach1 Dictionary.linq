<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 350. Intersection of Two Arrays II
// https://leetcode.com/problems/intersection-of-two-arrays-ii/

/*
    Time: O(N+M) where N is nums1.Length and M is nums2.Length
    Space: O(N)
*/
public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        if(nums1.Length > nums2.Length)
            return Intersect(nums2, nums1);
            
        var dict1 = new Dictionary<int, int>();
        foreach(var num in nums1)
        {
            if(!dict1.ContainsKey(num)) dict1.Add(num, 0);
            dict1[num]++;
        }
        
        var result = new List<int>();
        
        foreach(var num in nums2)
        {
            if(dict1.ContainsKey(num) && dict1[num] > 0)
            {
                result.Add(num);
                dict1[num]--;
            }
        }
        
        return result.ToArray();
    }
}

/*
    Time: O(N+M) where N is nums1.Length and M is nums2.Length
    Space: O(N+M)
*/
public class Solution0
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        if(nums1.Length > nums2.Length)
            return Intersect(nums2, nums1);
            
        var dict1 = new Dictionary<int, int>();
        foreach(var num in nums1)
        {
            if(!dict1.ContainsKey(num)) dict1.Add(num, 0);
            dict1[num]++;
        }
        var dict2 = new Dictionary<int, int>();
        foreach(var num in nums2)
        {
            if(!dict2.ContainsKey(num)) dict2.Add(num, 0);
            dict2[num]++;
        }
        
        var result = new List<int>();
        
        foreach(var pair in dict1)
        {
            if(dict2.ContainsKey(pair.Key))
            {
                var freq = Math.Min(pair.Value, dict2[pair.Key]);
                for(var i = 0; i < freq; i++) result.Add(pair.Key);
            }
        }
        
        return result.ToArray();
    }
}

[Test]
[TestCase(new int[] { 1,2,2,1 }, new int[] { 2, 2 }, new int[] { 2, 2 })]
[TestCase(new int[] { 4,9,5 }, new int[] { 9,4,9,8,4 }, new int[] { 4, 9 })]
public void SolutionTests(int[] nums1, int[] nums2, int[] expected)
{
    var actual = new Solution().Intersect(nums1, nums2);
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