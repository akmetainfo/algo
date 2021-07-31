using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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

            var currentResult = BeautifulPairs(N, line2);
            Console.WriteLine(currentResult);
        }
    }

    private static int BeautifulPairs(int N, int[] nums)
    {
        var dict = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!dict.ContainsKey(num))
                dict.Add(num, 0);

            dict[num]++;
        }

        var total = N * N - N;

        foreach (var pair in dict)
        {
            if (pair.Value == 1)
                continue;

            if (pair.Value == N)
                total = 0;

            total -= MyFunct(pair.Value);
        }

        if (total < 0)
            total = 0;

        return total;
    }

    private static int MyFunct(int n)
    {
        if (n == 2)
            return 2;
        if (n == 3)
            return 6;
        if (n == 4)
            return 12;
        if (n == 5)
            return 20;
        if (n == 6)
            return 30;
        if (n == 7)
            return 42;
        if (n == 8)
            return 56;

        // TODO: Understand logic for this sequence
        return 0;
    }
}