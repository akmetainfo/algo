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

            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var currentResult = MochaAndMath(n, nums);
            Console.WriteLine(currentResult);
        }
    }

    public static int MochaAndMath(int n, int[] nums)
    {
        var maxPos = 0;
        var maxVal = nums[maxPos];

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > maxVal)
            {
                maxVal = nums[i];
                maxPos = i;
            }
        }

        var minVal = maxVal;

        for (var i = 0; i <= maxPos; i++)
        {
            for (var j = maxPos; j < nums.Length; j++)
            {
                var mirrorPos = i + j - maxPos;
                var mirrorVal = nums[mirrorPos];
                var curVal = maxVal & mirrorVal;
                //$"{curVal}".Dump();
                if (curVal < minVal)
                    minVal = curVal;
            }
        }

        return minVal;
    }
}