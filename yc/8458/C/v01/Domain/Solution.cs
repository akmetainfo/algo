using System;
using System.Collections.Generic;

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

        var result = RemoveDuplicates(nums);

        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
    }

    /*
     * 
     * Time: O(N log N) where N is nums.Length
     * Space: O(N)
     * 
     */
    internal static SortedSet<int> RemoveDuplicates(int[] nums)
    {
        return new SortedSet<int>(nums);
    }
}