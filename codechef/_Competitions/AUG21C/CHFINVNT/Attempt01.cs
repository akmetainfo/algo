using System;
using System.Linq;

/*
ChefAndBulbInvention(10,5,5).Dump(); // 2
ChefAndBulbInvention(10,6,5).Dump(); // 4
ChefAndBulbInvention(10,4,5).Dump(); // 9
ChefAndBulbInvention(10,8,5).Dump(); // 8
*/

// https://www.codechef.com/AUG21C/problems/CHFINVNT
public class Test
{
    public static void Main()
    {
        var firstLine = Console.ReadLine();
        var testsCount = int.Parse(firstLine);

        for (int i = 1; i <= testsCount; i++)
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var currentResult = ChefAndBulbInvention(line[0], line[1], line[2]);
            Console.WriteLine(currentResult.ToString());
        }
    }

    private static int ChefAndBulbInvention(int N, int p, int K)
    {
        var result = 0;

        var maxMod = p % K;

        // $"maxMod={maxMod}".Dump();

        for (var i = 0; i <= maxMod; i++)
        {
            if (i == maxMod)
            {
                result += p / K;
            }
            else
            {
                result += N / K;
            }
        }

        return result + 1;
    }
}