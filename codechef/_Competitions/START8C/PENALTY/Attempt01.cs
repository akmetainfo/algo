using System;
using System.Linq;

/*
    PenaltyShots(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }).Dump(); // 0
    PenaltyShots(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }).Dump(); // 2
    PenaltyShots(new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 }).Dump(); // 1
    PenaltyShots(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 }).Dump(); // 1
*/

// https://codeforces.com/contest/1559/problem/A
public class Test
{
    public static void Main()
    {
        var firstLine = Console.ReadLine();
        var testsCount = int.Parse(firstLine);

        for (int i = 1; i <= testsCount; i++)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var currentResult = PenaltyShots(nums);
            Console.WriteLine(currentResult);
        }
    }

    public static int PenaltyShots(int[] nums)
    {
        var sum1 = 0;
        var sum2 = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (i % 2 == 0)
                sum1 += nums[i];
            else
                sum2 += nums[i];
        }

        if (sum1 > sum2)
            return 1;

        if (sum1 < sum2)
            return 2;

        return 0;
    }
}