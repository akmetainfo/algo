using System;
using System.Linq;

// https://www.codechef.com/LTIME98C/problems/CHFSPL
public class Test
{
    public static void Main()
    {
        var firstLine = Console.ReadLine();
        var testsCount = int.Parse(firstLine);

        for (int i = 1; i <= testsCount; i++)
        {
            var nums = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            var currentResult = SumOfMaxAndSecondMax(nums[0], nums[1], nums[2]);
            Console.WriteLine(currentResult);
        }
    }

    private static long SumOfMaxAndSecondMax(long a, long b, long c)
    {
        if (a >= b)
            return a < c ? a + c : a + Math.Max(b, c);

        return b < c ? b + c : b + Math.Max(a, c);
    }
}