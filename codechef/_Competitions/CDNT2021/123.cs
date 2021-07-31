using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


// https://www.codechef.com/CDNT2021/problems/ACM16
public class Test
{
    public static void Main()
    {
        Console.ReadLine();

        var line1 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        var line2 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

        var currentResult = EqualArray(line1, line2);
        Console.WriteLine(FormatResult(currentResult));
    }

    private static bool EqualArray(long[] nums1, long[] nums2)
    {
        var dict = new Dictionary<long, long>();

        foreach (var num in nums1)
        {
            if (!dict.ContainsKey(num))
                dict.Add(num, 0);

            dict[num]++;
        }

        foreach (var num in nums2)
        {
            if (!dict.ContainsKey(num))
                return false;

            dict[num]--;
        }

        foreach (var pair in dict)
        {
            if (pair.Value != 0)
                return false;
        }

        return true;
    }

    private static string FormatResult(bool result)
    {
        return result ? "1" : "0";
    }
}