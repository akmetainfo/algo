using System;
using System.Linq;

// https://www.codechef.com/LTIME98C/problems/REDALERT
public class Test
{
    public static void Main()
    {
        var firstLine = Console.ReadLine();
        var testsCount = int.Parse(firstLine);

        for (int i = 1; i <= testsCount; i++)
        {
            var line1 = Console.ReadLine().Split(' ');
            var N = int.Parse(line1[0]);
            var D = int.Parse(line1[1]);
            var H = int.Parse(line1[2]);

            var line2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var currentResult = RedAlert(D, H, line2);
            Console.WriteLine(FormatResult(currentResult));
        }
    }

    private static bool RedAlert(int D, int H, int[] nums)
    {
        var currentLevel = 0;
        foreach(var num in nums)
        {
            if(num > 0)
            {
                currentLevel += num;
                if (currentLevel > H)
                    return true;
            }
            else
            {
                currentLevel -= D;
                if (currentLevel < 0)
                    currentLevel = 0;
            }
        }
        return false;
    }

    private static string FormatResult(bool result)
    {
        return result ? "YES" : "NO";
    }
}