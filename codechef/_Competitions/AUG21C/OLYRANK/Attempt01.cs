using System;
using System.Linq;

/*
OlympicsRanking(10,20,30,0,29,30).Dump(); // 1
OlympicsRanking(0,0,0,0,0,1).Dump(); // 2
OlympicsRanking(1,1,1,0,0,0).Dump(); // 1
*/

// https://www.codechef.com/AUG21C/problems/OLYRANK
public class Test
{
    public static void Main()
    {
        var firstLine = Console.ReadLine();
        var testsCount = int.Parse(firstLine);

        for (int i = 1; i <= testsCount; i++)
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var currentResult = OlympicsRanking(line);
            Console.WriteLine(currentResult.ToString());
        }
    }

    private static int OlympicsRanking(int[] nums)
    {
        return OlympicsRanking(nums[0], nums[1], nums[2], nums[3], nums[4], nums[5]);
    }

    private static int OlympicsRanking(int G1, int S1, int B1, int G2, int S2, int B2)
    {
        var total1 = G1 + S1 + B1;
        var total2 = G2 + S2 + B2;

        if (total1 > total2)
            return 1;

        if (total2 > total1)
            return 2;

        if (G1 > G2)
            return 1;

        if (G2 > G1)
            return 2;

        if (S1 > S2)
            return 1;

        if (S2 > S1)
            return 2;

        if (B1 > B2)
            return 1;

        if (B2 > B1)
            return 2;

        throw new ArgumentOutOfRangeException("unkonsistent data!");
    }
}