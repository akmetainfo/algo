using System;
using System.Linq;
 
public class Test
{
    static void Main()
    {
        var firstLine   = Console.ReadLine();
        var testsCount = int.Parse(firstLine);
 
        for (int i = 1; i <= testsCount; i++)
        {
            var line1 = Console.ReadLine();
            var count = int.Parse(line1);
            var line2 = Console.ReadLine();
            var nums  = line2.Split(' ').Select(int.Parse).ToArray();
 
            var currentResult = TotalMax(nums);
            Console.WriteLine(currentResult);
        }
    }
 
    private static long TotalMax(int[] nums)
    {
        var max = (long)nums[0] * (long)nums[1];
 
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                //$"i={i} j={j}".Dump();
                var  localMax = FindMax(nums, i, j);
                var  localMin = FindMin(nums, i, j);
                var curMax   = (long)localMax * (long)localMin;
                //$"curMax={curMax} => {localMax} * {localMin}".Dump();
                if (curMax > max)
                    max = curMax;
            }
        }
        return max;
    }
 
    private static int FindMax(int[] nums, int start, int finish)
    {
        var a = nums.Skip(start).Take(finish - start + 1);
        //a.Dump();
        return a.Max();
    }
 
    private static int FindMin(int[] nums, int start, int finish)
    {
        var a = nums.Skip(start).Take(finish - start + 1);
        return a.Min();
    }
}