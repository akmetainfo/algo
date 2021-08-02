using System;
using System.Linq;

// https://codeforces.com/contest/1549/problem/A 
public class Test
{
    static void Main()
    {
        var firstLine   = Console.ReadLine();
        var testsCount = int.Parse(firstLine);
 
        for (int i = 1; i <= testsCount; i++)
        {
            var line1 = Console.ReadLine();
            var P = int.Parse(line1);
 
            var currentResult = GetAnyBasesForPrime(P);
            Console.WriteLine($"{currentResult.Item1} {currentResult.Item2}");
        }
    }

    /*
        Time: O(n)
        Space: O(1)
    */
    private static (int, int) GetAnyBasesForPrime(int num)
    {
        var storage = new int[10];

        for (var i = 2; i <= num; i++)
        {
            var rest = num % i;
            if (storage[rest] == 0)
            {
                storage[rest] = i;
            }
            else
            {
                return (storage[rest], i);
            }
        }
        throw new Exception("This was unexpected!");
    }
}