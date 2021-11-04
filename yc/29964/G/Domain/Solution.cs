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

        var result = Bonuses(nums);

        Console.WriteLine(result);
    }

    /*
     * 
     * Time: O(N log N) because of sort
     * Space: O(1) usually no auxilary space required for sorting
     * 
     * [TestCase(new int[] { 4, 2, 3, 3 }, 3000)] why not 4000???
     * we can use counting sort for ratings = new int[4096]
     * 
     */
    internal static int Bonuses(int[] nums, int quant = 500)
    {
        var result = 0;
        if (nums.Length == 0) return result;
        result += quant;
        if (nums.Length == 1) return result;
        Array.Sort(nums);
        var multKoeff = 1;
        var prev = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == prev)
            {
                result += multKoeff * quant;
            }
            else
            {
                multKoeff++;
                result += multKoeff * quant;
                prev = nums[i];
            }
        }
        return result;
    }
}