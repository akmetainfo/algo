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

        for (var i = 0; i < p % K; i++)
        {
            result += (N - i) % K == 0 ? (N - i) / K : 1 + (N - i) / K;

            // Or:
            //result += (N - i) % K == 0 ? 0 : 1;
            //result += (N - i) / K;
        }

        for (var j = p % K; j < N; j = j + K)
        {
            result++;

            if (j == p)
                return result;
        }
        throw new Exception("unexpected");
    }
}