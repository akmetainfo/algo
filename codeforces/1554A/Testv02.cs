using System;
using System.Linq;

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

    private static long TotalMax(int[] nums)
    {
        var max = (long)nums[0] * (long)nums[1];

        var maxArr = FillMaxArr(nums);
        var minArr = FillMinArr(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                //$"i={i} j={j}".Dump();
                //var  localMax = FindMax(nums, i, j);
                //var  localMin = FindMin(nums, i, j);
                var localMax = FindMax1(maxArr, i, j);
                var localMin = FindMin1(minArr, i, j);
                var curMax = (long)localMax * (long)localMin;
                //$"curMax={curMax} => {localMax} * {localMin}".Dump();
                if (curMax > max)
                    max = curMax;
            }
        }
        return max;
    }

    //private static int FindMax(int[] nums, int start, int finish)
    //{
    //    var a = nums.Skip(start).Take(finish - start + 1);
    //    //a.Dump();
    //    return a.Max();
    //}

    //private static int FindMin(int[] nums, int start, int finish)
    //{
    //    var a = nums.Skip(start).Take(finish - start + 1);
    //    return a.Min();
    //}


    private static int[] FillMaxArr(int[] nums)
    {
        var result = new int[nums.Length - 1];

        result[0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            result[i - 1] = Math.Max(nums[i - 1], nums[i]);
        }

        return result;
    }

    private static int[] FillMinArr(int[] nums)
    {
        var result = new int[nums.Length - 1];

        result[0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            result[i - 1] = Math.Min(nums[i - 1], nums[i]);
        }

        return result;
    }

    private static int FindMax1(int[] nums, int start, int finish)
    {
        var result = nums[start];
        for (int i = start; i < finish; i++)
        {
            if (nums[i] > result)
                result = nums[i];
        }
        return result;
    }

    private static int FindMin1(int[] nums, int start, int finish)
    {
        var result = nums[start];
        for (int i = start; i < finish; i++)
        {
            if (nums[i] < result)
                result = nums[i];
        }
        return result;
    }
}