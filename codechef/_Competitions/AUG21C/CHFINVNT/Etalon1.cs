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

        for (var i = 0; i < K; i++)
        {
            for (var j = i; j < N; j = j + K)
            {
                //$"i={i} j={j}".Dump();

                result++;

                if (j == p && p % K == i)
                    return result;
            }
        }
        throw new Exception("unexpected");
    }
}