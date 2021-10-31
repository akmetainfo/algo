using System;

public class Solution
{
    static void Main(string[] args)
    {
        string N = Console.ReadLine();
        int n = int.Parse(N);
        var nums = new int[n];
        for (var i = 0; i < n; i++)
        {
            string numValue = Console.ReadLine();
            int num = int.Parse(numValue);
            nums[i] = num;
        }

        var result = LongestSeries(nums);

        Console.WriteLine(result);
    }

    /*
     * 
     * Time: O(N) where N = nums.Length
     * Space: O(1)
     * 
     */
    internal static int LongestSeries(int[] nums, int target = 1)
    {
        var result = 0;
        if (nums.Length == 0) return result;
        var serieLength = 0;
        foreach(var num in nums)
        {
            if(num == target)
            {
                serieLength++;
                result = Math.Max(result, serieLength);
            }
            else
            {
                serieLength = 0;
            }
        }
        return result;
    }
}