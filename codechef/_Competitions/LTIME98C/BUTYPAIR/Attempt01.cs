using System;
using System.Linq;

// https://www.codechef.com/LTIME98C/problems/BUTYPAIR
public class Test
{
    public static void Main()
    {
        var firstLine = Console.ReadLine();
        var testsCount = int.Parse(firstLine);

        for (int i = 1; i <= testsCount; i++)
        {
            var line1 = Console.ReadLine();
            var N = int.Parse(line1);

            var line2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var currentResult = BeautifulPairs(line2);
            Console.WriteLine(currentResult);
        }
    }

    private static int BeautifulPairs(int[] nums)
    {
        var result = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < nums.Length; j++)
            {
                if (i == j)
                    continue;
                //$"{i} {j}".Dump();
                //$"{nums[i]} {nums[j]}".Dump();
                if (nums[i] > nums[j])
                    result += 2;
            }
        }
        return result;
    }
}