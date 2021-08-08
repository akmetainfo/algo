using System;
using System.Linq;

/*
    SpecialTriplets(3).Dump(); // 3
    SpecialTriplets(4).Dump(); // 6
    SpecialTriplets(5).Dump(); // 9
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
            var line = Console.ReadLine();
            var n = int.Parse(line);

            var currentResult = SpecialTriplets(n);
            Console.WriteLine(currentResult.ToString());
        }
    }

    private static int SpecialTriplets(int n)
    {
        var result = 0;

        for (var c = 1; c <= n; c++)
        {
            for (var b = c; b <= n; b = b + c)
            {
                for (var a = 1; a <= n;)
                {
                    if (a % b == c)
                    {
                        //$"{a}, {b}, {c}".Dump();
                        result++;
                        a = a + b;
                    }
                    else
                    {
                        a++;
                    }
                }
            }
        }

        return result;
    }
}