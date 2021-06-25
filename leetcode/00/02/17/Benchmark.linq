<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
</Query>

#LINQPad optimize+
void Main()
{
    var summary = BenchmarkRunner.Run<Solutions>();
}

// Define other methods and classes here

public class Solutions
{
    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public void Approach1(int[] nums, bool expected)
    {
        var actual = new SolutionApproach1().ContainsDuplicate(nums);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public void Approach2(int[] nums, bool expected)
    {
        var actual = new SolutionApproach1().ContainsDuplicate(nums);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public void Approach3(int[] nums, bool expected)
    {
        var actual = new SolutionApproach1().ContainsDuplicate(nums);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public void Solution1(int[] nums, bool expected)
    {
        var actual = new SolutionApproach1().ContainsDuplicate(nums);
    }

    public IEnumerable<object[]> Data()
    {
        yield return new object[] { new int[] { 1, 2, 3, 1 }, true };
        yield return new object[] { new int[] { 1, 2, 3, 4 }, false };
        yield return new object[] { new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true };
    }
}

public class SolutionApproach1
{
    public bool ContainsDuplicate(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                    return true;
            }
        }
        return false;
    }
}

public class SolutionApproach2
{
    public bool ContainsDuplicate(int[] nums)
    {
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == nums[i + 1])
                return true;
        }
        return false;
    }
}

public class SolutionApproach3
{
    public bool ContainsDuplicate(int[] nums)
    {
        var hs = new Hashtable(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            if (hs.Contains(nums[i]))
                return true;

            hs.Add(nums[i], null);
        }
        return false;
    }
}

public class Solution1
{
    public bool ContainsDuplicate(int[] nums)
    {
        var hs = new HashSet<int>(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            if (hs.Contains(nums[i]))
                return true;

            hs.Add(nums[i]);
        }
        return false;
    }
}