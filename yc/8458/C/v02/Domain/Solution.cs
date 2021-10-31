using System;
using System.Collections.Generic;

public class Solution
{
    /*
     * 
     * Time: O(N log N) where N is nums.Length
     * Space: O(N)
     * 
     */
    static void Main(string[] args)
    {
        string N = Console.ReadLine();
        int n = int.Parse(N);

        var result = new SortedSet<int>();

        for (var i = 0; i < n; i++)
        {
            string numValue = Console.ReadLine();
            int num = int.Parse(numValue);
            result.Add(num);
        }

        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
    }
}