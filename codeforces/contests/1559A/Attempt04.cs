using System;
using System.Linq;

/*
    MochaAndMath(2, new int[] { 1, 2 }).Dump(); // 0
    MochaAndMath(3, new int[] { 1, 1, 3 }).Dump(); // 1
    MochaAndMath(4, new int[] { 3, 11, 3, 7 }).Dump(); // 3
    MochaAndMath(5, new int[] { 11, 7, 15, 3, 7 }).Dump(); // 3
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
            var n = int.Parse(Console.ReadLine());

            var line = Console.ReadLine().Split(' ');
            var nums = new int[n];
            for (var a = 0; a < n; a++)
            {
                nums[a] = int.Parse(line[a]);
            }

            var currentResult = MochaAndMath(n, nums);
            Console.WriteLine(currentResult);
        }
    }

    public static int MochaAndMath(int n, int[] nums)
    {
        var result = nums[0];
        //foreach (var num in nums)
        //    if (num > result)
        //        result = num;

        for (var a = 0; a < nums.Length; a++)
        {
            result = result & nums[a];
        }

        return result;
    }
}