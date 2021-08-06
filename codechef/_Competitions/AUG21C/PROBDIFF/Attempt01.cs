using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

/*
ProblemDifficulties(new[] {1,4,3,2}).Dump(); // 2
ProblemDifficulties(new[] {4,5,5,5}).Dump(); // 1
ProblemDifficulties(new[] {2,2,2,2}).Dump(); // 0
*/

// https://www.codechef.com/AUG21C/problems/PROBDIFF
public class Test
{
    public static void Main()
    {
        var firstLine = Console.ReadLine();
        var testsCount = int.Parse(firstLine);

        for (int i = 1; i <= testsCount; i++)
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var currentResult = ProblemDifficulties(line);
            Console.WriteLine(currentResult.ToString());
        }
    }

    private static int ProblemDifficulties(int[] d)
    {
        var freq = new Dictionary<int, int>();

        foreach (var num in d)
        {
            if (!freq.ContainsKey(num))
                freq.Add(num, 0);

            freq[num]++;
        }

        if (freq.ContainsValue(d.Length))
            return 0;

        if (freq.ContainsValue(d.Length - 1))
            return 1;

        return 2;
    }
}