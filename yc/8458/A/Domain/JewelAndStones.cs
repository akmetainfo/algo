using System;
using System.Collections.Generic;

public class Solution
{
    static void Main(string[] args)
    {
        string j = Console.ReadLine();
        string s = Console.ReadLine();

        var result = JewelAndStones(j, s);

        Console.WriteLine(result);
    }

    /*
     * 
     * Time: O(N+M) where N = jewels.Length, M = stones.Length
     * Space: O(N) for storing hashset
     * 
     */
    internal static int JewelAndStones(string jewels, string stones)
    {
        var result = 0;
        var jewelSet = new HashSet<char>(jewels);

        foreach (char stone in stones)
        {
            if (jewelSet.Contains(stone))
            {
                ++result;
            }
        }

        return result;
    }
}