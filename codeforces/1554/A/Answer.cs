using System;
using System.Linq;

/*
    TotalMax(new int[] {2,4,3}).Dump(); // expected: 12
    TotalMax(new int[] {3,2,3,1}).Dump(); // expected: 6
    TotalMax(new int[] {69, 69}).Dump(); // 4761
    TotalMax(new int[] {719313, 273225, 402638, 473783, 804745, 323328}).Dump(); // 381274500335
*/

public class Test
{
    static void Main()
    {
        var firstLine = Console.ReadLine();
        var testsCount = int.Parse(firstLine);

        for (int i = 1; i <= testsCount; i++)
        {
            var line1 = Console.ReadLine();
            var count = int.Parse(line1);
            var line2 = Console.ReadLine();
            var nums = line2.Split(' ').Select(int.Parse).ToArray();

            var currentResult = TotalMax(nums);
            Console.WriteLine(currentResult);
        }
    }

    // the ans is for every 1 < i < n the maximum value of v[i] * v[i-1]
    private static long TotalMax(int[] nums)
    {
        long max = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            max = Math.Max(max, (long)nums[i] * nums[i-1]);
        }
        return max;
    }
}